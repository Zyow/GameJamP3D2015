using UnityEngine;
using System.Collections;

public class PlayerHit : PlayerBase 
{
	public GameObject attackPrefab;
	
	private bool canAttack = true;
	
	private PlayerMove playerMove;

	private Animator anim;

	private bool canHit = false;

	protected override void Awake ()
	{
		base.Awake();
		playerMove = GetComponent<PlayerMove>();
		attackPrefab.SetActive(false);
		if(GetComponentInChildren<Animator>() != null)
			anim = GetComponentInChildren<Animator>();
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Hit Player "+playerString))
			StartCoroutine(Attack ());
	}

	private IEnumerator Attack ()
	{
		if(canHit)
		{
			if (canAttack)
			{
				canAttack = false;
				attackPrefab.SetActive(true);
				if (anim != null)
					anim.SetTrigger("Hit");
			}
			yield return new WaitForSeconds(0.2f);
			attackPrefab.SetActive(false);
			canAttack = true;
		}
		
	}

	public void AllowHit()
	{
		canHit = true;
	}
}
