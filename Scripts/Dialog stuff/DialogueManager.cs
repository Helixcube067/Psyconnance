﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    /* This is the dialog class. It functions with the dialog and uses the Dialog class
     * It pauses the game then sets the dialogCanvas to true and then changes the text accordingly
     * Coroutine used to queue in the text and animate it
     */ 
    private Queue<string> sentences;
    public GameObject dialogueCanvas;
    public PauseGame pauseGame;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject finishButton;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        
        pauseGame.Pause(dialogueCanvas);
        dialogueCanvas.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void OpeningScene()
    {
        if (sentences.Count == 0)
        {
            OpeningEnd();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        pauseGame.Resume(dialogueCanvas);
        Debug.Log("End of Conversation");
    }

    void OpeningEnd()
    {
        continueButton.SetActive(false);
        finishButton.SetActive(true);
        Debug.Log("End of Conversation");
    }

    public void OpeningDialogue(Dialogue dialogue, string name)
    {
        dialogueCanvas.SetActive(true);
        nameText.text = name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        OpeningScene();
    }
}
