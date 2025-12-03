using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public int score = 0;
    private int highscore;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Highscore: " + highscore;
        scoreText.text = "Score: " + score.ToString();
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
}   
