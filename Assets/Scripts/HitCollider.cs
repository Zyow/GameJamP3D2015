using UnityEngine;
using System.Collections;
using System;

public class HitCollider : MonoBehaviour 
{
	public Action<string> enemyHited;

	private float ejectionForce = 8f;


	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player1" || col.tag == "Player2" || col.tag == "Player3" || col.tag == "Player4" )
		{
//			print ("col");
			col.GetComponent<Rigidbody>().AddForce(Vector3.up * ejectionForce, ForceMode.Impulse);
			col.GetComponent<Rigidbody>().AddForce(transform.forward * ejectionForce*2f, ForceMode.Impulse);
			col.GetComponent<PlayerMove>().Pushed();
			if(enemyHited != null)
				enemyHited(col.tag);
		}

		if (col.tag == "Cage")
		{
			col.GetComponent<Cage>().TakeHit();
		}
	}
}
