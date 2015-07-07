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
	
	public RuleScore ruleScorePlayer1;
	public RuleScore ruleScorePlayer2;
	public RuleScore ruleScorePlayer3;
	public RuleScore ruleScorePlayer4;

	void Start ()
	{
		audioManager = FindObjectOfType <AudioManager>();
		if (audioManager != null)
			audioManager.MenuLaunched ();

		canvasEnd.SetActive (false);

		textWinnerPlayer1.SetActive (false);
		textWinnerPlayer2.SetActive (false);
		textWinnerPlayer3.SetActive (false);
		textWinnerPlayer4.SetActive (false);

	}

	public void ActiveEnd ()
	{
		textScorePlayer1.text = "Score : " + ruleScorePlayer1.score;
		textScorePlayer2.text = "Score : " + ruleScorePlayer2.score;
		textScorePlayer3.text = "Score : " + ruleScorePlayer3.score;
		textScorePlayer4.text = "Score : " + ruleScorePlayer4.score;
		canvasEnd.SetActive (true);

		if (ruleScorePlayer1.score >= ruleScorePlayer2.score
		    && ruleScorePlayer1.score >= ruleScorePlayer3.score
		    && ruleScorePlayer1.score >= ruleScorePlayer4.score)
			Player1Win ();
		
		if (ruleScorePlayer2.score >= ruleScorePlayer1.score
		    && ruleScorePlayer2.score >= ruleScorePlayer3.score
		    && ruleScorePlayer2.score >= ruleScorePlayer4.score)
			Player2Win ();
		
		if (ruleScorePlayer3.score >= ruleScorePlayer1.score
		    && ruleScorePlayer3.score >= ruleScorePlayer2.score
		    && ruleScorePlayer3.score >= ruleScorePlayer4.score)
			Player3Win ();
		
		if (ruleScorePlayer4.score >= ruleScorePlayer1.score
		    && ruleScorePlayer4.score >= ruleScorePlayer2.score
		    && ruleScorePlayer4.score >= ruleScorePlayer3.score)
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
