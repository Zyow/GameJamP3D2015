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
			//GameObject.FindGameObjectWithTag("Player1").SetActive(true);
			Object playerOne = Resources.Load("PlayerFake");
			if(GameObject.FindGameObjectWithTag("Player1")==null)
			{
				Instantiate(playerOne);
			}
		}
		if (playerTwoActive)
		{
			Object playerTwo = Resources.Load("Player2");
			if(GameObject.FindGameObjectWithTag("Player2")==null)
			{
				Instantiate(playerTwo);
			}
		}
		if (playerTreeActive)
		{
			Object playerTree = Resources.Load("Player3");
			if(GameObject.FindGameObjectWithTag("Player3")==null)
			{
				Instantiate(playerTree);
			}
		}
		if (playerFourActive)
		{
			Object playerFour = Resources.Load("Player4");
			if(GameObject.FindGameObjectWithTag("Player4")==null)
			{
				Instantiate(playerFour);
			}
		}
	}

}
