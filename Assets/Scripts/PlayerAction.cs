using UnityEngine;
using System.Collections;

public class PlayerAction : PlayerBase 
{
	public AudioClip collectableSFX;

	void OnTriggerStay (Collider other)
	{
		if (other.GetComponent<Collectables>() && Input.GetButtonDown("Action Player "+playerNbr.ToString()))
		{
			other.GetComponent<Collectables>().Collected();
			 if (other.tag == "Pills")
			{
//				GetComponent<PlayerGetPills>().GotIt();
				audioSource.PlayOneShot (collectableSFX);
			}
		}
	}
}
