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

	void Start() 
	{
		timerCurrent = timerMax;
		//textTimer = transform.GetChild(0).GetChild(0).GetComponent<Text>();
		//superRuleUI = transform.GetChild(0).GetChild(1).gameObject;
		superRuleUI.SetActive (false);
		ShowTimer ();
	}

	private void ShowTimer ()
	{
		textTimer.text = timerCurrent + " s";
	}

	private void NewSuperRule ()
	{
		isASuperRuleIsActive = true;
		superRuleUI.SetActive (isASuperRuleIsActive);
		currentSuperRuleDuration = Random.Range (minSuperRuleDuration, maxSuperRuleDuration);
		StartCoroutine (EndSuperRule(currentSuperRuleDuration));
	}

	private void WaitSuperRule ()
	{
		isASuperRuleIsActive = false;
		superRuleUI.SetActive (isASuperRuleIsActive);
		currentSuperRuleWaitingTime = Random.Range (minSuperRuleWaitingTime, maxSuperRuleWaitingTime);
		StartCoroutine (StartSuperRule(currentSuperRuleWaitingTime));
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

	IEnumerator TimerUI(float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		timerCurrent -= timeRefreshTimer;
		ShowTimer ();
		if (timerCurrent > 0)
			StartCoroutine(TimerUI(timeRefreshTimer));
		else
			EndTimer ();
	}

	void Update ()
	{
		if (canCheat)
		{
			//cheat
			if (Input.GetKeyDown(KeyCode.C))
				StartTimer ();
			
			if (Input.GetKeyDown(KeyCode.R))
				EndTimer ();
		}
	}

	public void StartTimer ()
	{
		isASuperRuleIsActive = false;
		superRuleUI.SetActive (isASuperRuleIsActive);
		StartCoroutine(TimerUI(timeRefreshTimer));
		if (isThereSuperRulesInTheGame)
			WaitSuperRule ();
	}

	private void EndTimer ()
	{
		StopAllCoroutines ();
		isASuperRuleIsActive = false;
		superRuleUI.SetActive (isASuperRuleIsActive);
	}
}
