using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public int hitForce;
    private ScoreManager scoreManager;
    

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
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hitbox"))
        { 
            BounceAway();
            scoreManager.AddScore();
            SimpleAudio.Instance.Play("Hit");
        }
        
    }


    // Metode til at smide meteoren opad
    public void BounceAway()
    {       
        rb.linearVelocity = new Vector2(rb.linearVelocityX, hitForce);       
    }
    
    
    
}
