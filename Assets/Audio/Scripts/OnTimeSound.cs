using UnityEngine;
using System.Collections;

public class OnTimeSound : MonoBehaviour {
	
	AudioSource audioSource;
	
	public Item item;
	
	// Use this for initialization
	void Start () 
	{
		audioSource = this.audioSource;
	}
	
	/// <summary>
	/// Plays sound once if not null
	/// </summary>
	public void PlaySound()
	{
		if(audioSource.clip != null)
		{
			audioSource.Play();
		}
	}
}
