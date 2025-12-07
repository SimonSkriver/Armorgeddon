using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuKnapper : MonoBehaviour
{
    // Scriptet styrer knapperne i main menuen og game over menuen.
    // Hver script har en metode der loader scenerne.
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
