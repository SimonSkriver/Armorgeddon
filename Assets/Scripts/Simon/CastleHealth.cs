using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    [Header ("Castle health settings")]
    public int currentHealth;
    public int maxHealth = 10;
    public UIManager ui;

    void Start()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            ui.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D meteor)
    {
        if (meteor.CompareTag("Meteor"))
        {
            currentHealth--;
            //ui.UpdateHealthText();
            Destroy(meteor.gameObject);
            SimpleAudio.Instance.Play("Impact");
        }
    }
}
