using UnityEngine;
using System.Collections;

public class PlayerStayXtime : PlayerBase 
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
		print(IsInvoking("TimerUp"));

		if (isUsed)
		{
			if (myRigibody.velocity.x >= 0.1 || myRigibody.velocity.x <= -0.1)
				CancelInvoke();
			else if (myRigibody.velocity.y > 0.1)
				CancelInvoke();
			else
			{
				print ("test");
				if (!IsInvoking("TimerUp"))
				{
					InvokeRepeating("TimerUp",1f,1f);				
				}
			}
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

	public void Desactive()
	{
		isUsed = false;
	}
}
