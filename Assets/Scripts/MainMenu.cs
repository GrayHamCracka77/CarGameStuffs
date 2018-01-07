using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadEditor()
    {
        SceneManager.LoadScene("CarEditor");
    }

    public void QuitGame()
    {
        // Game will not quit in editor, so log it
        Debug.Log("Quit");
        Application.Quit();
    }
}
