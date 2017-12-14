using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public Transform menu;
    public static bool isPaused = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.gameObject.activeInHierarchy)
            {
                unpauseGame();
            }
            else
            {
                menu.gameObject.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
	}

    public void ResumeGame()
    {
        unpauseGame();
    }

    private void unpauseGame()
    {
        menu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
