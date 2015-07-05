using UnityEngine;
using System.Collections;

public class RuleGetPills : RuleBase 
{
	public Transform pillsPrefab;

	void Awake()
	{
		Instantiate(pillsPrefab);
	}

	public void Done(int player)
	{
		Finished(player);
	}
}
