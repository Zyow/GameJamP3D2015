using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour 
{
	protected int playerNbr;
	protected string playerString;
	protected AudioSource audioSource;
	//protected Animator animator;

	protected virtual void Awake ()
	{
		audioSource = GetComponent<AudioSource>();
		//animator = GetComponent<Animator>();

		switch (transform.tag)
		{
		case "Player1" :
			playerNbr = 1;
			playerString = playerNbr.ToString();
			break;
		case "Player2" :
			playerNbr = 2;
			playerString = playerNbr.ToString();
			break;
		case "Player3" :
			playerNbr = 3;
			playerString = playerNbr.ToString();
			break;
		case "Player4" :
			playerNbr = 4;
			playerString = playerNbr.ToString();
			break;
		}
	}
}
