using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	public Action jumped;
	public float gravityAcceleration;
	public float gravitySpeedDefault;
	public float speed;

	private Rigidbody rigidbody;
	private Vector3 v3;

	private Vector3 vertical;

	private Vector3 v3P1;
	private Vector3 v3P2;
	private Vector3 v3P3;
	private Vector3 v3P4;

	private Vector3 final;

	private float gravityCurrent;
	private bool isGrounded;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
		gravityCurrent = gravitySpeedDefault;
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "Ground")
		{
			isGrounded = true;
			print (isGrounded);
		}
	}

	void OnCollisionExit (Collision other)
	{
		if (other.transform.tag == "Ground")
		{
			isGrounded = false;
			print (isGrounded);
		}
	}

	void FixedUpdate ()
	{
		if (isGrounded)
			gravityCurrent = gravitySpeedDefault;
		else
			gravityCurrent += gravityAcceleration;

		vertical = new Vector3 (0, -gravityCurrent, 0);
		v3 = Vector3.forward * speed * 50 * Time.fixedDeltaTime;

		print (Vector3.forward);
		final = Vector3.forward + vertical;
		print (final);

		v3P1 = v3 * Input.GetAxis("Horizontal Player 1");
		v3P2 = v3 * Input.GetAxis("Horizontal Player 2");
		v3P3 = v3 * Input.GetAxis("Horizontal Player 3");
		v3P4 = v3 * Input.GetAxis("Horizontal Player 4");

		switch (tag)
		{
			case "Player1" :
				rigidbody.velocity = v3P1;
				if (Input.GetButtonDown("Jump Player 1"))
					Jump ();
				//if (Input.GetButtonDown("Action Player 1"))
					
				break;
			case "Player2" :
				rigidbody.velocity = v3P2;
				if (Input.GetButtonDown("Jump Player 2"))
					Jump ();
				break;
			case "Player3" :
				rigidbody.velocity = v3P3;
				if (Input.GetButtonDown("Jump Player 3"))
					Jump ();
				break;
			case "Player4" :
				rigidbody.velocity = v3P4;
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
		if (isGrounded)
		{
			print ("jump");
		}

		if (jumped != null)
		{
			jumped();
		}
	}
}
