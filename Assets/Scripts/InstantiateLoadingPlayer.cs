using UnityEngine;
using System.Collections;

public class InstantiateLoadingPlayer : MonoBehaviour 
{
	void Awake()
	{
		Object loadingPlayer = Resources.Load("LoadingPlayer");
		if(GameObject.FindObjectOfType<LoadingPlayer>() == null)
		{
			Instantiate(loadingPlayer);
		}
	}

	/*void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			Application.LoadLevel("SceneRespawnPlayer");
		}
	}*/
}
