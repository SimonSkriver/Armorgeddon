using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    [Header ("Castle health settings")]
    public int currentHealth;
    public int maxHealth = 10;
    public SceneHandler sceneLoader;

    void Start()
    {
        currentHealth = maxHealth; // Current health is set to max health initially
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            sceneLoader.GameOver(); // Constantly checking, if castle health is equal to, or less than zero. If so, it runs the GameOver method from sceneLoader
        }
    }

    void OnTriggerEnter2D(Collider2D meteor)
    {
        if (meteor.CompareTag("Meteor"))
        {
            currentHealth--;
            Destroy(meteor.gameObject); // When a meteor enters the ground's trigger zone, it decrements the health, and destroys the GameObject attached to the meteor tag
        }
    }
}
