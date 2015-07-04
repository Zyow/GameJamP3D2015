using UnityEngine;
using System.Collections;

public class PlayerGetPills : PlayerBase 
{
	public void GotIt ()
	{
		FindObjectOfType<RuleGetPills>().Done(playerNbr);
	}
}
