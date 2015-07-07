using UnityEngine;
using System.Collections;

public class WaitToPressStart : MonoBehaviour 
{
	public GameObject startObject;

	void Awake () 
	{
		startObject.SetActive(false);
		StartCoroutine(WaitStart());
	}
	
	// Update is called once per frame
	private IEnumerator WaitStart () 
	{	
		yield return new WaitForSeconds(2f);
		startObject.SetActive(true);
	}
}
