using UnityEngine;
using System.Collections;

public class PlayerTravel : PlayerBase 
{
	private bool isUsed;
	private float distance;
	public float distanceMax;
	
	void Start ()
	{
		if (FindObjectOfType<RuleTravel>())
			isUsed = true;
	}
	
	public void FixedUpdate ()
	{
		if (isUsed == true)
		{
			distance += Mathf.Abs((GetComponent<Rigidbody>().velocity.x)/100f);
			if (distance >= distanceMax)
			{
				FindObjectOfType<RuleTravel>().Done(playerNbr);
				
				PlayerTravel[] players = FindObjectsOfType<PlayerTravel>();
				foreach ( PlayerTravel player in players)
				{
					player.GetComponent<PlayerTravel>().Desactive();
				}
			}
		}
	}
	
	public void Desactive ()
	{
		isUsed = false;
	}
}
