using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuleManager : MonoBehaviour 
{
	private List<RuleBase> rules;
	public List<Transform> posUI;

	void Awake()
	{
		rules = new List<RuleBase>(Resources.LoadAll<RuleBase>("Rules"));
		print ("lol");
		foreach ( Transform pos in posUI)
		{
			int rdm = Random.Range(0,rules.Count);
			print (rules[rdm]);
			RuleBase clone = Instantiate(rules[rdm],pos.position,pos.rotation) as RuleBase;
			rules.RemoveAt(rdm);
			clone.GetComponent<RectTransform>().SetParent(pos);
			clone.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
		}
	}
}
