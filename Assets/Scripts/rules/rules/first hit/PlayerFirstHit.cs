using UnityEngine;
using System.Collections;

public class PlayerFirstHit : PlayerBase 
{
	private bool isUsed;
	private int timeHit;
	
	void Start ()
	{
		if (FindObjectOfType<RuleFirstHit>())
			isUsed = true;
		//GetComponent<PlayerHit>().hit += Hit;
	}

	private void Hit ()
	{
		timeHit ++;
		if (isUsed == true && timeHit >= 1)
		{
			FindObjectOfType<RuleFirstHit>().Done(playerNbr);
			
			PlayerFirstHit[] players = FindObjectsOfType<PlayerFirstHit>();
			foreach ( PlayerFirstHit player in players)
			{
				player.GetComponent<PlayerFirstHit>().Desactive();
			}
		}

	}

	public void Desactive ()
	{
		isUsed = false;
		//GetComponent<PlayerMove>().hit -= Hit;
	}
}
