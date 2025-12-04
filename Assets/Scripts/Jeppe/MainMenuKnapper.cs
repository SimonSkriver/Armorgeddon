using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuKnapper : MonoBehaviour
{
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
}
