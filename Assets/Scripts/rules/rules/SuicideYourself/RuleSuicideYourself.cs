using UnityEngine;
using System.Collections;

public class RuleSuicideYourself : RuleBase 
{
	
	public void Done(int player)
	{
		Finished(player);
	}
}
