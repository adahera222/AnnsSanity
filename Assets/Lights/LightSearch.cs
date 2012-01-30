/// <summary>
/// Light search.
/// </summary>
using UnityEngine;
using System.Collections;

public class LightSearch : MonoBehaviour {
	
	//The tower
	public SpotLight tower;
	
	//the alarm
	AudioSource alarm;
	
	void Start()
	{
		alarm = GetComponent<AudioSource>(); 
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			CrazyBastard player = other.GetComponent<CrazyBastard>();
			player.EnableMove = false;
			alarm.Play();
			tower.animation.Stop();
		}
	}
}
