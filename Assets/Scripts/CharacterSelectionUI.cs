using UnityEngine;
using System.Collections;

public class CharacterSelectionUI : MonoBehaviour 
{
	public GameObject loadingPlayerPrefab;
	public GameObject canLaunchGameUI;
	public GameObject cantLaunchGameUI;

	public int numberActivePlayers;
	private bool canLaunchGame;
	private LoadingPlayer loadingPlayer;

	void Start ()
	{
		Instantiate (loadingPlayerPrefab);
		loadingPlayer = loadingPlayerPrefab.GetComponent<LoadingPlayer>();
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

		if (Input.GetButtonDown ("Pause") && canLaunchGame)
		{
			Application.LoadLevel("SceneRespawnPlayer");
			loadingPlayer.ActivePlayer ();
		}
	}

	private void CheckNumberPlayers ()
	{
		if (numberActivePlayers >= 2)
		{
			canLaunchGame = true;
			cantLaunchGameUI.SetActive (false);
			canLaunchGameUI.SetActive (true);
		}
	}

	public void ActivePlayer1 ()
	{
		if (!loadingPlayer.playerOneActive)
		{
			numberActivePlayers ++;
			loadingPlayer.playerOneActive = true;
			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer2 ()
	{
		if (!loadingPlayer.playerTwoActive)
		{
			numberActivePlayers ++;
			loadingPlayer.playerTwoActive = true;
			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer3 ()
	{
		if (!loadingPlayer.playerTreeActive)
		{
			numberActivePlayers ++;
			loadingPlayer.playerTreeActive = true;
			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer4 ()
	{
		if (!loadingPlayer.playerFourActive)
		{
			numberActivePlayers ++;
			loadingPlayer.playerFourActive = true;
			CheckNumberPlayers ();
		}
	}
}
