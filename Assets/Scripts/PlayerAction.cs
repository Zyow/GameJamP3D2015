using UnityEngine;
using System.Collections;

public class PlayerAction : PlayerBase 
{
	public AudioClip collectableSFX;
	private Animator anim;

	void Awake()
	{
		base.Awake();
		anim = GetComponentInChildren<Animator>();
	}

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

			if (other.tag == "Crown")
			{
				if (GetComponent<PlayerGetCrown>())
					GetComponent<PlayerGetCrown>().GotIt();
				audioSource.PlayOneShot (collectableSFX);
			}

			if (other.tag == "Piece")
			{
				if (GetComponent<PlayerCollectPiece>())
					GetComponent<PlayerCollectPiece>().GotIt();
				audioSource.PlayOneShot (collectableSFX);
			}
		}
	}

	void Update ()
	{
		if (Input.GetButtonDown("Taunt Player "+ playerString))
		{
			anim.SetTrigger("Dance"+playerString);
		}
	}
}
