using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public ManagerUI managerUIScript;
    public PlayerController playerControllerScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("mushroom"))
        {
            playerControllerScript.GetMushroom();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("coin"))
        {
            managerUIScript.ForScore();
            Destroy(gameObject);
        }
    }
}
