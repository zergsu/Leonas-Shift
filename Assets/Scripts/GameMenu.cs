using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }

    public void Resume() {
        Time.timeScale = 1;
        gameObject.SetActive(false);
	}
}
