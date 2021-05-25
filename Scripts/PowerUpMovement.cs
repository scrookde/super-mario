using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpMovement : MonoBehaviour
{
    public GameObject player;

    public float speed = 1.5f;
    public bool MoveRight;

    public ManagerUI managerUIScript;
    public PlayerController playerControllerScript;


    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.tag == "turnTrigger")
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }
}