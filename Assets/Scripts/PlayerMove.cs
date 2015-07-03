using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	private Rigidbody rigidbody;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		print (Input.GetAxis("Horizontal Player 1"));
		rigidbody.AddForce (Vector3.forward * Input.GetAxis("Horizontal Player 1"));
	}
}
