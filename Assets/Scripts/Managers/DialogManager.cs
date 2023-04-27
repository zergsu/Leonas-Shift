using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{ 
    [Header("Refs")]
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject dialogUI;

    [Header("Customize")]
    [SerializeField] string[] sentences;

    private int index;

    private void Start() {
        GameEventsHandler.onDialog += ActiveDialog;
        dialogUI.SetActive(false);
    }

    private void Update() {
        if (textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }
		else {
            continueButton.SetActive(false);
        }

        if (textDisplay.text == sentences[sentences.Length - 1]) { //checks for the end of the dialog 
            GameEventsHandler.Dialog(false);
			dialogUI.SetActive(false);
            index = 0;
            textDisplay.text = "";
        }
    }

    IEnumerator Type() {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    IEnumerator TextTimer() {
        continueButton.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        if (index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            if (index < sentences.Length - 1) {
                SoundManager.instance.PlaySound("text2");
            }
            else if (index == sentences.Length - 1)
            { SoundManager.instance.PlaySound("text1"); }
        }
        else {
            textDisplay.text = "";
        }
    }

    public void NextSentence() {
        StartCoroutine(TextTimer());
    }

    public void ActiveDialog(bool dialog) {
		if (dialog) {
            if(dialogUI != null) {
                dialogUI.SetActive(true);
                StartCoroutine(Type());
                SoundManager.instance.PlaySound("cat");
            }
        }
    }

}
