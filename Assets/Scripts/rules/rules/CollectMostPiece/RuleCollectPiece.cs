using UnityEngine;
using System.Collections.Generic;

public class RuleCollectPiece : RuleBase 
{
	private Dictionary<int,int> playerScore = new Dictionary<int,int>();
	private int bestscore;
	private int bestPlayer2;
	private int bestPlayer;
	public Transform piecesPrefabs;
	private Transform prefabs;

	void Awake()
	{
		prefabs = Instantiate(piecesPrefabs);

		for (int i = 1; i < 5 ; i++ )
		{
			playerScore.Add(i,0);
		}

		Invoke("End",15f);
	}

	public void ChangeScore(int player)
	{
		playerScore[player] ++;
	}

	public void End()
	{
		bestPlayer = 1;
		bestscore = 0;
		for (int j = 0; j < playerScore.Count; j++)
		{
			if ( bestscore < playerScore[j])
			{
				bestscore = playerScore[j];
				bestPlayer = j + 1;
				bestPlayer2 = 0;
			}

			else if (bestscore == playerScore[j])
			{
				bestPlayer2 = j+1;
			}
		}

		prefabs.GetComponent<CleanMap>().Called();

		Finished(bestPlayer);

		if (bestPlayer2 != 0)
			Finished(bestPlayer2);
	}
}
