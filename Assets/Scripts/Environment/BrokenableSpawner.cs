using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrokenableSpawner : MonoBehaviour 
{
	public List<Transform> pos;
	private Dictionary<Transform,bool> used = new Dictionary<Transform, bool>();
	public BrokenableItem prefabBreakable;

	void Start()
	{
		for ( int i = 0; i < pos.Count;i++)
		{
			BrokenableItem prefab = Instantiate(prefabBreakable,pos[i].position,Quaternion.identity) as BrokenableItem;
			prefab.transform.SetParent(pos[i]);
			used.Add(pos[i],true);
		}
	}
}
