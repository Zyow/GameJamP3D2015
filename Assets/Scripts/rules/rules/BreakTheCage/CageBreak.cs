using UnityEngine;
using System.Collections;

public class CageBreak : MonoBehaviour 
{
	private bool isUsed ;
	
	void Start ()
	{
		if ( FindObjectOfType<RuleBreakCage>())
			isUsed = true;
		
	}
	
	public void Breaking(string player)
	{
		if (isUsed)
		{
			int playerNbr = 0;
			switch (player)
			{
			case "Player1" :
				playerNbr = 1;
				break;
			case "Player2" :
				playerNbr = 2;
				break;
			case "Player3" :
				playerNbr = 3;
				break;
			case "Player4" :
				playerNbr = 4;
				break;
			}
			FindObjectOfType<RuleBreakCage>().Done(playerNbr);		
			isUsed = false;
		}
	}
}
