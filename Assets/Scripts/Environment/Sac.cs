using UnityEngine;
using System.Collections;

public class Sac : MonoBehaviour {

	private float ejectionForce = 4f;

	
	void OnCollisionEnter2D(Collision2D col)
	{

		print (col);
		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4" )
		{
			//			print ("col");
			col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.up * ejectionForce, ForceMode2D.Impulse);
			col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(transform.forward * ejectionForce * 2f, ForceMode2D.Impulse);
			col.gameObject.GetComponentInParent<PlayerMove>().Pushed();
		}
	}
}
