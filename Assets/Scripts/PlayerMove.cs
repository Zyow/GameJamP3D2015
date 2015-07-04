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

	private bool canMove = true;

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
			
		myRigidbody.AddForce(-Vector3.up * 50, ForceMode.Acceleration);

		RaycastHit hit;
		
////		if (Physics.SphereCast(transform.position, 0.1f, transform.forward, out hit, 1f))
//		if (Physics.Raycast(transform.position, transform.forward * 10f, out hit) &&
//		    (Physics.Raycast(transform.position, transform.forward * 10f, out hit) &&
//		 	(Physics.Raycast(transform.position, transform.forward * 10f, out hit)
//			)))
		if (!myCharacterController.onTheGround)
		{
			if (( Physics.Raycast (GetComponent<Collider>().bounds.center, transform.forward, out hit, 0.6f)) || 
			    ( Physics.Raycast (GetComponent<Collider>().bounds.center + new Vector3( 0f , GetComponent<Collider>().bounds.extents.y, 0f), transform.forward, out hit, 0.6f)) || 
			    ( Physics.Raycast (GetComponent<Collider>().bounds.center - new Vector3( 0f , GetComponent<Collider>().bounds.extents.y, 0f), transform.forward, out hit, 0.6f)))
			{
				Debug.DrawLine(transform.position, hit.point, Color.red);
				print (hit.collider.gameObject);
				myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, myRigidbody.velocity.z);
				//			myRigidbody.AddForce(-transform.forward * 5f, ForceMode.Impulse);
				canMove = false;
			}
			else
			{
				canMove = true;
			}
		}
		
	
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
