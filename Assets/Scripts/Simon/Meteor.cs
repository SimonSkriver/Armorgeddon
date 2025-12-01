using UnityEngine;

public class Meteor : MonoBehaviour
{
    public UIManager ui;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            ui.TakeDamage();
            Destroy(gameObject);
        }
    }
}
