using UnityEngine;
using System.Collections;

public class RuleItemBreak : RuleBase 
{
	public Transform prefab;

	void Awake()
	{
		Instantiate(prefab);
	}

	public void Done(int player)
	{
		Finished(player);
	}
}
