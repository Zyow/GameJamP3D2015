using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour 
{
	public GameObject uiTitleScreen;
	//public GameObject uiCredits;
	//public bool titleScreenActive;

	/*void Start ()
	{
		uiTitleScreen.SetActive (titleScreenActive);
	}*/

	public void ButtonPlay ()
	{
		//uiTitleScreen.SetActive (false);
		Application.LoadLevel ("SceneCharacterSelection");
	}

	public void ButtonCredits ()
	{
		Application.LoadLevel ("Scene Credits Screen");
		//uiTitleScreen.SetActive (false);
	}

	public void ButtonQuit ()
	{
		Application.Quit ();
	}
}
