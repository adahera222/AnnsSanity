using UnityEngine;
using System.Collections;

public class Courtyard : SceneManager {
	
	
	void Awake() {
		FindInventory();
		LoadAnna();
		LoadTimeLeft();
		LoadMessaging();
		LoadMainLight();
		LoadAudio();
	}
	
	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.transform.position = new Vector3(3.2f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
