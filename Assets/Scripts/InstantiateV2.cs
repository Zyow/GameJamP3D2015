using UnityEngine;
using System.Collections;

public class InstantiateV2 : MonoBehaviour 
{
	private LoadingPlayer loadingPlayer;
	void Awake ()
	{
		loadingPlayer = FindObjectOfType<LoadingPlayer>();
		loadingPlayer.ActivePlayer ();
	}
}
