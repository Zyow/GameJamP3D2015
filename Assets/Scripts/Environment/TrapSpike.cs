using UnityEngine;
using System.Collections;

public class TrapSpike : MonoBehaviour 
{
	private LoadingPlayer loadingPlayer;

//	void Start()
//	{
//		loadingPlayer=GameObject.FindObjectOfType<LoadingPlayer>();
//		if(loadingPlayer!=null)
//		{
//			loadingPlayer.ActivePlayer();
//		}
//	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.GetComponent<PlayerRespawn>()!=null)
		{
			col.GetComponent<PlayerRespawn>().Die();
		}
	}
}
