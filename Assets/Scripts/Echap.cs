using UnityEngine;
using System.Collections;

public class Echap : MonoBehaviour 
{
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit ();
	}
}
