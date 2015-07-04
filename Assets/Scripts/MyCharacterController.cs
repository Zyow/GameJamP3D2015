using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour 
{
	private Vector3 offset = new Vector3(0f,-1f,0f);
	private bool onTheGround;
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit downHit;
		if (Physics.Raycast(transform.position + offset, -Vector3.up, out downHit, 0.4f))
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
