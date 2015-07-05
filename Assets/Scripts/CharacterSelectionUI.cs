using UnityEngine;
using System.Collections;

public class CharacterSelectionUI : MonoBehaviour 
{
	//public GameObject loadingPlayerPrefab;
	public GameObject canLaunchGameUI;
	public GameObject cantLaunchGameUI;

	public int numberActivePlayers;
	private bool canLaunchGame;
	private LoadingPlayer loadingPlayer;

	public GameObject textPlayer1Join;
	public GameObject textPlayer2Join;
	public GameObject textPlayer3Join;
	public GameObject textPlayer4Join;

	public GameObject textPlayer1Joined;
	public GameObject textPlayer2Joined;
	public GameObject textPlayer3Joined;
	public GameObject textPlayer4Joined;

	public int minPlayersNeed;

	void Start ()
	{
		//Instantiate (loadingPlayerPrefab);
		//loadingPlayer = loadingPlayerPrefab.GetComponent<LoadingPlayer>();
		loadingPlayer = FindObjectOfType<LoadingPlayer>();
		cantLaunchGameUI.SetActive (true);
		canLaunchGameUI.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Jump Player 1"))
			ActivePlayer1 ();

		if (Input.GetButtonDown ("Jump Player 2"))
			ActivePlayer2 ();

		if (Input.GetButtonDown ("Jump Player 3"))
			ActivePlayer3 ();

		if (Input.GetButtonDown ("Jump Player 4"))
			ActivePlayer4 ();

		if (Input.GetButtonDown ("Hit Player 1"))
			DesactivePlayer1 ();
		
		if (Input.GetButtonDown ("Hit Player 2"))
			DesactivePlayer2 ();
		
		if (Input.GetButtonDown ("Hit Player 3"))
			DesactivePlayer3 ();
		
		if (Input.GetButtonDown ("Hit Player 4"))
			DesactivePlayer4 ();

		if (Input.GetButtonDown ("Pause") && canLaunchGame)
		{
			Application.LoadLevel("SceneDef");
			//loadingPlayer.ActivePlayer ();
		}
	}

	private void CheckNumberPlayers ()
	{
		if (numberActivePlayers >= minPlayersNeed)
		{
			canLaunchGame = true;
			cantLaunchGameUI.SetActive (false);
			canLaunchGameUI.SetActive (true);
		}
		else
		{
			canLaunchGame = false;
			cantLaunchGameUI.SetActive (true);
			canLaunchGameUI.SetActive (false);
		}
	}

	public void ActivePlayer1 ()
	{
		if (!loadingPlayer.playerOneActive)
		{
			textPlayer1Join.SetActive (false);
			textPlayer1Joined.SetActive (true);
			numberActivePlayers ++;
			loadingPlayer.playerOneActive = true;
			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer2 ()
	{
		if (!loadingPlayer.playerTwoActive)
		{
			textPlayer2Join.SetActive (false);
			textPlayer2Joined.SetActive (true);
			numberActivePlayers ++;
			loadingPlayer.playerTwoActive = true;
			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer3 ()
	{
		if (!loadingPlayer.playerTreeActive)
		{
			textPlayer3Join.SetActive (false);
			textPlayer3Joined.SetActive (true);
			numberActivePlayers ++;
			loadingPlayer.playerTreeActive = true;
			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer4 ()
	{
		if (!loadingPlayer.playerFourActive)
		{
			textPlayer4Join.SetActive (false);
			textPlayer4Joined.SetActive (true);
			numberActivePlayers ++;
			loadingPlayer.playerFourActive = true;
			CheckNumberPlayers ();
		}
	}

	public void DesactivePlayer1 ()
	{
		if (loadingPlayer.playerOneActive)
		{
			textPlayer1Join.SetActive (true);
			textPlayer1Joined.SetActive (false);
			numberActivePlayers --;
			loadingPlayer.playerOneActive = false;
			CheckNumberPlayers ();
		}
	}
	
	public void DesactivePlayer2 ()
	{
		if (loadingPlayer.playerTwoActive)
		{
			textPlayer2Join.SetActive (true);
			textPlayer2Joined.SetActive (false);
			numberActivePlayers --;
			loadingPlayer.playerTwoActive = false;
			CheckNumberPlayers ();
		}
	}
	
	public void DesactivePlayer3 ()
	{
		if (loadingPlayer.playerTreeActive)
		{
			textPlayer3Join.SetActive (true);
			textPlayer3Joined.SetActive (false);
			numberActivePlayers --;
			loadingPlayer.playerTreeActive = false;
			CheckNumberPlayers ();
		}
	}
	
	public void DesactivePlayer4 ()
	{
		if (loadingPlayer.playerFourActive)
		{
			textPlayer4Join.SetActive (true);
			textPlayer4Joined.SetActive (false);
			numberActivePlayers --;
			loadingPlayer.playerFourActive = false;
			CheckNumberPlayers ();
		}
	}
}
