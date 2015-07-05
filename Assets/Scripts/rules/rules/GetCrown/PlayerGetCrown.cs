using UnityEngine;
using System.Collections;

public class PlayerGetCrown : PlayerBase 
{
	public void GotIt ()
	{
		if (FindObjectOfType<RuleGetCrown>())
			FindObjectOfType<RuleGetCrown>().Done(playerNbr);
	}
}
