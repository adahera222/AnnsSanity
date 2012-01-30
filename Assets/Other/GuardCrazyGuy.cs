/// <summary>
/// Simple script for crazy guy/ordery
/// </summary>
using UnityEngine;
using System.Collections;

public class GuardCrazyGuy : MonoBehaviour {
	
	//1.951437
	//-4.396435
	
	//The player
	CrazyBastard player;
	
	//Crazy person
	public GameObject crazyGuy;
	
	//Guard
	public GameObject Guard;
	
	Inventory inventory;
	
	//Position the player will move to
	public GameObject playerPosition;
	
	void Start()
	{
		Debug.Log("Starting Guard Chase");
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		if(inventory.ShowInterface)
		{
			inventory.ToggleInterface();
		}
		StartCoroutine(SetUpAnimation());
	}
	
	IEnumerator SetUpAnimation()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<CrazyBastard>();
		player.EnableMove = false;
		
		yield return new WaitForSeconds(.75f);
		while(crazyGuy.transform.position != transform.position)
		{
			crazyGuy.transform.position = Vector3.MoveTowards(crazyGuy.transform.position, transform.position, 2.0f * Time.deltaTime);
			player.transform.LookAt(playerPosition.transform.position);
			player.transform.position = Vector3.MoveTowards(player.transform.position, playerPosition.transform.position, 2.5f * Time.deltaTime);
			yield return null;
		}
		
		yield return new WaitForSeconds(0.5f);
		animation.Play("GuardCrazyGuy");
		yield return new WaitForSeconds(4.0f);
		Guard.renderer.enabled = true;
		yield return new WaitForSeconds(17.0f);
		player.EnableMove = true;
	}
}
