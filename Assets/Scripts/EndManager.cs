using UnityEngine;
using System.Collections;

public class EndManager : MonoBehaviour 
{
	public void ButtonReplay ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void ButtonTitleScreen ()
	{
		Application.LoadLevel ("Scene Title Screen");
	}
}
