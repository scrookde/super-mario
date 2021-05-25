using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    private float blockBottomPos = 1f;

    public PlayerController playerControllerScript;
    public ManagerUI managerUIScript;

    public Animator anim;


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.CompareTag("brick"))
        {
            Vector2 pos = col.collider.transform.position;
            Vector2 blockPos = transform.position;

            if (pos.y <= blockPos.y + blockBottomPos)
            {
                if (playerControllerScript.health > 1)
                {
                    Destroy(gameObject);
                }
            }
        }

        if (gameObject.CompareTag("coinblock"))
        {
            Vector2 pos = col.collider.transform.position;
            Vector2 blockPos = transform.position;

            if (pos.y <= blockPos.y + blockBottomPos)
            {
                anim.SetBool("destroyed", true);
                managerUIScript.ForCoins();
                managerUIScript.ForScore();
            }
        }
    }
}
