using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public AudioClip gameMusic;
	public AudioClip menuMusic;
	private AudioSource audioSource;
	public static AudioManager instance;

	void Start ()
	{
		if (instance == null)
		{
			DontDestroyOnLoad (gameObject);
			instance = this;
			audioSource = GetComponent<AudioSource>();
			MenuLaunched ();
		}
		else if ( instance != this)
		{
			Destroy (gameObject);
		}

		/*if(GameObject.FindObjectOfType<AudioSource>() != null)
		{
			Destroy (gameObject);
		}*/
		//DontDestroyOnLoad (gameObject);
	}

	void Update ()
	{
		//cheat
		if (Input.GetKeyDown(KeyCode.Y))
			GameLaunched ();

		if (Input.GetKeyDown(KeyCode.U))
			MenuLaunched ();
	}

	public void GameLaunched ()
	{
		audioSource.clip = gameMusic;
		audioSource.Play ();
	}

	public void MenuLaunched ()
	{
		audioSource.clip = menuMusic;
		audioSource.Play ();
	}
}
