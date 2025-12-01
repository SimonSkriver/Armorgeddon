using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Movement settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    private Vector2 moveInput;

    [Header("Ground check settings")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Vector2 groundCeckSize;

    private bool isGrounded;

    void Update()
    {
        CheckGrounded();
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocityY);
    }

    void OnJump(InputValue value) // Is called when you press space
    {
        if (value.isPressed && isGrounded) // Make sure you can only jump, when you're grounded
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce); // Updates the Y velocity
        }
    }

    void OnMove(InputValue value) // This gets called when you click a move button (set in the input action assets)
    {
        Debug.Log("Move called");
        moveInput = value.Get<Vector2>(); // This value is constantly read in update and used to update the X velocity
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCeckSize, 0f, groundLayer); //This function is called from update, which means that the bool "isGrounded" constantly gets updated. The bool turns true, when the OverlapBox hits the Ground layer
    }

    void OnDrawGizmosSelected() // For debugging purposes. Draws an outline around the groundCheck box
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, groundCeckSize);
    }
}
