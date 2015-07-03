using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnPlayer : MonoBehaviour 
{
	private PlayerRespawn player;
	public float delayAddSpawnPoint;
	public List<GameObject> respawnPoints;
	private List<GameObject> removedPoints;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindObjectOfType<PlayerRespawn>();
		foreach(GameObject points in GameObject.FindGameObjectsWithTag("RespawnPlayer"))
		{
			respawnPoints.Add(points);
		}
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			LaunchRespawn();
		}
	}
	public void LaunchRespawn()
	{
		int spawnIndex = Random.Range(0,transform.childCount-1);
		player.Respawn(respawnPoints[spawnIndex].transform.position);
		//removedPoints.Add(respawnPoints[spawnIndex]);
		GameObject removedpoint = respawnPoints[spawnIndex];
		respawnPoints.RemoveAt(spawnIndex);
		StartCoroutine(AddSpawnPoint(removedpoint));
	}
	IEnumerator AddSpawnPoint(GameObject removed)
	{
		print (removed.name);
		yield return new WaitForSeconds(delayAddSpawnPoint);
		respawnPoints.Add(removed);
	}

}
