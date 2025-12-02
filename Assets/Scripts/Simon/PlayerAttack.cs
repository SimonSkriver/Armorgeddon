using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("Meteor check settings")]
    [SerializeField] Transform meteorCheck;
    [SerializeField] LayerMask Meteor;
    [SerializeField] float meterCheckRadius;
    Collider2D meteorCollider;

    void Update()
    {
        CheckMeteor();
    }

    void OnAttack()
    {
        if (meteorCollider != null)
        {
            
        }
    }

    void CheckMeteor()
    {
        meteorCollider = Physics2D.OverlapCircle(meteorCheck.position, meterCheckRadius, Meteor);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meteorCheck.position, meterCheckRadius);
    }
}
