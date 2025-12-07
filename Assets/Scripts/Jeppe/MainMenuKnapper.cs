using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuKnapper : MonoBehaviour
{
    // Scriptet styrer knapperne i main menuen og game over menuen.
    // Hver script har en metode der loader scenerne.
    
    private int nextScene;
    public Animator transition;
    public float transitionDuration; //Overall duration of transition, which is adjustable
    private float fadeAnimDuration = 1f; //duration of keyframed transition anim. NO TOUCHY!!
    
    public void StartGame()
    {
        nextScene = 1;
        LoadNextScene();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame() 
    {
        nextScene = 1;
        LoadNextScene();
    }

    public void MainMenu()
    {
        nextScene = 0;
        LoadNextScene();
    }

    public void GameOver()
    {
        nextScene = 2;
        SimpleAudio.Instance.Play("Doomed");
        LoadNextScene();
    }

    public void LoadNextScene() //loads next scene by starting the coroutine
    {
        Debug.Log("Loading: "+ nextScene);
        StartCoroutine(LoadScene()); //Else starts coroutine
    }

    IEnumerator LoadScene() //Coroutine making sure scene only loads after animation plays
    {
        transition.speed = fadeAnimDuration / transitionDuration; //Sync anim speed to transition duration
        transition.SetTrigger("SceneLoad"); //start transition animation
        yield return new WaitForSeconds(transitionDuration); //wait for transition duration, so that anim can play
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single); //load specified scene
    }
}
