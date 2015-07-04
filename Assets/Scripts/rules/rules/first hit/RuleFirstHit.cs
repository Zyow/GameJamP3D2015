using UnityEngine;
using System.Collections;

public class RuleFirstHit : RuleBase 
{
	public void Done(int player)
	{
		Finished(player);
	}
}
