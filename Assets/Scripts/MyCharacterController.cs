using UnityEngine;
using System;
using System.Collections;

public class MyCharacterController : MonoBehaviour 
{
	private Vector3 offset = new Vector3(0f,-1f,0f);
	public bool onTheGround;
	private bool frontObject;
	public Action<string> hitTag;
	
	void Update () 
	{
		RaycastHit downHit;
		if (Physics.Raycast(GetComponent<Collider>().bounds.center, -Vector3.up, out downHit, 1.4f) ||
		    ( Physics.Raycast (GetComponent<Collider>().bounds.center + new Vector3( 0f , GetComponent<Collider>().bounds.extents.x/2, 0f), -Vector3.up, out downHit, 1.4f)) || 
		    ( Physics.Raycast (GetComponent<Collider>().bounds.center - new Vector3( 0f , GetComponent<Collider>().bounds.extents.x/2, 0f), -Vector3.up, out downHit, 1.4f)))
		{		
			Debug.DrawLine(transform.position, downHit.point, Color.red);
			onTheGround = true;	
			if (hitTag != null)
				hitTag(downHit.transform.tag);
		}
		else
		{
			onTheGround = false;
			if (hitTag != null)
				hitTag(null);
		}

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
