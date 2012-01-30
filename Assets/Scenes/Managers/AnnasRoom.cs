/// <summary>
/// Annas room.
/// </summary>
using UnityEngine;
using System.Collections;

public class AnnasRoom : SceneManager {
	
	protected override void Awake ()
	{
		this.LoadAnna();
		this.LoadMessaging();
		this.LoadTimeLeft();
		this.FindInventory();
		this.LoadAudio();
		LoadMainLight();
	}
	
	void Start()
	{
		//this.player.transform.position = new Vector3(-1.5f, 0.0f, 0.0f);
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.transform.position = new Vector3(-1.5f, 0.0f, 0.0f);
		//player.transform.Translate(-1.5f, 0.0f, 0.0f);
	}
	
	protected override void LoadAnna ()
	{
		if(GameObject.FindGameObjectWithTag("Player") == null)
		{
			Debug.LogWarning("Loading Anna");
			GameObject player = Instantiate(Resources.Load("Player")) as GameObject;
			
			if (player != null)
			{
				player.name = "Player";
				player.tag = "Player";
			}
			else
			{
				Debug.LogError(string.Format(FORMAT_FailLoading, "Player"));
			}
		}
		else
		{
			Debug.LogWarning("Anna Already Exist");
		}
	}
}
