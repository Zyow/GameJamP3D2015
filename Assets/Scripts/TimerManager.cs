using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour 
{
	public Text textTimer;
	public GameObject superRuleUI;

	public float timerMax;

	public float minSuperRuleDuration;
	public float maxSuperRuleDuration;
	
	public float minSuperRuleWaitingTime;	
	public float maxSuperRuleWaitingTime;

	public float timeRefreshTimer;
	public bool isASuperRuleIsActive;

	public bool canCheat;
	public bool isThereSuperRulesInTheGame;
	
	private float timerCurrent;
	private float timerSuperRule;

	private float currentSuperRuleDuration;
	private float currentSuperRuleWaitingTime;

	public GameObject endGameManager;
	public float introDuration;

	private float currentIntroTimer;
	public Text textCurrentIntroTimer;

	public Animator introAnimator;

	public float outroDuration;

	public AudioManager audioManager;

	public EndManager endManager;

	public Renderer curtainG;
	public Renderer curtainD;

	public RuleScore ruleScorePlayer1;
	public RuleScore ruleScorePlayer2;
	public RuleScore ruleScorePlayer3;
	public RuleScore ruleScorePlayer4;

	private PlayerMove[] playerMove;
	private PlayerHit[] playerHit;
	private PlayerStayXtime[] playerStay;

	void Awake () 
	{
		//introAnimator = curtains.GetComponent<Animator>();
		playerMove = FindObjectsOfType<PlayerMove>();
		playerHit = FindObjectsOfType<PlayerHit>();
		playerStay = FindObjectsOfType<PlayerStayXtime>();

		timerCurrent = timerMax;
		//textTimer = transform.GetChild(0).GetChild(0).GetComponent<Text>();
		//superRuleUI = transform.GetChild(0).GetChild(1).gameObject;
		textTimer.enabled = false;
		superRuleUI.SetActive (false);
		ShowTimer ();
		currentIntroTimer = introDuration;
		audioManager = FindObjectOfType <AudioManager>();
		endManager = FindObjectOfType <EndManager>();
//		StartIntro ();

		PlayerPrefs.SetInt("Player 1 Score", 0);
		PlayerPrefs.SetInt("Player 2 Score", 0);
		PlayerPrefs.SetInt("Player 3 Score", 0);
		PlayerPrefs.SetInt("Player 4 Score", 0);
		textCurrentIntroTimer.gameObject.SetActive(false);
	}

	private void ShowTimer ()
	{
		var minutes = timerCurrent / 60; 
		var seconds = timerCurrent % 60;

		textTimer.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
	}

	private void NewSuperRule ()
	{
		isASuperRuleIsActive = true;
		superRuleUI.SetActive (isASuperRuleIsActive);
		currentSuperRuleDuration = Random.Range (minSuperRuleDuration, maxSuperRuleDuration);
		StartCoroutine (EndSuperRule (currentSuperRuleDuration));
	}

	private void WaitSuperRule ()
	{
		isASuperRuleIsActive = false;
		superRuleUI.SetActive (isASuperRuleIsActive);
		currentSuperRuleWaitingTime = Random.Range (minSuperRuleWaitingTime, maxSuperRuleWaitingTime);
		StartCoroutine (StartSuperRule (currentSuperRuleWaitingTime));
	}

	IEnumerator StartSuperRule (float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		NewSuperRule ();
	}

	IEnumerator EndSuperRule (float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		WaitSuperRule ();
	}

	IEnumerator TimerUI (float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		timerCurrent -= timeRefreshTimer;
		ShowTimer ();
		if (timerCurrent > 0)
			StartCoroutine (TimerUI (timeRefreshTimer));
		else
			EndTimer ();

		if (timerCurrent == outroDuration)
			Outro ();
	}

	private void Outro ()
	{
		ShowCurtains ();
		introAnimator.SetTrigger ("onOutro");
	}

	private void ShowCurtains ()
	{
		curtainG.enabled = true;
		curtainD.enabled = true;
	}

	private void HideCurtains ()
	{
		curtainG.enabled = false;
		curtainD.enabled = false;
	}

	void Update ()
	{
		if (canCheat && Input.GetKeyDown (KeyCode.Alpha5))
		{
			EndTimer ();
		}
	}

	public void StartIntro ()
	{
		StartCoroutine (IntroTimer(1f));
		
		ShowCurtains ();
		introAnimator.SetTrigger ("onIntro");
	}

	private void ShowTimerIntro ()
	{
		textCurrentIntroTimer.gameObject.SetActive(true);
		if (currentIntroTimer > 0)
			textCurrentIntroTimer.text = currentIntroTimer + "";
		else 
			textCurrentIntroTimer.text = "Partez !";
	}

	IEnumerator IntroTimer (float waitTime)
	{
		ShowTimerIntro ();
		yield return new WaitForSeconds(waitTime);
		currentIntroTimer --;
		if (currentIntroTimer >= 0)
			StartCoroutine (IntroTimer (1f));
		else
			StartTimer ();
	}

	IEnumerator WaitTimer (float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		StartTimer ();
	}

	public void StartTimer ()
	{
		foreach (PlayerMove play in playerMove)
			play.AllowMove();

		foreach (PlayerHit hit in playerHit)
			hit.AllowHit();

		foreach (PlayerStayXtime pStay in playerStay)
			pStay.AllowUseStay();

		if (audioManager != null)
			audioManager.GameLaunched ();

		textCurrentIntroTimer.enabled = false;
		HideCurtains ();

		textTimer.enabled = true;
		isASuperRuleIsActive = false;
		superRuleUI.SetActive (isASuperRuleIsActive);
		StartCoroutine (TimerUI (timeRefreshTimer));
		if (isThereSuperRulesInTheGame)
			WaitSuperRule ();
	}

	private void EndTimer ()
	{
		if (audioManager != null)
			audioManager.MenuLaunched ();

		StopAllCoroutines ();
		isASuperRuleIsActive = false;
		superRuleUI.SetActive (isASuperRuleIsActive);
		//endManager.ActiveEnd ();
		HideCurtains ();

		PlayerPrefs.SetInt("Player 1 Score", ruleScorePlayer1.score);
		PlayerPrefs.SetInt("Player 2 Score", ruleScorePlayer2.score);
		PlayerPrefs.SetInt("Player 3 Score", ruleScorePlayer3.score);
		PlayerPrefs.SetInt("Player 4 Score", ruleScorePlayer4.score);
		Application.LoadLevel ("Scene End");
	}
}
