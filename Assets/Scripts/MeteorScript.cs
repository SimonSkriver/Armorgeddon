using UnityEngine;
using UnityEngine.InputSystem;

public class MeteorScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform Pos;
    public float speed = 5f;
    public int hitForce;

    void Start()
    {
        // Dette henter Rigidbody og transform komponenterne
        rb = GetComponent<Rigidbody2D>();
        Pos = GetComponent<Transform>();

        // Hvis positionen er over 0 på x-aksen, bevæger den mod venstre, ellers bevæger den mod højre
        if (Pos.position.x > 0)
            rb.AddForce(Vector2.left * speed);
        else
            rb.AddForce(Vector2.right * speed);        
       
    }
    public void Update()
    {        
        // Hvis y positionen er over 20, så dør meteoren
        if(Pos.position.y > 20)
        {
            Destroy(gameObject);
        }
    }

    // Metode til at smide meteoren opad
    public void bounceAway()
    {       
        rb.AddForce(Vector2.up * speed * hitForce);       
    }
    

    

}
