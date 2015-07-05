using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
	public AudioClip pauseSFX;
	public GameObject uiPause;

	private AudioSource audioSource;
	public bool isInPause;
	public AudioManager audioManager;

	void Awake ()
	{
		Time.timeScale = 1;
		uiPause.SetActive (false);
		audioSource = GetComponent<AudioSource>();
		audioManager = FindObjectOfType<AudioManager>();
	}

	void Update ()
	{
		if (Input.GetButtonDown("Pause"))
		{
			ButtonResume ();
		}
	}

	public void ButtonResume ()
	{
		audioSource.PlayOneShot (pauseSFX);
		isInPause = !isInPause;
		if (isInPause)
		{
			audioManager.MenuLaunched ();
			uiPause.SetActive (true);
			Time.timeScale = 0;
		}
		else 
		{
			audioManager.GameLaunched ();
			uiPause.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void ButtonTitleScreen ()
	{
		Application.LoadLevel ("Scene Title Screen");
	}
}
