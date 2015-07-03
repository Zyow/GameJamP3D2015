using UnityEngine;
using System.Collections;

public class PlayerStayXtime : RuleGetPlayerNbr 
{
	private int time;
	public int timeMax;

	 void Start()
	{
		if ( FindObjectOfType<RuleStayXTime>())
		InvokeRepeating("TimerUp,1f,1f");
	}

	public void TimerUp()
	{
		time ++;
		if (time >= timeMax)
			FindObjectOfType<RuleStayXTime>().Done(playerNbr);
	}

	public void TimerReset()
	{
		time = 0;
	}
}
