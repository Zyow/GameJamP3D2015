using UnityEngine;
using System.Collections;

public class PlayerSuicideYourself : PlayerBase 
{
	private bool isUsed;

	void Start ()
	{
		if (FindObjectOfType<RuleSuicideYourself>())
			isUsed = true;
	}
	
	public void Death ()
	{
		if (isUsed == true)
		{
			FindObjectOfType<RuleSuicideYourself>().Done(playerNbr);
			
			PlayerSuicideYourself[] players = FindObjectsOfType<PlayerSuicideYourself>();
			foreach ( PlayerSuicideYourself player in players)
			{
				player.GetComponent<PlayerSuicideYourself>().Desactive();
			}
		}
	}
	
	public void Desactive ()
	{
		isUsed = false;
	}
}
