using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: PlayerMovement.cs
/// Date last Modified: 2020-11-20
/// Program description
///  - Contain the function of player movement
///  
/// Revision History
/// 2020-11-17: Added player movement function and jump.
/// 2020-11-17: Added the functions for several blocks
/// 2020-11-20: Player can kill enemy. If player kills enemy, player auto jump (20.0f)
/// 
/// </summary>

public class PlayerMovement : MonoBehaviour
{

	[Header("Speed")]
	public float movePower = 5f;
	public float jumpPower = 2f;

	// components
	SpriteRenderer spriteRenderer;
	Rigidbody2D rigid;
	Animator animator;

	// to move and jump the character
	Vector3 movement;
	bool isJumping = false;

	// to use double jump block
	bool isDoubleJump;
	int jumpCount;

    #region Unity_Methods
    //Initialization
    void Start()
	{
		// get all components
		rigid = gameObject.GetComponent<Rigidbody2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		animator = gameObject.GetComponent<Animator>();
	}

	//Updates	
	void Update()
	{
		// prevent double jump
		if (Input.GetButtonDown("Jump") && (!animator.GetBool("isJumping") || (animator.GetBool("isJumping") && isDoubleJump)))
		{
			jumpCount++;
			isJumping = true;
			animator.SetBool("isJumping", true);
			animator.SetTrigger("doJumping"); // jump animation

			// if i used the double jump block - cannot double jump anymore
			if(jumpCount == 2)
            {
				isDoubleJump = false;
				jumpCount = 0;
            }
		}
	}

	//Physics engine Updates
	void FixedUpdate()
	{
		Move();
		Jump();
	}

    #endregion

    void Move()
	{
		Vector3 moveVelocity = Vector3.zero;

		// Idle animation
		if(Input.GetAxisRaw("Horizontal") == 0)
        {
			animator.SetBool("isMoving", false);
		}

		// moving and moving animations
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			moveVelocity = Vector3.left;
			animator.SetBool("isMoving", true);

			//transform.localScale = new Vector3(-1, 1, 1); // flip to left turn
			spriteRenderer.flipX = true; // flip to left turn
		}
		else if (Input.GetAxisRaw("Horizontal") > 0)
		{
			moveVelocity = Vector3.right;
			animator.SetBool("isMoving", true);

			//transform.localScale = new Vector3(1, 1, 1); // flip to right turn
			spriteRenderer.flipX = false;  // flip to right turn

		}

		// actual move
		transform.position += moveVelocity * movePower * Time.deltaTime;
	}

	// jump with rigid body 2d
	void Jump()
	{
		if (!isJumping)
			return;

		//Prevent Velocity amplification.
		rigid.velocity = Vector2.zero;

		Vector2 jumpVelocity = new Vector2(0, jumpPower);
		rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

		isJumping = false;
	}

	// on player's foot, there is a box collider(trigger box)
    private void OnTriggerEnter2D(Collider2D collision)
    {
		// player steps the ground
		Debug.Log(collision.gameObject.layer);
		if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9 && rigid.velocity.y < 0)
        {
			// Idle
			animator.SetBool("isJumping", false);
        }

		// blocks function
		if((collision.gameObject.layer == 9 && rigid.velocity.y < 0))
		{
			BlockStatus block = collision.gameObject.GetComponent<BlockStatus>();

            switch (block.type)
            {
				// auto jump block
				case "Up":
					Vector2 upVelocity = new Vector2(0, block.value);
					rigid.AddForce(upVelocity, ForceMode2D.Impulse);
					break;

				// double jump block
				case "Double":
					isDoubleJump = true;
					break;

				// portal block
				case "Portal":
					Vector3 portal2 = block.portal.transform.position;
					Vector3 warp = new Vector3(portal2.x, portal2.y + 2.0f, portal2.z);
					transform.position = warp;

					break;
            }
        }

		// if player step on th eenemy
		if(collision.gameObject.tag == "Enemy" && !collision.isTrigger && rigid.velocity.y < -3.0f)
        {
			// get enemy component
			EnemyMovement enemy = collision.gameObject.GetComponent<EnemyMovement>();

			// call enemy die method
			enemy.Die();

			// this vector is used when player step on the enemy and auto_jump again
			Vector2 killVector = new Vector2(0, 20.0f);
			rigid.AddForce(killVector, ForceMode2D.Impulse);

			// set score
			ScoreManager.SetScore(enemy.score);

			// for debug
			Debug.Log(ScoreManager.GetScore());
        }

		// get coins
		if(collision.gameObject.tag == "Coin")
        {
			// get coin component
			CollectableObject coin = collision.gameObject.GetComponent<CollectableObject>();
			
			// set score
			ScoreManager.SetScore(coin.value);

			// for debug
			Debug.Log(ScoreManager.GetScore());

			// destroy instantly
			Destroy(collision.gameObject, 0.0f);
        }
    }
	// just for debug
    private void OnTriggerExit2D(Collider2D collision)
    {
		Debug.Log(collision.gameObject.layer);
	}
	
}