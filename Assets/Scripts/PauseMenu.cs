using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public Transform menu;
    public static bool isPaused = false;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.gameObject.activeInHierarchy)
            {
                SetPaused(false);
            }
            else
            {
                SetPaused(true);
            }
        }
	}

    public void SetPaused(bool shouldPause)
    {
        menu.gameObject.SetActive(shouldPause);
        Time.timeScale = shouldPause ? 0f : 1f;
        isPaused = shouldPause;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
