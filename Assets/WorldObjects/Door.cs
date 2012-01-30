using UnityEngine;
using System.Collections;

public class Door : WorldObject
{
	public bool IsOpen;
	
	public string NextScene;
	
	public Item.ItemProperty WhatOpensMe;
	
	public GameObject doorCollider;
	
	// Use this for initialization
	void Start ()
	{		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public override Item DoAction ()
	{		
		Item selectedItem = getPlayer().SelectedItem;
		bool playerCanOpenDoor = false;
		
		if(Item.ItemProperty.None == this.WhatOpensMe) {
			playerCanOpenDoor = true;
		} else {
			playerCanOpenDoor = selectedItem != null && getPlayer().SelectedItem.itemProperty == this.WhatOpensMe;
		}
		
		if (playerCanOpenDoor)
		{
			this.IsOpen = true;
			if(this.doorCollider) {
				OpenDoor();
			}
			
			MessageManager.AddMessage("You unlocked me!");
		}
		else
		{
			if(this.description == null || this.description == "") {
				MessageManager.AddMessage("I'm a locked door");
			} else {
				MessageManager.AddMessage(description);
			}
		}
		
		if (this.IsOpen)
		{
			if (!string.IsNullOrEmpty(this.NextScene))
			{
				Application.LoadLevel(this.NextScene);
			}
		}
		
		return null;
	}
	
	public void OpenDoor() {
		this.doorCollider.collider.isTrigger = true;
		this.doorCollider.renderer.enabled = false;
	}
}

