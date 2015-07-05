using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour 
{

	public float time = 1;

	void Update () 
	{
		Destroy( gameObject, time );
	}
}
