using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Platform Type")]
    [SerializeField] bool staticPlatform;

    [Header("Customize")]
    [SerializeField] float speed = 3;
    [SerializeField] Transform[] points;

    private int index;
    private GameObject player;

    void Start() {
        index = 1;
        points[0].position = transform.position;
    }

    void Update() {
		if (staticPlatform) {
            MovePlatform();
        } else {
			if (player != null) {
                MovePlatform();
			} else { transform.position = Vector2.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime); }
		}
        if (Input.GetKeyDown(KeyCode.LeftShift) && player != null) { // release from platform if player switched worlds
            player.transform.SetParent(null);
        }
    }

    private void MovePlatform() {
		if (!staticPlatform) {
            if (player != null) {
                if (Vector2.Distance(transform.position, points[index].position) < 0.02f) {
                    return;
				} else {
                    transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);
                }
            }
		} else {
            if (Vector2.Distance(transform.position, points[index].position) < 0.02f) {
                index++;
                if (index == points.Length) {
                    index = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);
        }
    }

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Player")) {
            player = other.gameObject;
            player.transform.SetParent(transform);
        }
	}

	private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            player.transform.SetParent(null);
            player = null;
        }
    }
}
