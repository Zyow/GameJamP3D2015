using UnityEngine;
using System.Collections;

public class PlayerHit : PlayerBase 
{
	public GameObject attackPrefab;

	public Transform attackSpawnPointLeft;
	public Transform attackSpawnPointRight;
	private bool canAttack = true;
	
	private PlayerMove playerMove;

	protected override void Awake ()
	{
		base.Awake();
		playerMove = GetComponent<PlayerMove>();
		attackPrefab.SetActive(false);
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Hit Player "+playerString))
			StartCoroutine(Attack ());
	}

	private IEnumerator Attack ()
	{
		if (canAttack)
		{
			canAttack = false;
			attackPrefab.SetActive(true);
			
//			if (playerMove.isMovingToTheRight)
//				attack.transform.SetParent (attackSpawnPointRight,false);
//			else
//				attack.transform.SetParent (attackSpawnPointLeft,false);
		}
		yield return new WaitForSeconds(0.2f);
		attackPrefab.SetActive(false);
		canAttack = true;
		
	}
}
