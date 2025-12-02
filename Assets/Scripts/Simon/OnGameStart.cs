using UnityEngine;

public class OnGameStart : MonoBehaviour
{
    public GameObject player;
    public GameObject spawner;
    public GameObject button;
    public GameObject healthBar;


    public void StartGame()
    {
        Instantiate(player, new Vector2(0f, -1.851854f), transform.rotation);
        healthBar.SetActive(true);
        Destroy(button);
    }

}
