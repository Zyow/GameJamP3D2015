using UnityEngine;
using System.Collections;
using System;

public class HitCollider : MonoBehaviour 
{
	public Action<string> enemyHited;

	private float ejectionForce = 4f;


	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.tag == "Player1" || col.tag == "Player2" || col.tag == "Player3" || col.tag == "Player4" )
		{
//			print ("col");
			col.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.up * ejectionForce, ForceMode2D.Impulse);
			col.GetComponentInParent<Rigidbody2D>().AddForce(transform.forward * ejectionForce*2f, ForceMode2D.Impulse);
			col.GetComponentInParent<PlayerMove>().Pushed();

			if(enemyHited != null)
				enemyHited(col.tag);
		}

		if (col.tag == "Damageable")
		{
			if (col.GetComponentInParent<Cage>())
				col.GetComponentInParent<Cage>().TakeHit(transform.parent.tag);

			if (col.GetComponent<BrokenableItem>())
				col.GetComponent<BrokenableItem>().Damaged(transform.parent.tag);

			if (col.GetComponent<ItemInflictDamage>())
				col.GetComponent<ItemInflictDamage>().Damaged(transform.parent.tag);
		}

		if (col.tag != "Decors")
		{
			if (transform.parent.tag == "Player1")
				Instantiate (Resources.Load("ParticleHitFliquette") as GameObject, col.transform.position, Quaternion.identity);

			if (transform.parent.tag == "Player2")
				Instantiate (Resources.Load("ParticleHitPyro") as GameObject, col.transform.position, Quaternion.identity);

			if (transform.parent.tag == "Player3")
				Instantiate (Resources.Load("ParticleHitDiablotin") as GameObject, col.transform.position, Quaternion.identity);

			if (transform.parent.tag == "Player4")
				Instantiate (Resources.Load("ParticleHitElBourito") as GameObject, col.transform.position, Quaternion.identity);

		}

	}
}
