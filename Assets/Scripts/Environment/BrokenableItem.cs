using UnityEngine;
using System.Collections;

public class BrokenableItem : MonoBehaviour 
{
	public int life;

	public void Damaged(string player)
	{
		life--;

		if(life<=0)
		{
			Destroy(gameObject);
			GetComponent<ItemBreak>().Breaking(player);
			//Animation Destruction Object(Caisse/Bouteille/Cage)
		}
	}
}
