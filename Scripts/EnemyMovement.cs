using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public Animator anim;

    public float speed = 0.5f;
    public bool MoveRight;

    public float enemyHeadYPos = 0.5f;

    public ManagerUI managerUIScript;
    public PlayerController playerControllerScript;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

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

    public void Die()
    {
        Destroy(gameObject);

        if (gameObject.tag == "EnemyGoomba")
        {
            managerUIScript.ForGoomba();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 pos = col.collider.transform.position;
        Vector2 goombaPos = transform.position;

        if (pos.y >= goombaPos.y + enemyHeadYPos)
        {
            anim.SetBool("death", true);
        }
        else if(col.collider.CompareTag("Player"))
        {
            playerControllerScript.TakeDamage();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.up * enemyHeadYPos, Color.red);
    }
#endif
}
