using UnityEngine;
using System.Collections;

public class TrapSpike : MonoBehaviour 
{
	void OnTriggerEnter(Collider col)
	{
		if(col.GetComponent<PlayerRespawn>()!=null)
		{
			col.GetComponent<PlayerRespawn>().Die();
		}
	}
}
