using UnityEngine;
using System.Collections;

public class PlayerPassByPortals : PlayerBase 
{
	public int portalToPass;
	private int portalNbr;
	private bool isUsed ;

	void Start ()
	{
		if ( FindObjectOfType<RulePassByPortals>())
			isUsed = true;

	}

	public void PassedPortal()
	{
		if (isUsed)
		{
			portalNbr ++;

			if (portalNbr >= portalToPass)
			{
				FindObjectOfType<RulePassByPortals>().Done(playerNbr);
				
				PlayerPassByPortals[] players = FindObjectsOfType<PlayerPassByPortals>();
				foreach ( PlayerPassByPortals player in players)
				{
					player.GetComponent<PlayerPassByPortals>().Desactive();
				}
			}
			
		}
	}

	public void Desactive()
	{
		isUsed = false;
	}
}
