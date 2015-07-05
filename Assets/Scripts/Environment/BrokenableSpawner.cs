using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrokenableSpawner : MonoBehaviour 
{
	public BrokenableItem prefabBreakable;
	public Transform spawnPointPrefab;
	public List<Transform> pos;
	public int nbrDestroy;
	private Dictionary<Transform,bool> used = new Dictionary<Transform, bool>();
	private Dictionary<int,int>  playersScore = new Dictionary<int, int>();

	void Start()
	{
		Transform truc = Instantiate(spawnPointPrefab) as Transform;
		pos = new List<Transform>(truc.GetComponentsInChildren<Transform>());

		for ( int i = 0; i < pos.Count;i++ )
		{
			used.Add(pos[i],false);
		}
		SpawnItem();
		StartCoroutine(Spawnwave());
	}

	private IEnumerator Spawnwave()
	{
		if (true)
		{
			SpawnItem();			
		}
		yield return new WaitForSeconds(5f);
		
	}

	private void SpawnItem()
	{
		for ( int i = 0; i < pos.Count;i++ )
		{
			if (!used[pos[i]])
			{
				BrokenableItem prefab = Instantiate(prefabBreakable,pos[i].position,Quaternion.identity) as BrokenableItem;
				prefab.transform.SetParent(pos[i]);
				used[pos[i]] = true;
			}
		}
	}
	
	public void Broken( int player, Transform spawn)
	{
		used[spawn] = false;
		print ("lol");
		playersScore[player] ++;
		if(playersScore[player] > nbrDestroy)
		{
			FindObjectOfType<RuleItemBreak>().Done(player);
		}
	}
}
