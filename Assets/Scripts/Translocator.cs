using UnityEngine;
using System.Collections;

public class Translocator : MonoBehaviour 
{
	public GameObject[] doors;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player1" || col.tag == "Player2" || col.tag == "Player3" || col.tag == "Player4" )
		{

		}
	}
}
