using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private MeteorScript meteorScript;

    [Header ("Meteor check settings")]
    [SerializeField] Transform meteorCheck;
    [SerializeField] LayerMask meteor;
    [SerializeField] float meterCheckRadius;
    private Collider2D meteorCollider;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    void Update()
    {
        CheckMeteor();
        meteorScript = FindAnyObjectByType<MeteorScript>();
    }

    void OnAttack()
    {
        if (meteorCollider != null)
        {
            meteorScript.BounceAway();
            scoreManager.AddScore();
        }
    }
    
    void CheckMeteor()
    {
        meteorCollider = Physics2D.OverlapCircle(meteorCheck.position, meterCheckRadius, meteor);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meteorCheck.position, meterCheckRadius);
    }
}
