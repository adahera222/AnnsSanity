using UnityEngine;
using System.Collections;

public class CrazyGuy : WorldObject {
	
	//Script which manages animation
	public GuardCrazyGuy guardCrazyGuy;
	
	public bool IsCrazyMoving;
	bool positive;
	
	public Item.ItemProperty WhatOpensMe;
	
	public Texture chainTexture;
	
	// Use this for initialization
	void Start () {
		this.IsCrazyMoving = true;
		positive = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.IsCrazyMoving)
		{
			float newX = 0;
			float newY = 0;
			
			newX = this.gameObject.transform.position.x + (Random.value * .75f);
			newY = this.gameObject.transform.position.y + (Random.value * .75f);
			
			newX *= positive ? 1 : -1;
			newY *= positive ? 1 : -1;
			
			positive = !positive;
			
			this.gameObject.transform.position = Vector3.Slerp(this.gameObject.transform.position, new Vector3(newX, newY, 0.0f), 1.0f * Time.deltaTime);
		}
	}
	
	public override Item DoAction ()
	{
		Debug.Log("Crazy talk");
		
		Item selectedItem = getPlayer().SelectedItem;
		
		if (selectedItem != null && getPlayer().SelectedItem.itemProperty == this.WhatOpensMe)
		{
			Door crazyDoor = GameObject.FindGameObjectWithTag("CrazyDoor").GetComponent<Door>() as Door;
			
			if (crazyDoor != null)
			{
				Debug.Log("Found door.");
				crazyDoor.IsOpen = true;
				gameObject.renderer.material.mainTexture = chainTexture;
				guardCrazyGuy.enabled = true;
			}
			
			Debug.Log("Can't find door.");
			
			MessageManager.AddMessage("Horray!! sausage links!");
			this.IsCrazyMoving = false;
		}
		else
		{
			int crazyTalk = Mathf.FloorToInt(Random.value * 4);
		
			switch (crazyTalk)
			{
				case 0:
					MessageManager.AddMessage("You know I'm crazy right..");
					break;
				case 1:
					MessageManager.AddMessage("My favorite character is link..");
					break;
				case 2:
					MessageManager.AddMessage("gargle.. gargle..");
					break;
				case 3:
					MessageManager.AddMessage("Hmmm I could go for sausage links..");
					break;
				default:
					MessageManager.AddMessage("Pretty Pretty Butter Flies..");
					break;
			}
		}
		return null;
	}
}
