using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : PlayerBase 
{
	public Action jumped;
	private PlayerState state = PlayerState.Moving;

	public float speed;
	public float jumpForce;

	private Rigidbody myRigidbody;
	private Vector3 v3;

	private MyCharacterController myCharacterController;
	private float horizontalInputSpeed;

	protected override void Awake ()
	{
		base.Awake ();
		myRigidbody = GetComponent<Rigidbody>();
		myCharacterController = GetComponent<MyCharacterController>();
	}

	void FixedUpdate ()
	{
		horizontalInputSpeed = Input.GetAxis("Horizontal Player "+playerString);

		if(horizontalInputSpeed != 0)
		{
			v3 = Vector3.forward * speed * horizontalInputSpeed;
			v3.y = myRigidbody.velocity.y;
			myRigidbody.velocity = v3;
		}
		
		if (Input.GetButtonDown("Jump Player "+playerString))
			Jump ();

		if (horizontalInputSpeed < -0.1)
			transform.rotation = Quaternion.Euler(0f,180f,0f);
		else if (horizontalInputSpeed > 0.1)
			transform.rotation = Quaternion.Euler(0f,0f,0f);
	}

	private void Jump ()
	{
		if (myCharacterController.onTheGround)
		{
			myCharacterController.onTheGround =false;
			myRigidbody.velocity = new Vector3(myRigidbody.velocity.x,0f,myRigidbody.velocity.z);
			myRigidbody.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
			if (jumped != null)
			{
				jumped();
			}
		}

	}
}
