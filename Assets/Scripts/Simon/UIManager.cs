using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("Health bar")]
    [SerializeField] CastleHealth castleHealth;
    [SerializeField] Slider healthBar;

    public void Update()
    {
        healthBar.value = castleHealth.currentHealth;
        healthBar.maxValue = castleHealth.maxHealth;
    }
}
