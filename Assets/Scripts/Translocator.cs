using UnityEngine;
using System.Collections;

public class Translocator : MonoBehaviour 
{
	public GameObject otherDoor;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player1" || col.tag == "Player2" || col.tag == "Player3" || col.tag == "Player4" )
		{
			// Penser a orienter l'axe Y dans le sens inverse de là ou le player doit spawner
			col.transform.position = new Vector3(otherDoor.transform.position.x, otherDoor.transform.position.y-1.2f, otherDoor.transform.position.z) ; 
		}
	}
}
