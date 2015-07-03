using UnityEngine;
using System;
using System.Collections;

public class RuleBase : MonoBehaviour 
{
	private int winner;
	public Action<int> winnerUI;
	public bool done;

	protected void Finished ( int player)
	{
		winner = player;
		if( winnerUI != null )
			winnerUI( winner );
	}
}
