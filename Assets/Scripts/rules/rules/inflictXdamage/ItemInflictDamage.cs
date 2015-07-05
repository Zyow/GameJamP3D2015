using UnityEngine;
using System.Collections.Generic;

public class ItemInflictDamage : MonoBehaviour 
{
	private Dictionary<string,int> playerDamage = new Dictionary<string, int>();
	public int damageObjectif;
	private int playerNbr;
	private bool done;

	void Awake()
	{
		for ( int i = 1; i < 5;i++)
		{
			playerDamage.Add("Player"+i.ToString(),0);
		}
	}

	public void Damaged(string player)
	{
		if (!done)
		{
			playerDamage[player]++;
			
			if (playerDamage[player] >= damageObjectif )
			{
				switch (player)
				{
				case "Player1" :
					playerNbr = 1;
					break;
				case "Player2" :
					playerNbr = 2;
					break;
				case "Player3" :
					playerNbr = 3;
					break;
				case "Player4" :
					playerNbr = 4;
					break;
				}
				FindObjectOfType<RuleInflictDamage>().Done(playerNbr);	
				done = true;
			}
		}
	}
}
