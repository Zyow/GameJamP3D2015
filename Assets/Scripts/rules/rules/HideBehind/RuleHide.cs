using UnityEngine;
using System.Collections;

public class RuleHide : RuleBase 
{
	public Transform hidingPrefab;

	void Awake()
	{
		Instantiate(hidingPrefab);
	}

	public void Done(int player)
	{
		Finished(player);
	}
}
