using UnityEngine;
using System.Collections;

public class PlayerHit : PlayerBase 
{
	public GameObject attack;
	public Transform attackSpawnPointLeft;
	public Transform attackSpawnPointRight;
	private PlayerMove playerMove;

	void Start ()
	{
		playerMove = GetComponent<PlayerMove>();
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Hit Player "+ playerNbr.ToString ()))
			Attack ();
	}

	private void Attack ()
	{
		print ("attack");
		if (playerMove.isMovingToTheRight)
			Instantiate (attack, attackSpawnPointRight.transform.position, attackSpawnPointRight.transform.rotation);
		else
			Instantiate (attack, attackSpawnPointLeft.transform.position, attackSpawnPointLeft.transform.rotation);
	}
}
