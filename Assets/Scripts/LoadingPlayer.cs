using UnityEngine;
using System.Collections;

public class LoadingPlayer : MonoBehaviour 
{
	public bool playerOneActive;
	public bool playerTwoActive;
	public bool playerTreeActive;
	public bool playerFourActive;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	public void ActivePlayer()
	{
		if (playerOneActive)
		{
			//print ("Active Joueur 1");
			//GameObject.FindGameObjectWithTag("Player1").SetActive(true);
			Object playerOne = Resources.Load("Player 1");
			if(GameObject.FindGameObjectWithTag("Player1")==null)
			{
				Instantiate(playerOne);
			}
		}
		if (playerTwoActive)
		{
			//print ("Active Joueur 2");
			Object playerTwo = Resources.Load("Player 2");
			if(GameObject.FindGameObjectWithTag("Player2")==null)
			{
				Instantiate(playerTwo);
			}
		}
		if (playerTreeActive)
		{
			//print ("Active Joueur 3");
			Object playerTree = Resources.Load("Player 3");
			if(GameObject.FindGameObjectWithTag("Player3")==null)
			{
				Instantiate(playerTree);
			}
		}
		if (playerFourActive)
		{
			//print ("Active Joueur 4");
			Object playerFour = Resources.Load("Player 4");
			if(GameObject.FindGameObjectWithTag("Player4")==null)
			{
				Instantiate(playerFour);
			}
		}
	}

}
