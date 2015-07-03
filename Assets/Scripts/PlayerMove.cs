using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	private Rigidbody rigidbody;
	private float speed;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
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
}
