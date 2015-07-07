using UnityEngine;
using System.Collections;

public class LoadingPlayer : MonoBehaviour 
{
	public bool playerOneActive;
	public bool playerTwoActive;
	public bool playerTreeActive;
	public bool playerFourActive;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		ActivePlayer();
	}

	public void ActivePlayer()
	{
		print ("reset player");
		player1.SetActive (false);
		player2.SetActive (false);
		player3.SetActive (false);
		player4.SetActive (false);

		if (PlayerPrefs.GetInt ("Player 1", 0) == 1)
		{
			print ("player 1");
			player1.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("Player 2", 0) == 1)
		{
			print ("player 2");
			player2.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("Player 3", 0) == 1)
		{
			print ("player 3");
			player3.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("Player 4", 0) == 1)
		{
			print ("player 4");
			player4.SetActive (true);
		}

		/*if (playerOneActive)
		{
			//print ("Active Joueur 1");
			//GameObject.FindGameObjectWithTag("Player1").SetActive(true);
			Object playerOne = Resources.Load("Player 1");
			if(GameObject.FindGameObjectWithTag("Player1")==null)
			{
				print ("player 1");
				//Instantiate(playerOne);
				player1.SetActive (true);
				//Instantiate (player1Prefab, transform.position, transform.rotation);
			}
		}
		if (playerTwoActive)
		{
			//print ("Active Joueur 2");
			Object playerTwo = Resources.Load("Player 2");
			if(GameObject.FindGameObjectWithTag("Player2")==null)
			{
				print ("player 2");
				//Instantiate(playerTwo);
				player2.SetActive (true);
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
				print ("player 3");
				player3.SetActive (true);
				//Instantiate (player3Prefab, transform.position, transform.rotation);
			}
		}
		if (playerFourActive)
		{
			//print ("Active Joueur 4");
			Object playerFour = Resources.Load("Player 4");
			if(GameObject.FindGameObjectWithTag("Player4")==null)
			{
				//Instantiate(playerFour);
				print ("player 4");
				player4.SetActive (true);
				//Instantiate (player4Prefab, transform.position, transform.rotation);
			}
		}*/
	}

}
