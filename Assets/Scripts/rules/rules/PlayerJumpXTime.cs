using UnityEngine;
using System.Collections;

public class PlayerJumpXTime : RuleGetPlayerNbr 
{
	private bool isUsed ;
	private int timeJumped;

	void Start ()
	{
		if ( FindObjectOfType<RuleJumpXTime>())
			isUsed = true;
		GetComponent<PlayerMove>().jumped += Jumping;
	}

	private void Jumping ()
	{
		timeJumped ++;
		if (isUsed == true && timeJumped >= 10 )
		{
			FindObjectOfType<RuleJumpXTime>().Done(playerNbr);

			PlayerJumpXTime[] players = FindObjectsOfType<PlayerJumpXTime>();
			foreach ( PlayerJumpXTime player in players)
			{
				player.GetComponent<PlayerJumpXTime>().Desactive();
			}
		}
	}

	public void Desactive ()
	{
		isUsed = false;
		GetComponent<PlayerMove>().jumped -= Jumping;
	}
}
