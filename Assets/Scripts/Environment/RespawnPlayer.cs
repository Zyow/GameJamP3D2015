using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnPlayer : MonoBehaviour 
{
	public float delayAddSpawnPoint;
	public float delayActivePlayer;
	public List<GameObject> respawnPoints;
	private List<GameObject> removedPoints;

	// Use this for initialization
	void Start () 
	{
		foreach(GameObject points in GameObject.FindGameObjectsWithTag("RespawnPlayer"))
		{
			respawnPoints.Add(points);
		}
	}
	public void LaunchRespawn(GameObject player)
	{
		int spawnIndex = Random.Range(0,transform.childCount-1);
		player.GetComponent<PlayerRespawn>().Respawn(respawnPoints[spawnIndex].transform.position);
		GameObject removedpoint = respawnPoints[spawnIndex];
		respawnPoints.RemoveAt(spawnIndex);
		StartCoroutine(ActivePlayer(player));
		StartCoroutine(AddSpawnPoint(removedpoint));
	}
	IEnumerator AddSpawnPoint(GameObject removed)
	{
		yield return new WaitForSeconds(delayAddSpawnPoint);
		respawnPoints.Add(removed);
	}

	IEnumerator ActivePlayer(GameObject player)
	{
		yield return new WaitForSeconds(delayActivePlayer);
		player.SetActive(true);
	}
}
