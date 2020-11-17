using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: PlayerMovement.cs
/// Date last Modified: 2020-11-17
/// Program description
///  - Contain the function of player movement
///  
/// Revision History
/// 2020-11-17: Added player movement function and jump
/// 
/// </summary>

public class PlayerMovement : MonoBehaviour
{

	public float movePower = 5f;
	public float jumpPower = 2f;

	SpriteRenderer renderer;

	Rigidbody2D rigid;

	Vector3 movement;
	bool isJumping = false;

	Animator animator;

	bool doubleJump;
	int jumpCount;

	//---------------------------------------------------[Override Function]
	//Initialization
	void Start()
	{
		rigid = gameObject.GetComponent<Rigidbody2D>();
		renderer = gameObject.GetComponent<SpriteRenderer>();
		animator = gameObject.GetComponent<Animator>();
	}

	//Graphic & Input Updates	
	void Update()
	{
		// prevent double jump at first
		if (Input.GetButtonDown("Jump") && (!animator.GetBool("isJumping") || (animator.GetBool("isJumping") && doubleJump)))
		{
			jumpCount++;
			isJumping = true;
			animator.SetBool("isJumping", true);
			animator.SetTrigger("doJumping"); // jump animation

			if(jumpCount == 2)
            {
				doubleJump = false;
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

	//---------------------------------------------------[Movement Function]

	void Move()
	{
		Vector3 moveVelocity = Vector3.zero;
		if(Input.GetAxisRaw("Horizontal") == 0)
        {
			animator.SetBool("isMoving", false);
		}

		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			moveVelocity = Vector3.left;
			animator.SetBool("isMoving", true);

			//transform.localScale = new Vector3(-1, 1, 1); // flip to left turn
			renderer.flipX = true; // flip to left turn
		}

		else if (Input.GetAxisRaw("Horizontal") > 0)
		{
			moveVelocity = Vector3.right;
			animator.SetBool("isMoving", true);

			//transform.localScale = new Vector3(1, 1, 1); // flip to right turn
			renderer.flipX = false;  // flip to right turn

		}

		transform.position += moveVelocity * movePower * Time.deltaTime;
	}

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
		// landing
		Debug.Log(collision.gameObject.layer);
		if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9 && rigid.velocity.y < 0)
        {
			animator.SetBool("isJumping", false);
        }

		// block
		if((collision.gameObject.layer == 9 && rigid.velocity.y < 0))
		{
			BlockStatus block = collision.gameObject.GetComponent<BlockStatus>();

            switch (block.type)
            {
				case "Up":
					Vector2 upVelocity = new Vector2(0, block.value);
					rigid.AddForce(upVelocity, ForceMode2D.Impulse);
					break;
				case "Double":
					doubleJump = true;
					break;
				case "Portal":
					Vector3 portal2 = block.portal.transform.position;
					Vector3 warp = new Vector3(portal2.x, portal2.y + 2.0f, portal2.z);
					transform.position = warp;

					break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
		Debug.Log(collision.gameObject.layer);
	}
}