using UnityEngine;
using System.Collections;

public class DinningRoom : SceneManager {

	protected override void Awake ()
	{
		base.Awake ();
	}
	
	void Start()
	{
		//this.player.transform.position = new Vector3(-1.5f, 0.0f, 0.0f);
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.transform.position = new Vector3(-9.5f, -6.5f, 0.0f);
		//player.transform.Translate(-1.5f, 0.0f, 0.0f);
	}
}
