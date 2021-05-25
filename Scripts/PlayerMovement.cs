using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject player;

    public float speed = 1;
    public float movementSpeed;
    public float jumpForce = 3;

    public bool isGrounded = false;

    public Animator anim;

    public PlayerController playerControllerScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Movement
        Move();
        Jump();

        //Movement Keys
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector2(1, 1);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            CheckPipe();
        }


        if (playerControllerScript.health == 0)
        {
            anim.SetFloat("run", 0);
            anim.SetBool("dead", true);
            //SceneManager.LoadScene("Game_Scene01");
        }

        if (playerControllerScript.health == 1)
        {
            anim.SetFloat("run_big", 0);
            anim.SetBool("big", false);
            anim.SetFloat("run", Mathf.Abs(movementSpeed));
        }

        if (playerControllerScript.health == 2)
        {
            anim.SetFloat("run", 0);
            anim.SetBool("big", true);
            anim.SetFloat("run_big", Mathf.Abs(movementSpeed));
        }
    }

    private void CheckPipe()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, playerControllerScript.health == 2 ? 1.01f : 0.51f, 1 | LayerMask.NameToLayer("Player"));
        RaycastHit2D hit;
        if (playerControllerScript.health == 2)
            hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, 1 | LayerMask.NameToLayer("Player"));
        else
            hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 | LayerMask.NameToLayer("Player"));

        Debug.DrawRay(transform.position, Vector2.down * 0.51f, Color.blue, 0.1f);
        if (hit.collider == null)
        {
            print("hit nothing");
            return;
        }

        Debug.Log("hit: " + hit.collider.name);

        if (hit.collider.CompareTag("pipe"))
        {
            PipeManager pipe = hit.collider.GetComponent<PipeManager>();
            pipe.Trigger();
        }
    }

    private void Move()
    {
        movementSpeed = Input.GetAxisRaw("Horizontal");
        float moveBy = movementSpeed * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true || Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
