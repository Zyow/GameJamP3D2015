using UnityEngine;
using System.Collections;
using System;

public class HitCollider : MonoBehaviour 
{
	public Action<string> enemyHited;

	private float ejectionForce = 3f;


	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player1" || col.tag == "Player2" || col.tag == "Player3" || col.tag == "Player4" )
		{
			print ("col");
			col.GetComponent<Rigidbody>().AddForce(Vector3.up * ejectionForce, ForceMode.Impulse);
			col.GetComponent<Rigidbody>().AddForce(Vector3.forward * ejectionForce*2f, ForceMode.Impulse);
			if(enemyHited != null)
				enemyHited(col.tag);
		}

	}
}
