using UnityEngine;
using System.Collections;

public class PlayerAction : PlayerBase 
{
	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Collectable" && Input.GetButtonDown("Action Player "+playerNbr.ToString()))
			other.GetComponent<Collectables>().Collected();
	}
}
