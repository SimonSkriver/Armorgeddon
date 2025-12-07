using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header ("Meteor check settings")]
    public GameObject attackHitBox;
    public GameObject hitBoxSpawnPoint;

    void OnAttack()
    {
        GameObject hitbox = Instantiate(attackHitBox, hitBoxSpawnPoint.transform.position, Quaternion.identity);
        Destroy(hitbox, 0.2f);
    }
}
