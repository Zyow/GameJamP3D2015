using UnityEngine;
using System.Collections;

public class PlayerHit : PlayerBase 
{
	public GameObject attackPrefab;

	public Transform attackSpawnPointLeft;
	public Transform attackSpawnPointRight;
	public bool canAttack;

	private GameObject attack;
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
		if (canAttack)
		{
			canAttack = false;
			attack = Instantiate (attackPrefab) as GameObject;
			
			if (playerMove.isMovingToTheRight)
				attack.transform.SetParent (attackSpawnPointRight,false);
			else
				attack.transform.SetParent (attackSpawnPointLeft,false);
		}
	}

	public void CanAttackAgain ()
	{
		canAttack = true;
	}
}
