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

	void Awake () 
	{
		//introAnimator = curtains.GetComponent<Animator>();
		timerCurrent = timerMax;
		//textTimer = transform.GetChild(0).GetChild(0).GetComponent<Text>();
		//superRuleUI = transform.GetChild(0).GetChild(1).gameObject;
		textTimer.enabled = false;
		superRuleUI.SetActive (false);
		ShowTimer ();
		currentIntroTimer = introDuration;
		audioManager = FindObjectOfType <AudioManager>();
		endManager = FindObjectOfType <EndManager>();
		StartIntro ();
	}

	private void ShowTimer ()
	{
//		textTimer.text = timerCurrent + " s";

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
		if (canCheat)
		{
			//cheat
			//if (Input.GetKeyDown (KeyCode.Alpha6))
			//	StartIntro ();
				//StartTimer ();
			
			if (Input.GetKeyDown (KeyCode.Alpha5))
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
		//Instantiate (endGameManager);
		endManager.ActiveEnd ();
		HideCurtains ();
	}
}
