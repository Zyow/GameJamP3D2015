using UnityEngine;
using System.Collections;

public class LoadingPlayer : MonoBehaviour 
{
	public bool playerOneActive;
	public bool playerTwoActive;
	public bool playerTreeActive;
	public bool playerFourActive;

	public GameObject player1Prefab;
	public GameObject player2Prefab;
	public GameObject player3Prefab;
	public GameObject player4Prefab;

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
				print ("Active Joueur 1");
				Instantiate(playerOne);

				//Instantiate (player1Prefab, transform.position, transform.rotation);
			}
		}
		if (playerTwoActive)
		{
			//print ("Active Joueur 2");
			Object playerTwo = Resources.Load("Player 2");
			if(GameObject.FindGameObjectWithTag("Player2")==null)
			{
				print ("Active Joueur 2");
				Instantiate(playerTwo);
				//Instantiate (player2Prefab, transform.position, transform.rotation);
			}
		}
		if (playerTreeActive)
		{
			//print ("Active Joueur 3");
			Object playerTree = Resources.Load("Player 3");
			if(GameObject.FindGameObjectWithTag("Player3")==null)
			{
				//Instantiate(playerTree);
				Instantiate (player3Prefab, transform.position, transform.rotation);
			}
		}
		if (playerFourActive)
		{
			//print ("Active Joueur 4");
			Object playerFour = Resources.Load("Player 4");
			if(GameObject.FindGameObjectWithTag("Player4")==null)
			{
				//Instantiate(playerFour);
				Instantiate (player4Prefab, transform.position, transform.rotation);
			}
		}
	}

}
