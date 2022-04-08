using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    /* This class is used to trigger dialogue and it finds the dialogue manager and then calls start dialogue
     * 
     * 
     */
    public Dialogue dialogue;
    //public GameObject player;

    void Update()
    {

    }

    private void OnMouseDown()
    {
        //float dist = Vector3.Distance(player.transform.position, this.transform.position);
        //if (dist < 4.0f)
            TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerOpening() {
        FindObjectOfType<DialogueManager>().OpeningDialogue(dialogue, MainCharacter.mcName);
    }
}
