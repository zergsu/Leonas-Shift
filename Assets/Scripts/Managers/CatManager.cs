using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    [SerializeField] GameObject catPopup;
    [SerializeField] bool firstTime;
    bool canDialog;

    private void Start() {
        firstTime = false;
    }

	private void Update() {
		if(Input.GetKeyDown(KeyCode.F) && canDialog) {
            GameEventsHandler.Dialog(true);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            catPopup.SetActive(true);
            if (firstTime) {
                GameEventsHandler.Dialog(true);
                firstTime = false;
            } else {
                canDialog = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            catPopup.SetActive(false);
            canDialog = false;
        }
    }
}
