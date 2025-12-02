using UnityEngine;

public class StopGame : MonoBehaviour
{
    [Header ("What to disable")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawner;

    public void DisableGame()
    {
        Destroy(player);
        Destroy(spawner);
    }

}
