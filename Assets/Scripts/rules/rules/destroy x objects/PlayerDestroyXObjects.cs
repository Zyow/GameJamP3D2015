using UnityEngine;
using System.Collections;

public class PlayerDestroyXObjects : PlayerBase 
{
	public int maxDestroyedObjects;

	private bool isUsed;
	private int currentDestroyedObjects;
	
	void Start ()
	{
		if (FindObjectOfType<PlayerDestroyXObjects>())
			isUsed = true;
		//GetComponent<PlayerHit>().destroy += Destroy;
	}

	private void Destroy ()
	{
		currentDestroyedObjects ++;
		if (isUsed == true && currentDestroyedObjects >= maxDestroyedObjects)
		{
			FindObjectOfType<RuleDestroyXObjects>().Done(playerNbr);
			
			PlayerDestroyXObjects[] players = FindObjectsOfType<PlayerDestroyXObjects>();
			foreach ( PlayerDestroyXObjects player in players)
			{
				player.GetComponent<PlayerDestroyXObjects>().Desactive();
			}
		}
	}

	public void Desactive ()
	{
		isUsed = false;
		//GetComponent<PlayerHit>().destroy -= Destroy;
	}
}
