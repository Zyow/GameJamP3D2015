using UnityEngine;
using System.Collections;

public class LineRenderAttach : MonoBehaviour 
{
	public Transform attachStart;
	public Transform attachStop;

	private LineRenderer lineR;
	
	void Start () 
	{
		lineR = GetComponent<LineRenderer>();
	}

	void LateUpdate () 
	{
		lineR.SetPosition(0, attachStart.position);
		lineR.SetPosition(1, attachStop.position);
	}
}
