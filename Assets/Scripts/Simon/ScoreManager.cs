using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public int score = 0;
    private int highscore;    

    //Sværhedsgrad variabler
    private SpawnerScript spawnerScript;
    
    

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Highscore: " + highscore;
        scoreText.text = "Score: " + score.ToString();

        spawnerScript = FindAnyObjectByType<SpawnerScript>();        
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();

        if(PlayerPrefs.GetInt("highscore") < score)
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
