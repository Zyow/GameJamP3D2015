using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : PlayerBase 
{
	public Action jumped;
	private PlayerState state = PlayerState.Moving;

	[Header("Mouvements")]
	public float speed;
	public float jumpForce;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool canMove = true;
	private float horizontalInputSpeed;
	private bool pushed = false;
	private bool grounded = false;

	[Header("Sons")]
	public AudioClip jumpSFX;
	public AudioClip pushedSFX;

	private Rigidbody2D myRigidbody;
	private Vector3 v3;

	private MyCharacterController myCharacterController;


	protected override void Awake ()
	{
		base.Awake ();
		myRigidbody = GetComponent<Rigidbody2D>();
		myCharacterController = GetComponent<MyCharacterController>();
	}

	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

		horizontalInputSpeed = Input.GetAxis("Horizontal Player "+playerString);
		
		if (!pushed)
			myRigidbody.velocity = new Vector2(horizontalInputSpeed * speed, myRigidbody.velocity.y);


		if (horizontalInputSpeed < -0.1)
			transform.rotation = Quaternion.Euler(0f,-90f,0f);
		else if (horizontalInputSpeed > 0.1)
			transform.rotation = Quaternion.Euler(0f,90f,0f);
		
	}

	void Update()
	{
		if (grounded && Input.GetButtonDown("Jump Player " + playerString))		
		{
			myRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			audioSource.PlayOneShot (jumpSFX);
			
			if (jumped != null)
			{
				jumped();
			}
		}
	}

	private void Jump ()
	{
		if (myCharacterController.onTheGround)
		{
//			myCharacterController.onTheGround =false;
//			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,0f);
//			myRigidbody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
//			audioSource.PlayOneShot (jumpSFX);
//
//			if (jumped != null)
//			{
//				jumped();
//			}
		}
	}

	public void Pushed()
	{
		audioSource.PlayOneShot (pushedSFX);
		pushed = true;
		CancelInvoke();
		Invoke("UnPushed",0.3f);
	}

	public void UnPushed()
	{
		pushed = false;
	}
}
