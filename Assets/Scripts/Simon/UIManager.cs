using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    [Header ("Health bar")]
    //[SerializeField] TextMeshProUGUI healthText;
    [SerializeField] CastleHealth castleHealth;

    public Slider healthBar;


    void Start()
    {
        //startGameButton.SetActive(true);
        
    }

    public void UpdateHealthText()
    {
        //healthText.text = "Castle health: " + castleHealth.currentHealth.ToString();
    }

    public void Update()

    {
        healthBar.value = castleHealth.currentHealth;
        healthBar.maxValue = castleHealth.maxHealth;
        //healthText.text = "Castle health: " + castleHealth.currentHealth.ToString();

    }
}
