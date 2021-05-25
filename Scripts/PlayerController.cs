using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public int health = 1;

    public ManagerUI managerUIScript;


    private void Update()
    {

    }
    public void TakeDamage()
    {
        health--;
    }

    public void GetMushroom()
    {
        health = 2;
        managerUIScript.ForMushroom();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("deathCol"))
        {
            SceneManager.LoadScene("Game_Scene01");
        }
    }

}
