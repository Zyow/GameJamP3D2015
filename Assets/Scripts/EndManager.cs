using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndManager : MonoBehaviour 
{
	public GameObject textWinnerPlayer1;
	public GameObject textWinnerPlayer2;
	public GameObject textWinnerPlayer3;
	public GameObject textWinnerPlayer4;

//	public int scorePlayer1;
//	public int scorePlayer2;
//	public int scorePlayer3;
//	public int scorePlayer4;

	public Text textScorePlayer1;
	public Text textScorePlayer2;
	public Text textScorePlayer3;
	public Text textScorePlayer4;

	public AudioManager audioManager;

	public GameObject canvasEnd;
	
//	public RuleScore ruleScorePlayer1;
//	public RuleScore ruleScorePlayer2;
//	public RuleScore ruleScorePlayer3;
//	public RuleScore ruleScorePlayer4;

	public int scorePlayer1;
	public int scorePlayer2;
	public int scorePlayer3;
	public int scorePlayer4;

	void Start ()
	{
		audioManager = FindObjectOfType <AudioManager>();
		if (audioManager != null)
			audioManager.MenuLaunched ();

		canvasEnd.SetActive (false);

//		textWinnerPlayer1.SetActive (false);
//		textWinnerPlayer2.SetActive (false);
//		textWinnerPlayer3.SetActive (false);
//		textWinnerPlayer4.SetActive (false);
	
		ActiveEnd ();
	}

	public void ActiveEnd ()
	{
		scorePlayer1 = PlayerPrefs.GetInt("Player 1 Score", 0);
		scorePlayer2 = PlayerPrefs.GetInt("Player 2 Score", 0);
		scorePlayer3 = PlayerPrefs.GetInt("Player 3 Score", 0);
		scorePlayer4 = PlayerPrefs.GetInt("Player 4 Score", 0);

		textScorePlayer1.text = "Score : " + scorePlayer1;
		textScorePlayer2.text = "Score : " + scorePlayer2;
		textScorePlayer3.text = "Score : " + scorePlayer3;
		textScorePlayer4.text = "Score : " + scorePlayer4;

		canvasEnd.SetActive (true);

		if (scorePlayer1 >= scorePlayer2
		    && scorePlayer1 >= scorePlayer3
		    && scorePlayer1 >= scorePlayer4)
			Player1Win ();
		
		if (scorePlayer2 >= scorePlayer1
		    && scorePlayer2 >= scorePlayer3
		    && scorePlayer2 >= scorePlayer4)
			Player2Win ();
		
		if (scorePlayer3 >= scorePlayer1
		    && scorePlayer3 >= scorePlayer2
		    && scorePlayer3 >= scorePlayer4)
			Player3Win ();
		
		if (scorePlayer4 >= scorePlayer1
		    && scorePlayer4 >= scorePlayer2
		    && scorePlayer4 >= scorePlayer3)
			Player4Win ();
	}

	public void Player1Win ()
	{
		textWinnerPlayer1.SetActive (true);
	}

	public void Player2Win ()
	{
		textWinnerPlayer2.SetActive (true);
	}

	public void Player3Win ()
	{
		textWinnerPlayer3.SetActive (true);
	}

	public void Player4Win ()
	{
		textWinnerPlayer4.SetActive (true);
	}

	public void ButtonReplay ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void ButtonTitleScreen ()
	{
		Application.LoadLevel ("Scene Title Screen");
	}
}
