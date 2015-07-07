using UnityEngine;
using System.Collections;

public class Translocator : MonoBehaviour 
{
	public enum EnumTp
	{
		top,
		left,
		right,
		down,
		none,
	};

	public GameObject otherDoor;
	public EnumTp tplocation;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player1" || col.tag == "Player2" || col.tag == "Player3" || col.tag == "Player4" )
		{

			switch(tplocation)
			{
				case EnumTp.down:
					col.transform.position = new Vector2(otherDoor.transform.position.x, otherDoor.transform.position.y-1.2f) ; 
					if (col.GetComponent<PlayerPassByPortals>() != null)
						col.GetComponent<PlayerPassByPortals>().PassedPortal();
				break;
				case EnumTp.top:
					col.transform.position = new Vector2(otherDoor.transform.position.x, otherDoor.transform.position.y+1.2f) ; 
					if (col.GetComponent<PlayerPassByPortals>() != null)
						col.GetComponent<PlayerPassByPortals>().PassedPortal();
				break;
				case EnumTp.left:
					col.transform.position = new Vector2(otherDoor.transform.position.x-1.2f, otherDoor.transform.position.y) ; 
					if (col.GetComponent<PlayerPassByPortals>() != null)
						col.GetComponent<PlayerPassByPortals>().PassedPortal();
				break;
				case EnumTp.right:
					col.transform.position = new Vector2(otherDoor.transform.position.x+1.2f, otherDoor.transform.position.y) ; 
					if (col.GetComponent<PlayerPassByPortals>() != null)
						col.GetComponent<PlayerPassByPortals>().PassedPortal();
				break;
				case EnumTp.none:
				break;
			}

//			// Penser a orienter l'axe Y dans le sens inverse de là ou le player doit spawner
//			if (tplocation == EnumTp.down)
//			{
//			}
		}
	}


	
}
