using UnityEngine;
using System.Collections;

public class BrokenableItem : MonoBehaviour 
{
	public int life;
	// Use this for initialization
	void Start () 
	{
		
	}
	public void BreakingBad()
	{
		life--;
		if(life<=0)
		{
			//Animation Destruction Object(Caisse/Bouteille/Cage)
		}
	}
}
