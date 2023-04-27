using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    Vector3 offset = new Vector3(0 ,0 ,-1);

	void Update() {
        if (player != null) {
            Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, 0.006f);
            newPosition += new Vector3(0, 0.005f, 0);
            transform.position = new Vector3(newPosition.x, newPosition.y, -1);
		}
    }
}
