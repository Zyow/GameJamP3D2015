using UnityEngine;
using System;
using System.Collections;

using System;
using System.Collections;

public class PlayerMove : PlayerBase 
{
	public Action jumped;
	
	public float speed;
	public float jumpForce;
	
	private Rigidbody myRigidbody;
	private Vector3 v3;
	private string playerString;
	
	private MyCharacterController myCharacterController;
	
	protected override void Awake ()
	{
		base.Awake ();
		
		myRigidbody = GetComponent<Rigidbody>();
		myCharacterController = GetComponent<MyCharacterController>();
		switch (tag)
		{
		case "Player1" :
			playerNbr = 1;
			playerString=playerNbr.ToString();
			break;
		case "Player2" :
			playerNbr = 2;
			playerString=playerNbr.ToString();
			break;
		case "Player3" :
			playerNbr = 3;
			playerString=playerNbr.ToString();
			break;
		case "Player4" :
			playerNbr = 4;
			playerString=playerNbr.ToString();
			break;
		}
	}
	
	void FixedUpdate ()
	{
		v3 = Vector3.forward * speed * Input.GetAxis("Horizontal Player " + playerNbr.ToString());
		v3.y = myRigidbody.velocity.y;
		myRigidbody.velocity = v3;
		
		if (Input.GetButtonDown ("Jump Player "+playerString))
			Jump ();
	}
	
	
	private void Jump ()
	{
		if (myCharacterController.onTheGround)
		{
			myRigidbody.velocity= new Vector3(myRigidbody.velocity.x,0f,myRigidbody.velocity.z);
			myRigidbody.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
			if (jumped != null)
			{
				jumped();
			}
		}
		
	}
}