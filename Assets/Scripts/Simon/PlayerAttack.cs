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
    public GameObject attackHitBox;
    public GameObject hitBoxSpawnPoint;

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
        GameObject Hitbox = Instantiate(attackHitBox, hitBoxSpawnPoint.transform.position, Quaternion.identity);
        Destroy(Hitbox, 0.2f);
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
