using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public PlayerMovement playerMovementScript;

    public Animator anim;

    public void Trigger()
    {
        print("Triggered pipe " + name);
        anim.SetBool("pipe", true);

        playerMovementScript.player.transform.position = new Vector3(playerMovementScript.player.transform.position.x, playerMovementScript.player.transform.position.y, .5f);
        //playerMovementScript.player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private void Update()
    {
        if (playerMovementScript.player.transform.position == new Vector3(750, -1, 1) || playerMovementScript.player.transform.position.x >= 278)
        {
            Debug.Log("NJ");
            anim.SetBool("pipe", false);
        }
    }
}
