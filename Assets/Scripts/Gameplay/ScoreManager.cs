using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to our score text
    public TextMeshProUGUI highscoreText; // Reference to our highscore text
    public int score = 0; // Initial score value is set to 0
    private int highscore;    

    //Svaerhedsgrad variabler
    private SpawnerScript spawnerScript;
    
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0); // Checks if there's an int saved under "highscore" within playerprefs. If not, highscore is set to 0
        highscoreText.text = "Highscore: " + highscore; // Shows our highscore value
        scoreText.text = "Score: " + score.ToString(); // Shows our score value
        spawnerScript = FindAnyObjectByType<SpawnerScript>();
    }

    public void AddScore()
    {
        score++; // Increments our score value 
        scoreText.text = "Score: " + score.ToString(); // Updates the number on the screen

        if (PlayerPrefs.GetInt("highscore") < score) // If our score is greater than the highscore saved in playerprefs, highscore gets set to the current score value, and the new highscore is saved in playerprefs and the number is updated on screen
        {
            Debug.Log("New highscore");
            highscore = score;
            PlayerPrefs.SetInt("highscore", score);
            highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
        }
    }

    public void Update()
    {
        if (SpawnerScript.instance.gameTime == 0.2f)
        { 
            return; 
        }
        else if (SpawnerScript.instance.gameTime >= 30f)
        {
            spawnerScript.spawnRate -= 0.2f;
            SpawnerScript.instance.gameTime = 0;
            Debug.Log("SpawnRate increased");
        }
    }
}   
