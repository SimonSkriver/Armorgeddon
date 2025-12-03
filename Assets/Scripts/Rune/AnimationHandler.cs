using UnityEditor.Callbacks;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = FindAnyObjectByType<PlayerController>();
    }

   void OnJump()
    {
        if(playerController.isGrounded)
        {
        animator.SetTrigger("Jump");
        animator.SetBool("Grounded", false);
        }
    }

    void OnMove()
    {
        animator.SetBool("Running", true);
    }


    void Update()
    {
                 
        
        if (playerController.moveInput.x != 0f) return;
        {
            animator.SetBool("Running", false);
        }
        
        if (playerController.isGrounded) return;
        {
            animator.SetBool("Grounded", true);
        }
    }
}
