using UnityEngine;
using System.Collections;

public class PlayerCollectPiece : PlayerBase 
{
	public void GotIt ()
	{
		if (FindObjectOfType<RuleCollectPiece>())
			FindObjectOfType<RuleCollectPiece>().ChangeScore(playerNbr);
	}
}
