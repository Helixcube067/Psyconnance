using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameSetter : MonoBehaviour
{
    public TMP_InputField nameField;
    public GameObject continueButton;
    private MainCharacter mc;

    private void Update()
    {
        NameChecker();
    }

    public void NameChecker() {
        if (!string.IsNullOrWhiteSpace(nameField.text))
            if (!string.IsNullOrEmpty(nameField.text))
                if(nameField.text != null)
                    continueButton.SetActive(true);
        string checker = nameField.text;
        if (string.IsNullOrWhiteSpace(nameField.text) || string.IsNullOrEmpty(nameField.text))
            continueButton.SetActive(false);
    }

    public void SubmitName() {

        if (string.IsNullOrWhiteSpace(nameField.text))
        {
            if (string.IsNullOrEmpty(nameField.text))
                Debug.LogError("You need some content in the name field");
        }
        else {
            MainCharacter.mcName = nameField.text;
            mc = new MainCharacter();
            mc.McJoins();
            //mc.SaveMember();
        }
            
    }
}
