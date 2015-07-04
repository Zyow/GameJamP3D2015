using UnityEngine;
using System.Collections;

public class PlayerJumpXTimeOnBed : PlayerBase 
{
	private bool isUsed;
	private int timeJumped;
	private string floorTag;
	public int jumpNbr;

	void Start ()
	{
		if (FindObjectOfType<RuleJumpXTimeOnBed>())
			isUsed = true;
		GetComponent<PlayerMove>().jumped += Jumping;
		GetComponent<MyCharacterController>().hitTag += ChangeTag;
	}
	
	private void Jumping ()
	{
		if(isUsed && floorTag == "Bed")
		{
			timeJumped ++;
			if (timeJumped >= jumpNbr)
			{
				FindObjectOfType<RuleJumpXTimeOnBed>().Done(playerNbr);
				
				PlayerJumpXTimeOnBed[] players = FindObjectsOfType<PlayerJumpXTimeOnBed>();
				foreach ( PlayerJumpXTimeOnBed player in players)
				{
					player.GetComponent<PlayerJumpXTimeOnBed>().Desactive();
				}
			}
		}
	}

	private void ChangeTag(string tag)
	{
		floorTag = tag;
	}
	
	public void Desactive ()
	{
		isUsed = false;
		//GetComponent<PlayerMove>().jumpedOnBed -= JumpingOnBed;
	}
}
