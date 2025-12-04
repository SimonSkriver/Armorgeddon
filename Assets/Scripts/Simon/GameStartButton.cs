using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    [Header ("What to instatiate/enable")]
    //[SerializeField] GameObject player;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject healthBar;

    public void StartGame()
    {
        //Instantiate(player, new Vector2(0f, -1.851854f), transform.rotation);
        healthBar.SetActive(true);
    }
}
