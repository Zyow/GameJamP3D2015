using UnityEngine;
using System.Collections;

public class PlayerGetCrown : PlayerBase 
{
	public void GotIt ()
	{
		if (FindObjectOfType<RuleGetPills>())
			FindObjectOfType<RuleGetPills>().Done(playerNbr);
	}
}
