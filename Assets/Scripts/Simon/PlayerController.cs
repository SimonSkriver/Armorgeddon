using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rb;

    [Header("Movement settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    //[SerializeField] float invinsibilityTime = 0.3f;
    public Vector2 moveInput;

    [Header("Ground and platform check settings")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask platformLayer;
    [SerializeField] Vector2 groundCeckSize;
    
    public bool isGrounded;
    public AudioSource JumpSound;
   
    private Collider2D platform;

    //Alt herunder er lyd
    //public AudioSource jumpSound;

    void Update()
    {
        CheckGrounded();
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocityY);
    }

    void OnJump() // Is called when you press space
    {
        if (isGrounded || platform != null) // Make sure you can only jump, when you're grounded or on a platform
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce); // Updates the Y velocity
            JumpSound.Play();
            //SimpleAudio.Instance.Play("Leap");
        }
    }

    void OnMove(InputValue value) // This gets called when you click a move button (set in the input action assets)
    {
        Debug.Log("Move called");
        moveInput = value.Get<Vector2>(); // This value is constantly read in update and used to update the X velocity
       
    }

    void OnDescent()
    {
        if (platform != null)
        {
            StartCoroutine(TemporarilyDisbleCollider(platform));
        }
    }

    IEnumerator TemporarilyDisbleCollider(Collider2D platformCollider)
    {
        platformCollider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        platformCollider.enabled = true;
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCeckSize, 0f, groundLayer); //This function is called from update, which means that the bool "isGrounded" constantly gets updated. The bool turns true, when the OverlapBox hits the Ground layer
        platform = Physics2D.OverlapBox(groundCheck.position, groundCeckSize, 0f, platformLayer); //Returns the collider of the platform, if within reach
    }

    void OnDrawGizmosSelected() // For debugging purposes. Draws an outline around the groundCheck box
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, groundCeckSize);
    }
}
