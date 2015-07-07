using UnityEngine;
using System.Collections;

public class PlayerHide : PlayerBase 
{
	public int timetoHide;
	private int timeHidden;
	private bool isUsed;

	void Start()
	{
		if(FindObjectOfType<RuleHide>())
			isUsed = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Hide")
		{
			InvokeRepeating("Hiding",1f,1f);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Hide")
		{
			CancelInvoke();
		}
	}

	public void Hiding ()
	{
		if(isUsed)
		{
			timeHidden ++;

			if(timeHidden >= timetoHide)
			{
				if (FindObjectOfType<RuleHide>())
					FindObjectOfType<RuleHide>().Done(playerNbr);

				PlayerHide[] players = FindObjectsOfType<PlayerHide>();
				foreach ( PlayerHide player in players)
				{
					player.GetComponent<PlayerHide>().Desactive();
				}
			}
		}
	}

	public void Desactive()
	{
		isUsed = false;
	}
}
