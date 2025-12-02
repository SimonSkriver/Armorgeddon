using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    [Header ("Health bar")]
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] CastleHealth castleHealth;

    [Header ("Buttons")]
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject gameOverButton;

    [Header ("Game stopper")]
    [SerializeField] StopGame stopGame;


    void Start()
    {
        startGameButton.SetActive(true);
        healthText.text = "Castle health: " + castleHealth.currentHealth.ToString();
    }
    
    public void UpdateHealthText()
    {
        healthText.text = "Castle health: " + castleHealth.currentHealth.ToString();
    }
    
    public void GameOver()
    {
        gameOverButton.SetActive(true);
        stopGame.DisableGame();
    }
}
