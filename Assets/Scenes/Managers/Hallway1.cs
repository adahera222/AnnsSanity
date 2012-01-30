using UnityEngine;
using System.Collections;

public class Hallway1 : SceneManager {

	// Use this for initialization
	void Start() {
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.transform.position = new Vector3(0.0f, -4.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update() {
	
	}
	
	void Awake()
	{
		base.Awake();
	}
	
	/// <summary>
	/// Finds the inventory.
	/// </summary>
	void FindInventory()
	{
		if(GameObject.FindGameObjectWithTag("Inventory") == null)
		{
			Debug.LogWarning("Loading Inventory");
			Object inventory = Instantiate(Resources.Load("Inventory"));
			inventory.name = "Inventory";
		}
		else
		{
			Debug.LogWarning("Inventory Already Exist");
		}
	}
	
	/// <summary>
	/// Finds the player.
	/// </summary>
	void LoadAnna()
	{
		if(GameObject.FindGameObjectWithTag("Player") == null)
		{
			Debug.LogWarning("Loading Anna");
			CrazyBastard player = Instantiate(Resources.Load("Player")) as CrazyBastard;
			if(player != null) {
				player.name = "Anna";
				player.transform.position = new Vector3(0.0f, 4.0f, 0.0f);
			}
			
		}
		else
		{
			Debug.LogWarning("Anna Already Exist");
		}
	}
}
