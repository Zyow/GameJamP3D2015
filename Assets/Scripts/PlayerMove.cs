using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	public Action jumped;

	public float speed;
	private bool doJump;
	public float jumpForce;
	private int playerNbr;

	private Rigidbody myRigidbody;
	private Vector3 v3;

	private MyCharacterController myCharacterController;

	void Awake ()
	{
		myRigidbody = GetComponent<Rigidbody>();
		myCharacterController = GetComponent<MyCharacterController>();
		switch (tag)
		{
		case "Player1" :
			playerNbr = 1;
			break;
		case "Player2" :
			playerNbr = 2;
			break;
		case "Player3" :
			playerNbr = 3;
			break;
		case "Player4" :
			playerNbr = 4;
			break;
		}
	}
//	void Update()
//	{
//		if (Input.GetButtonDown("Jump Player "+playerNbr.ToString()))
//			Jump ();
//	}
	void FixedUpdate ()
	{
		v3 = Vector3.forward * speed * Input.GetAxis("Horizontal Player " + playerNbr.ToString()); //* 50 * Time.fixedDeltaTime;
//		v3P1 = v3 * Input.GetAxis("Horizontal Player 1");
		v3.y = myRigidbody.velocity.y;
		myRigidbody.velocity = v3;
		if (Input.GetButtonDown("Jump Player "+playerNbr.ToString()))
			Jump ();
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
