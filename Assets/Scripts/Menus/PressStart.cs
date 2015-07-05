using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour 
{

	void Update()
	{
		if(Input.GetButtonDown("Pause"))
		{
			Application.LoadLevel ("SceneCharacterSelection");
		}
	}
	
}
