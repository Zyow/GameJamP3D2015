using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour
{
	public void Collected ()
	{
		Destroy(gameObject);
	}
}
