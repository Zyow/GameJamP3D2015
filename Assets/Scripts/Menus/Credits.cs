using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour 
{
	public GameObject uiCredits;

	/*void Start ()
	{
		uiCredits.SetActive (false);
	}*/

	public void ButtonReturn ()
	{
		//uiCredits.SetActive (false);
		Application.LoadLevel ("Scene Title Screen");
	}
}
