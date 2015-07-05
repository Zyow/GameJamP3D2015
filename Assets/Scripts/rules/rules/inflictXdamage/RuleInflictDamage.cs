using UnityEngine;
using System.Collections;

public class RuleInflictDamage : RuleBase 
{
	public Transform PuchingBallPrefab;
	
	void Awake()
	{
		Instantiate(PuchingBallPrefab);
	}
	
	public void Done(int player)
	{
		Finished(player);
	}
}
