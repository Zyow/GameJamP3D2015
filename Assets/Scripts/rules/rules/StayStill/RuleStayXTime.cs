using UnityEngine;
using System.Collections;

public class RuleStayXTime : RuleBase 
{
	public void Done(int player)
	{
		Finished(player);
	}
}
