using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public AudioClip gameMusic;
	public AudioClip menuMusic;
	private AudioSource audioSource;

	void Start ()
	{
		DontDestroyOnLoad (gameObject);
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = menuMusic;
	}

	public void GameLaunched ()
	{
		audioSource.clip = gameMusic;
	}

	public void GameEnd ()
	{
		audioSource.clip = menuMusic;
	}
}
