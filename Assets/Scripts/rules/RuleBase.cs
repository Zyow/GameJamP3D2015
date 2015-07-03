using UnityEngine;
using System;
using System.Collections;

public class RuleBase : MonoBehaviour 
{
	private int winner;
	public Action<int> winnerUI;
	public bool done;

	/// <summary>
	/// Signaler si l'achievement est fini.
	/// </summary>
	/// <param name="player">numero du player.</param>
	protected void Finished ( int player)
	{
		winner = player;
		if( winnerUI != null )
			winnerUI( winner );
	}
}
