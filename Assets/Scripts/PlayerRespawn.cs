using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour 
{
	public void Respawn (Vector3 pos)
	{
		transform.position = pos;
	}
}
