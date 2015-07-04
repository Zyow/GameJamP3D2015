using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour 
{
	private Vector3 offset = new Vector3(0f,-1f,0f);
	public bool onTheGround;
	private bool frontObject;
	
	void Update () 
	{
		RaycastHit downHit;
		if (Physics.Raycast(transform.position, -Vector3.up, out downHit, 1.4f))
		{		
			onTheGround = true;	
		}
		else
			onTheGround = false;

		RaycastHit frontHit;
		if (Physics.SphereCast(transform.position, 0.5f, Vector3.forward, out frontHit, 0.75f))
		{
			frontObject = true;
		}
		else
			frontObject = false;

	}

	public bool OnTheGround {
		get {
			return this.onTheGround;
		}
	}
}
