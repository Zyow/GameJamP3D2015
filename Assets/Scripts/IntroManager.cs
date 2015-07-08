using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour 
{
	private TimerManager timerManager;
	private RuleManager ruleManager;
	

	// Use this for initialization
	void Awake () 
	{
		timerManager = FindObjectOfType<TimerManager>();
		ruleManager = FindObjectOfType<RuleManager>();
		StartCoroutine(IntroTime());
	}
	
	// Update is called once per frame
	private IEnumerator IntroTime () 
	{
		yield return new WaitForSeconds(5f);
		timerManager.StartIntro();
	
	}
}
