using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour 
{
	public void Die()
	{
		GameObject.FindObjectOfType<RespawnPlayer>().LaunchRespawn(gameObject);
		if(GetComponent<PlayerSuicideYourself>())
		GetComponent<PlayerSuicideYourself>().Death();
		gameObject.SetActive(false);
	}

	public void Respawn (Vector3 pos)
	{
		transform.position = pos;
	}
}
