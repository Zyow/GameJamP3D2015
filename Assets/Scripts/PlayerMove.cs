using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : PlayerBase 
{
	public Action jumped;
	private PlayerState state = PlayerState.Moving;
	private bool pushed;

	public float speed;
	public float jumpForce;

	public AudioClip jumpSFX;
	public AudioClip pushedSFX;

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

		if(horizontalInputSpeed != 0 && pushed == false)
		{
			v3 = Vector3.right * speed * horizontalInputSpeed;
			v3.y = myRigidbody.velocity.y;
			myRigidbody.velocity = v3;
		}
		
		if (Input.GetButton("Jump Player "+playerString))
			Jump ();

		if (horizontalInputSpeed < -0.1)
			transform.rotation = Quaternion.Euler(0f,-90f,0f);
		else if (horizontalInputSpeed > 0.1)
			transform.rotation = Quaternion.Euler(0f,90f,0f);

		myRigidbody.AddForce(-Vector2.up * 50, ForceMode.Acceleration);

	}

	private void Jump ()
	{
		if (myCharacterController.onTheGround)
		{
			myCharacterController.onTheGround =false;
			myRigidbody.velocity = new Vector3(myRigidbody.velocity.x,0f,myRigidbody.velocity.z);
			myRigidbody.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
			audioSource.PlayOneShot (jumpSFX);

			if (jumped != null)
			{
				jumped();
			}
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
