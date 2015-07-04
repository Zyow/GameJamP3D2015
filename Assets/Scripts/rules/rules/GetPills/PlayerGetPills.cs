using UnityEngine;
using System.Collections;

public class PlayerGetPills : PlayerBase 
{
	public void GotIt ()
	{
		if (FindObjectOfType<RuleGetPills>())
			FindObjectOfType<RuleGetPills>().Done(playerNbr);
	}
}
