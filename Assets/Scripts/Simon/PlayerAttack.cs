using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public MeteorScript meteorScript;

    [Header ("Meteor check settings")]
    [SerializeField] Transform meteorCheck;
    [SerializeField] LayerMask meteor;
    [SerializeField] float meterCheckRadius;
    private Collider2D meteorCollider;

    void Update()
    {
        CheckMeteor();
    }

    void OnAttack()
    {
        if (meteorCollider != null)
        {
            Debug.Log("You hit a meteor");
            meteorScript.BounceAway();
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
