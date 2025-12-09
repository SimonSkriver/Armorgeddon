using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;    
    public int minCurve = 0;
    public int maxCurve = 100;
    public int hitForce;

    // Her går vi ind og finder ScoreManager scriptet, så vi kan tilføje point når meteoren bliver ramt.
    private ScoreManager scoreManager;
    public AudioSource hitSound;

    void Start()
    {
        // Dette henter Rigidbody, så vi kan styre meteoren. Vi finder også scoreManager scriptet i scenen, så vi kan tilføre score længere nede.
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindAnyObjectByType<ScoreManager>();

        // Hvis positionen er over 0 på x-aksen, bevæger den mod venstre, vice versa. Speed bliver også udregnet random lige over
        speed = Random.Range(minCurve, maxCurve);

        if (transform.position.x > 0)
        {
            rb.AddForce(Vector2.left * speed);
        }
        else
        {
            rb.AddForce(Vector2.right * speed);
        }
    }

    public void Update()
    {        
        // Hvis y positionen er over 40, så dør meteoren
        if(transform.position.y > 40)
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
        // Scriptet tjekker om meteoren rammer et Gameobject med tagget "Hitbox". Hvis ja, kaldes BounceAway, addscore og spiller en lyd.
        if(collision.gameObject.CompareTag("Hitbox"))
        { 
            BounceAway();
            scoreManager.AddScore();
            hitSound.Play();
        }
    }

    // Metode til at smide meteoren opad. Tilfører en meget stor kraft opad på y-aksen.
    public void BounceAway()
    {       
        rb.linearVelocity = new Vector2(rb.linearVelocityX, hitForce);       
    }
}
