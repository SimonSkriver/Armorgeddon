using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int health = 10;

    void Start()
    {
        scoreText.text = "Castle health: " + health.ToString();
    }

    void OnTriggerEnter2D(Collider2D meteor)
    {
        if (meteor.CompareTag("Meteor"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health--;
        scoreText.text = "Castle health: " + health.ToString();
    }
}
