using UnityEngine;
using System.Collections;

public class PlayerJumpXTimeOnBed : PlayerBase 
{
	private bool isUsed;
	private int timeJumped;

	void Start ()
	{
		if (FindObjectOfType<RuleJumpXTime>())
			isUsed = true;
		//GetComponent<PlayerMove>().jumpedOnBed += JumpingOnBed;
	}
	
	private void JumpingOnBed ()
	{
		timeJumped ++;
		if (isUsed == true && timeJumped >= 10)
		{
			FindObjectOfType<RuleJumpXTime>().Done(playerNbr);
			
			PlayerJumpXTimeOnBed[] players = FindObjectsOfType<PlayerJumpXTimeOnBed>();
			foreach ( PlayerJumpXTimeOnBed player in players)
			{
				player.GetComponent<PlayerJumpXTimeOnBed>().Desactive();
			}
		}
	}
	
	public void Desactive ()
	{
		isUsed = false;
		//GetComponent<PlayerMove>().jumpedOnBed -= JumpingOnBed;
	}
}
