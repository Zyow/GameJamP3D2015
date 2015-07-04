using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour 
{
	protected int playerNbr;

	protected virtual void Awake ()
	{
		switch (tag)
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
	}
}
