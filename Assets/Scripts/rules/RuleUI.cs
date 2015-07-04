using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RuleUI : MonoBehaviour 
{
	private Text text;

	void Start ()
	{
		GetComponent<RuleBase>().winnerUI += ChangeColor;
		text = GetComponent<Text>();
	}

	private void ChangeColor(int player )
	{
//		switch (player)
//		{
//		case 1:
//			text.color = Color.blue;
//			break;
//
//		case 2 :
//			text.color = Color.green;
//			break;
//
//		case 3 :
//			text.color = Color.yellow;
//			break;
//
//		case 4 :
//			text.color = Color.red;
//			break;
//		}
	}
}
