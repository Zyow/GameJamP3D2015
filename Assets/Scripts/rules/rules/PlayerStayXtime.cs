using UnityEngine;
using System.Collections;

public class PlayerStayXtime : RuleGetPlayerNbr 
{
	private int time;
	public int timeMax;
	private Rigidbody myRigibody;
	private bool isUsed;

	 void Start()
	{
		if ( FindObjectOfType<RuleStayXTime>())
		{
			InvokeRepeating("TimerUp",1f,1f);
			isUsed = true;
		}
		myRigibody = GetComponent<Rigidbody>();
	}
	void Update()
	{
		print(myRigibody.velocity.z);
		if (isUsed)
		{
			if (myRigibody.velocity.z >= 0.1 || myRigibody.velocity.z <= -0.1)
				TimerReset();
			if (myRigibody.velocity.y > 0.1)
				TimerReset();
		}
	}
	private void TimerUp()
	{
		if (isUsed)
		{
			time += 1;
			if (time >= timeMax)
			{
				FindObjectOfType<RuleStayXTime>().Done(playerNbr);
				PlayerStayXtime[] players = FindObjectsOfType<PlayerStayXtime>();
				foreach ( PlayerStayXtime player in players)
				{
					player.GetComponent<PlayerStayXtime>().Desactive();
				}
			}
		}
		else 
			CancelInvoke();
	}

	private void TimerReset()
	{
		time = 0;
	}

	public void Desactive()
	{
		isUsed = false;
	}
}
