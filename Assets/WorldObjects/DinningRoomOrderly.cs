using UnityEngine;
using System.Collections;

public class DinningRoomOrderly : WorldObject {

	public Item.ItemProperty WhatOpensMe;
	public Item.ItemProperty WhatElseOpensMe;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	public override Item DoAction ()
	{
		Debug.Log("Crazy talk");
		
		Item selectedItem = getPlayer().SelectedItem;
		
		if (selectedItem != null && (getPlayer().SelectedItem.itemProperty == this.WhatOpensMe || getPlayer().SelectedItem.itemProperty == this.WhatElseOpensMe))
		{
			Door courtyardDoor = GameObject.FindGameObjectWithTag("CourtyardDoor").GetComponent<Door>() as Door;
			
			if (courtyardDoor != null)
			{
				Debug.Log("Found door.");
				courtyardDoor.IsOpen = true;
			}
			else
			{
				Debug.Log("Can't find door.");
			}
			
			MessageManager.AddMessage("Thanks!");
			
			GameObject orderly = GameObject.FindGameObjectWithTag("DinningRoomOrderly");
			
			if (orderly != null)
			{
				orderly.renderer.enabled = false;
				orderly.collider.isTrigger = true;
				
				if (selectedItem.itemProperty == Item.ItemProperty.fork)
				{
					GameObject deadOrderly = GameObject.FindGameObjectWithTag("DeadOrderly");
					
					if (deadOrderly != null)
					{
						deadOrderly.renderer.enabled = true;
						this.audio.PlayOneShot(this.audio.clip);
					}
				}
			}
		}
		else
		{
			int crazyTalk = Mathf.FloorToInt(Random.value * 4);
		
			switch (crazyTalk)
			{
				case 0:
					MessageManager.AddMessage("You're not allowed here.");
					break;
				case 1:
					MessageManager.AddMessage("Get back to your room!");
					break;
				case 2:
					MessageManager.AddMessage("You Shall NOT PASS!");
					break;
				case 3:
					MessageManager.AddMessage("har har har");
					break;
				default:
					MessageManager.AddMessage("I can't believe you made it this far");
					break;
			}
		}
		return null;
	}
}
