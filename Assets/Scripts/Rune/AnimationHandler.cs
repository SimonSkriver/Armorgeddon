using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    public AudioSource SwingSound;
     public AudioSource WalkSound;
    public AudioSource JumpSound;
    
    void Start()
    {
        //Here we get a reference to both our animator, playerController and attack, so that we can update the animation controller parameters according to the players current state
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

   void OnJump() //calling the jump method to trigger jump animation, with an if statement making sure we're grounded and actually able to jump
    {
        if (playerController.isGrounded)
        {
        animator.SetTrigger("Jump");
        }
    }

    void OnMove() //calling move method to trigger running animation, by switching bool
    {
        animator.SetBool("Running", true);
       // SimpleAudio.Instance.Play("Footsteps");
       WalkSound.Play();
       
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
       // SimpleAudio.Instance.Play("Swing");
        SwingSound.Play();
    }
    void FlipCharacter() //method in which we flip the character according to movement direction. Using rotation, to avoid issues with scaling, physics and the animation rig and stuff
    {
        if (playerController.moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (playerController.moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Update()
    {
        FlipCharacter(); //calling the flip function
        
        if (playerController.isGrounded) // else/if switching the Grounded parameter in the animator according to the grounded bool in the playerController
        {
            animator.SetBool("Grounded", true);
        }
        else
        {
            animator.SetBool("Grounded", false);
        }

        if (playerController.moveInput.x != 0f) return; //if moveInput is anything but 0, we "return" out of the if statement and execute no more code. If it is 0 then we set running to false and thus play the idle
        {
            animator.SetBool("Running", false);
            WalkSound.Stop();
        }
    }
}
