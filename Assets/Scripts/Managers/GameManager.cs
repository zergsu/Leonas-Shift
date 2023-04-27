using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Menu, Dark, Light;


	private void Start() {
        GameEventsHandler.onNextLevel += NextLevel;
    }

	void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Menu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Menu.activeInHierarchy)
        {
            Menu.SetActive(false);
            Time.timeScale = 1;
        }
       if(Input.GetKeyDown(KeyCode.LeftShift))
		{
            SwitchWorld();
		}
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private void SwitchWorld() {
        if(Light != null && Dark != null)
        if (Light.activeInHierarchy) {
            Dark.SetActive(true);
            Light.SetActive(false);
        } else {
            Dark.SetActive(false);
            Light.SetActive(true);
        }
    }
}
