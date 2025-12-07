using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    [Header ("Castle health settings")]
    public int currentHealth;
    public int maxHealth = 10;
    public SceneHandler sceneLoader;

    void Start()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            sceneLoader.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D meteor)
    {
        if (meteor.CompareTag("Meteor"))
        {
            currentHealth--;
            Destroy(meteor.gameObject); 
        }
    }
}
