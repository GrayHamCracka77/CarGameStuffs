using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame() 
    {
        // Get next scene
        // Can also call by name or build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // Game will not quit in editor, so log it
        Debug.Log("Quit");
        Application.Quit();
    }
}
