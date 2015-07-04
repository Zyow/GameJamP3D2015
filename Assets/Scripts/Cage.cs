using UnityEngine;
using System.Collections;

public class Cage : MonoBehaviour 
{
	public int life;

	public void TakeHit()
	{
		life --;
		if (life == 0)
		{
			Destroy(gameObject);
		}
	}
}
