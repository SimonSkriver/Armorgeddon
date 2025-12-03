using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider healthBar;


    void Start()
    {
        startGameButton.SetActive(true);
        
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

    public void Update()

    {
        healthBar.value = castleHealth.currentHealth;
        healthBar.maxValue = castleHealth.maxHealth;
        healthText.text = "Castle health: " + castleHealth.currentHealth.ToString();

    }
}
