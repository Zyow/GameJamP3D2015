using UnityEngine;
using System.Collections;

public class RunManager : MonoBehaviour 
{
	private Rigidbody2D rigid;
	private Animator anim;

	// Use this for initialization
	void Awake () 
	{
		rigid = GetComponentInParent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetFloat("Speed", rigid.velocity.magnitude);
	}
}
