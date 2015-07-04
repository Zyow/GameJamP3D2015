using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour 
{
	public GameObject uiTitleScreen;
	public bool titleScreenActive;

	void Start ()
	{
		uiTitleScreen.SetActive (titleScreenActive);
	}
}
