using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollider : MonoBehaviour
{
    public GameObject pipeCollider;
    public PlayerController PlayerControllerScript;

    public Vector3 playerTPpos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControllerScript.player.transform.position = playerTPpos;
            Debug.Log("POS VON DEM RAUM EINTRAGEN LASSEN!");
        }
    }
}
