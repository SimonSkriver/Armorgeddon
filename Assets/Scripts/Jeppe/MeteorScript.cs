using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public int hitForce;
    private ScoreManager scoreManager;
    public AudioSource hitSound;

    void Start()
    {
        // Dette henter Rigidbody og transform komponenterne
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindAnyObjectByType<ScoreManager>();


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

        //Roterer meteoren i dens movement direction:
        Vector2 movementDirection = rb.linearVelocity; //vi finder retningen af meteorer ved at kigge på vores rigid body component og dens linear velocity
        float rotation = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg + 90f; //Her definerer vi rotationen i radianer udfra x og y movement vectorene. +90 fordi meteoren ellers ville pege til siden...
        transform.rotation = Quaternion.Euler(0f, 0f, rotation); //og her opdaterer vi rotationen på objektet baseret på ovenstaaende
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hitbox"))
        { 
            BounceAway();
            scoreManager.AddScore();
            hitSound.Play();
        }
        
    }


    // Metode til at smide meteoren opad
    public void BounceAway()
    {       
        rb.linearVelocity = new Vector2(rb.linearVelocityX, hitForce);       
    }
    
    
    
}
