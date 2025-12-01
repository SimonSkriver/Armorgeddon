using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int health = 10;

    void Start()
    {
        scoreText.text = "Castle health: " + health.ToString();
    }

    public void TakeDamage()
    {
        health--;
        scoreText.text = "Castle health: " + health.ToString();
    }
}
