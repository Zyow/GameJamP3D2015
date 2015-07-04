using UnityEngine;
using System.Collections;

public class PlayerXHits : PlayerBase 
{
	public int maxXTimesHit;
	private bool isUsed;
	private int currentXTimesHit;
	
	void Start ()
	{
		if (FindObjectOfType<RuleXHits>())
			isUsed = true;
		//GetComponent<HitCollider>().hitGiver += HitGiver;
	}

	private void HitGiver ()
	{
		currentXTimesHit ++;
		if (isUsed == true && currentXTimesHit >= maxXTimesHit)
		{
			FindObjectOfType<RuleXHits>().Done(playerNbr);
			
			PlayerXHits[] players = FindObjectsOfType<PlayerXHits>();
			foreach ( PlayerXHits player in players)
			{
				player.GetComponent<PlayerXHits>().Desactive();
			}
		}
	}

	public void Desactive ()
	{
		isUsed = false;
		//GetComponent<HitCollider>().hitGiver -= HitGiver;
	}
}
