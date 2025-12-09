using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("Health bar")]
    [SerializeField] CastleHealth castleHealth;
    [SerializeField] Slider healthBar;

    void Start()
    {
        healthBar.maxValue = castleHealth.maxHealth; // Sets the max value of the slider at game start to be equal to the castle's max health
    }

    public void Update() // Constantly updates the slider to be equal to the castle's current health
    {
        healthBar.value = castleHealth.currentHealth;
    }
}
