using UnityEngine;
using System.Collections;

public class PlayerDance : PlayerBase 
{
	private bool isUsed;
	private int timer;
	public int timeToDance;

	void Start()
	{
		if (FindObjectOfType<RuleDance>())
		isUsed = true;
	}

	void Update ()
	{
		if (Input.GetButtonDown("Taunt Player "+ playerString))
		{
			CancelInvoke();
			InvokeRepeating("Timer",1f,1f);
		}

		if (Input.GetButton("Jump Player "+playerString) || Input.GetButtonDown ("Hit Player "+playerString) || Input.GetAxis("Horizontal Player "+playerString) >=0.1 || Input.GetAxis("Horizontal Player "+playerString) <= -0.1 )
		CancelInvoke();
	}

	private void Timer()
	{
		if ( isUsed)
		{
			timer ++;
			if ( timer >= timeToDance)
			{
				isUsed = false;
				FindObjectOfType<RuleDance>().Done(playerNbr);
				
				PlayerDance[] players = FindObjectsOfType<PlayerDance>();
				foreach ( PlayerDance player in players)
				{
					player.GetComponent<PlayerDance>().Desactive();
				}
			}
		}
	}
	public void Desactive()
	{
		isUsed = false;
	}
}
