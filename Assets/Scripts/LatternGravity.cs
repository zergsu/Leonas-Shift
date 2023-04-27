using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LatternGravity : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] GameObject world;
    [SerializeField] PlayerMovement player;
    private int rotateAmount = 0;
    private bool canPress;


	private void Start() {
        GameEventsHandler.onRespawn += ResetGravity;
	}

	private void Update() {
        if (Input.GetKeyDown(KeyCode.F) && canPress) {
            world.transform.Rotate(0, 0, -90);
            canPress = false;
            player.transform.Rotate(0, 0, 90);
            rotateAmount++;
            if (rotateAmount == 4) {
                rotateAmount = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        canPress = false;
    }

    private void ResetGravity() {
        if (SceneManager.GetActiveScene().buildIndex == 3) {
            for (int i = 0; i < 4 - rotateAmount; i++) {
                world.transform.Rotate(0, 0, -90);
                player.transform.Rotate(0, 0, 90);
            }
            rotateAmount = 0;
        }
    }
}
