using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = gameObject.transform.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "pipe")
        {
            player.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "pipe")
        {
            player.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }
}
