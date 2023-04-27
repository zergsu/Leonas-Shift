using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] GameObject exitBond;
    [SerializeField] Sprite OpenDoor;

    private bool Open;
    private bool canOpen;

    void Start() {
        Open = false;
        canOpen = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F) && canOpen && !Open) {
            exitBond.SetActive(false);
            Open = true;
            SoundManager.instance.PlaySound("door");
            GetComponent<SpriteRenderer>().sprite = OpenDoor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            canOpen = true;
        }
    }

	private void OnTriggerExit2D(Collider2D other) {
        canOpen = false;
	}

}
