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
		if (Input.GetButtonDown("Jump"))
		{
			isJumping = true;
			animator.SetBool("isJumping", true);
			animator.SetTrigger("doJumping"); // jump animation
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
		Debug.Log(collision.gameObject.layer);
		if(collision.gameObject.layer == 8 && rigid.velocity.y < 0)
        {
			animator.SetBool("isJumping", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
		Debug.Log(collision.gameObject.layer);
	}
}