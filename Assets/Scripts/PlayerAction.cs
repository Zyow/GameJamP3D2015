using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour 
{
	private int playerNbr;

	void Awake()
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

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Collectable" && Input.GetButtonDown("Action Player "+playerNbr.ToString()))
			other.GetComponent<Collectables>().Collected();
	}
}
