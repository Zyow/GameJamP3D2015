using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	public Action jumped;

	public float speed;
	private bool doJump;
	public float jumpForce;

	private Rigidbody myRigidbody;
	private Vector3 v3;

	private Vector3 v3P1;
	private Vector3 v3P2;
	private Vector3 v3P3;
	private Vector3 v3P4;

	private MyCharacterController myCharacterController;

	void Awake ()
	{
		myRigidbody = GetComponent<Rigidbody>();
		myCharacterController = GetComponent<MyCharacterController>();
	}

	void FixedUpdate ()
	{
		v3 = Vector3.forward * speed; //* 50 * Time.fixedDeltaTime;


		switch (tag)
		{
			case "Player1" :
				v3P1 = v3 * Input.GetAxis("Horizontal Player 1");
				v3P1.y = myRigidbody.velocity.y;
				myRigidbody.velocity = v3P1;
				if (Input.GetButtonDown("Jump Player 1"))
					Jump ();
				//if (Input.GetButtonDown("Action Player 1"))
				break;
			case "Player2" :
				v3P2 = v3 * Input.GetAxis("Horizontal Player 2");
				v3P2.y = myRigidbody.velocity.y;
				myRigidbody.velocity = v3P2;
				if (Input.GetButtonDown("Jump Player 2"))
					Jump ();
				break;
			case "Player3" :
				v3P3 = v3 * Input.GetAxis("Horizontal Player 3");
				v3P3.y = myRigidbody.velocity.y;
				myRigidbody.velocity = v3P3;
				if (Input.GetButtonDown("Jump Player 3"))
					Jump ();
				break;
			case "Player4" :
				v3P4 = v3 * Input.GetAxis("Horizontal Player 4");
				v3P1.y = myRigidbody.velocity.y;
				myRigidbody.velocity = v3P4;
				if (Input.GetButtonDown("Jump Player 4"))
					Jump ();
				break;
		}
	}

	private void Action ()
	{
		print ("action");
	}

	private void Hit ()
	{
		print ("hit");
	}


	private void Jump ()
	{
		if (myCharacterController.OnTheGround)
		{
//			doJump = true;
			myRigidbody.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
			if (jumped != null)
			{
				jumped();
			}
		}

	}
}
