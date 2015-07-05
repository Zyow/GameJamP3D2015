using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RuleScore : MonoBehaviour 
{
	private Text text;
	private List<RuleBase> rules;
	public int playerNbr;
	public int score;
	
	void Start ()
	{
		rules = new List<RuleBase>(FindObjectsOfType<RuleBase>());
		foreach(RuleBase rule in rules)
			rule.winnerUI += ChangeColor;
		text = GetComponent<Text>();
	}
	
	private void ChangeColor(int player )
	{
		if(player == playerNbr)
		{
			score ++;
			text.text = score.ToString();
		}
	}
}
