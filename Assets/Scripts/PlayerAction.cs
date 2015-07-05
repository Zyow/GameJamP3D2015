using UnityEngine;
using System.Collections;

public class PlayerAction : PlayerBase 
{
	public AudioClip collectableSFX;

	void OnTriggerStay (Collider other)
	{
		if (other.GetComponent<Collectables>() && Input.GetButtonDown("Action Player "+ playerString))
		{
			other.GetComponent<Collectables>().Collected();
			 if (other.tag == "Pills")
			{
				if (GetComponent<PlayerGetPills>())
					GetComponent<PlayerGetPills>().GotIt();
				audioSource.PlayOneShot (collectableSFX);
			}
		}
	}

	void Update ()
	{
		if (Input.GetButtonDown("Taunt Player "+ playerString))
		{
			print ("launch anim dance " + playerString);
		}
	}
}
