using UnityEngine;
using System.Collections;

public class RuleItemBreak : RuleBase 
{
	public void Done(int player)
	{
		Finished(player);
	}
}
