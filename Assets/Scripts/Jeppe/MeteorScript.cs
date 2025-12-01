using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public int hitForce;
    public UIManager ui;

    void Start()
    {
        // Dette henter Rigidbody og transform komponenterne
        rb = GetComponent<Rigidbody2D>();

        // Hvis positionen er over 0 på x-aksen, bevæger den mod venstre, ellers bevæger den mod højre
        if (transform.position.x > 0)
            rb.AddForce(Vector2.left * speed);
        else
            rb.AddForce(Vector2.right * speed);        
    }

    public void Update()
    {        
        // Hvis y positionen er over 20, så dør meteoren
        if(transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }

    // Metode til at smide meteoren opad
    public void BounceAway()
    {       
        rb.linearVelocity = new Vector2(rb.linearVelocityX, hitForce);       
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            ui.TakeDamage();
            Destroy(gameObject);
        }
    }
    

}
