using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
	public AudioSource audioSource;
	public AudioClip pauseSFX;
	public GameObject uiPause;
	private bool isInPause;

	void Start ()
	{
		uiPause.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetButtonDown("Pause"))
		{
			audioSource.PlayOneShot (pauseSFX);
			isInPause = !isInPause;
			if (isInPause)
			{
				uiPause.SetActive (true);
				Time.timeScale = 0;
			}
			else 
			{
				uiPause.SetActive (false);
				Time.timeScale = 1;
			}
		}
	}
}
