using UnityEngine;
using System.Collections;

public class RuleGetCrown : RuleBase 
{
	public Transform crownPrefab;
	
	void Awake()
	{
		Instantiate(crownPrefab);
	}
	
	public void Done(int player)
	{
		Finished(player);
	}
}
