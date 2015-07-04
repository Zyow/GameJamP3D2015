using UnityEngine;
using System.Collections;

public class PlayerHit : PlayerBase 
{
	void Update ()
	{
		if (Input.GetButtonDown ("Hit Player "+ playerNbr.ToString ()))
			Attack ();
	}

	private void Attack ()
	{
		print ("attack");
	}
}
