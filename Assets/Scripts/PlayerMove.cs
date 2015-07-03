using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	public Action jumped;
	private CharacterController characterController;
	//private Rigidbody rigidbody;
	private float speed;

	void Start ()
	{
		//rigidbody = GetComponent<Rigidbody>();
		characterController = GetComponent<CharacterController>();
	}

	void Update ()
	{
		print ("a " + Input.GetAxis("Horizontal Player 1"));
		print ("b " + Input.GetAxis("Horizontal Player 2"));
		print ("c " + Input.GetAxis("Horizontal Player 3"));

		print (Input.GetButtonDown("Action Player 1"));
		//rigidbody.AddForce (Vector3.forward * Input.GetAxis("Horizontal Player 1"));
		//rigidbody.velocity.x = Input.GetAxis("Horizontal Player 1");
	}

	private void Jump ()
	{
		if (Input.GetButtonDown("Jump Player 1"))
		{

		}

		if (jumped != null)
		{
			jumped();
		}
	}
}
