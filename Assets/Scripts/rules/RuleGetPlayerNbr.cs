using UnityEngine;
using System.Collections;

public class RuleGetPlayerNbr : MonoBehaviour 
{
	protected int playerNbr;
	void Start ()
	{
		switch (gameObject.tag)
		{
		case "Player1":
			playerNbr = 1;
			break;
		case "Player2":
			playerNbr = 2;
			break;
		case "Player3":			
			playerNbr = 3;
			break;
		case "Player4":
			playerNbr = 4;
			break;
		}
	}
}
