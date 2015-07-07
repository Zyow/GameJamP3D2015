using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour 
{
	public bool canCheat;

	void Update()
	{
		if(Input.GetButtonDown("Pause"))
			Application.LoadLevel ("SceneCharacterSelection");

		if (canCheat && Input.GetKeyDown(KeyCode.Return))
			Application.LoadLevel ("SceneCharacterSelection");
	}
}
