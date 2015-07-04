using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour 
{
	private Vector3 offset = new Vector3(0f,-1f,0f);
	public bool onTheGround;
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit downHit;
		if (Physics.Raycast(transform.position, -Vector3.up, out downHit, 1.4f))
		{		
			onTheGround = true;	
		}
		else
			onTheGround = false;
	}

	public bool OnTheGround {
		get {
			return this.onTheGround;
		}
	}
}
