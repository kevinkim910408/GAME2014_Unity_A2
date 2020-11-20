using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: EnemyMovement.cs
/// Date last Modified: 2020-11-20
/// Program description
///  - Control Enemy characters movement and A.I, animations
///  
/// Revision History
/// 2020-11-20:  Added enemy - patrol on the tile
///              Added enemy die animation
/// 
/// </summary>
/// 

public class EnemyMovement : MonoBehaviour
{
    [Header("Basic Stats")]
    public float moveSpeed;
    public int enemyType;
    public int score;


    // boolean
    bool isLeft = true;
    bool isDie = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // move
    private void Move()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    // enemy die
    public void Die()
    {
        // change boolean to true
        isDie = true;

        // enemy flips Y-Axis
        SpriteRenderer spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.flipY = true;

        // enemy falling down - delete box collider, then enemy cannot collide with tiles
        BoxCollider2D boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;

        // Bouncing when enemy dies
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Vector2 dieVector = new Vector2(0, 10.0f);
        rigidbody2D.AddForce(dieVector, ForceMode2D.Impulse);
        

        // destroy enemy
        Destroy(this.gameObject, 5.0f);
    }

    // for collision box with tag "endPoint"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if hit this collision
        if(collision.tag == "endPoint")
        {
            // if enemy hit from left side
            if (isLeft)
            {
                // change the direction
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);

                // let him go right side
                isLeft = false;
            }
            // if enemy hit from right side
            else
            {
                // change direction
                transform.eulerAngles = new Vector3(0.0f, 0, 0.0f);

                // let him go left side
                isLeft = true;
            }
        }
        
    }
}
