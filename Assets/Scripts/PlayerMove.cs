using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : PlayerBase 
{
	public Action jumped;

	public float speed;
	public float jumpForce;

	private Rigidbody myRigidbody;
	private Vector3 v3;

	private MyCharacterController myCharacterController;
	private float horizontalInputSpeed;
	public bool isMovingToTheRight = true;

	protected override void Awake ()
	{
		base.Awake ();

		myRigidbody = GetComponent<Rigidbody>();
		myCharacterController = GetComponent<MyCharacterController>();
	}

	void FixedUpdate ()
	{
		horizontalInputSpeed = Input.GetAxis("Horizontal Player " + playerNbr.ToString());

		v3 = Vector3.forward * speed * horizontalInputSpeed;
		v3.y = myRigidbody.velocity.y;
		myRigidbody.velocity = v3;

		if (Input.GetButtonDown ("Jump Player "+ playerNbr.ToString ()))
			Jump ();

		if (horizontalInputSpeed < -0.1)
			isMovingToTheRight = false;
		else if (horizontalInputSpeed > 0.1)
			isMovingToTheRight = true;
	}


	private void Jump ()
	{
		if (myCharacterController.OnTheGround)
		{
			myRigidbody.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
			if (jumped != null)
			{
				jumped();
			}
		}

	}
}
