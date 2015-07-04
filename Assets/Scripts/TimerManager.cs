using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour 
{
	public float timerMax;
	private float timerCurrent;
	private float timerSuperRule;
	private Text textTimer;
	private GameObject superRuleUI;

	void Start() 
	{
		timerCurrent = timerMax;
		StartCoroutine(TimerUI(1.0f));
		textTimer = transform.GetChild(0).GetChild(0).GetComponent<Text>();
		ShowTimer ();
		superRuleUI.SetActive (false);
	}

	void ShowTimer ()
	{
		print(timerCurrent);
		textTimer.text = timerCurrent + " s";
	}

	IEnumerator TimerUI(float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		timerCurrent --;
		ShowTimer ();
		if (timerCurrent > 0)
			StartCoroutine(TimerUI(1.0f));
		else
			EndTimer ();
	}

	void Update ()
	{
		//cheat
		if (Input.GetKey(KeyCode.R))
			EndTimer ();
	}

	private void EndTimer ()
	{
		StopAllCoroutines ();
		print ("end !");
	}
}
