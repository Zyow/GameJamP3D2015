using UnityEngine;
using System.Collections;

public class Dance : MonoBehaviour 
{
	
	public void DancePosition () 
	{
		transform.parent.transform.rotation = Quaternion.Euler(0f, 180, 0f);
	}
}
