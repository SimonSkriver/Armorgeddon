using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public int score = 0;
    private int highscore;
    private int level = 1;

    //Sværhedsgrad variabler
    private SpawnerScript spawnerScript;

    [Header("Level 1")]
    public float SpawnRatelvl1 = 3f;
    

    [Header("Level 2")]
    public float SpawnRatelvl2 = 2f;
    public int scoreNeeded2 = 5;

    [Header("Level 3")]
    public float SpawnRatelvl3 = 1f;
    public int scoreNeeded3 = 30;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Highscore: " + highscore;
        scoreText.text = "Score: " + score.ToString();
        spawnerScript = FindAnyObjectByType<SpawnerScript>();

        spawnerScript.spawnRate = SpawnRatelvl1;
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
        if(level == 1 && score >= scoreNeeded2)
        {
            level = 2;
            spawnerScript.spawnRate = SpawnRatelvl2;
            Debug.Log("Level 2");     
        }
        else if(level == 2 && score >= scoreNeeded3)
        {
            level = 3;
            spawnerScript.spawnRate = SpawnRatelvl3;
            Debug.Log("Level 3");
        }
    }
}   
