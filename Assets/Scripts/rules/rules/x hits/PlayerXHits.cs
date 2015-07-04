using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerXHits : PlayerBase 
{
	public int timeHitedObjectif;
	public HitCollider hitCollider;
	private bool isUsed;
	private int currentXTimesHit;
	private Dictionary<string,int> playerTouch = new Dictionary<string, int>();
	
	void Start ()
	{
		if (FindObjectOfType<RuleXHits>())
			isUsed = true;
		hitCollider.enemyHited += HitGived;

		playerTouch.Add("Player1",0);
		playerTouch.Add("Player2",0);
		playerTouch.Add("Player3",0);
		playerTouch.Add("Player4",0);
	}

	private void HitGived (string target)
	{
		print (target);
		print(playerTouch[target]);

		if (isUsed)
		{
			playerTouch[target] ++;
			if (playerTouch[target] >= timeHitedObjectif)
			{
				FindObjectOfType<RuleXHits>().Done(playerNbr);
				
				PlayerXHits[] players = FindObjectsOfType<PlayerXHits>();
				foreach ( PlayerXHits player in players)
				{
					player.GetComponent<PlayerXHits>().Desactive();
				}
			}
		}
	}

	public void Desactive ()
	{
		isUsed = false;
		//GetComponent<HitCollider>().hitGiver -= HitGiver;
	}
}
