using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    [Header ("Castle health settings")]
    public int currentHealth;
    public int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D meteor)
    {
        if (meteor.CompareTag("Meteor"))
        {
            Debug.Log("Damage dealt");
            currentHealth--;
        }
    }
}
