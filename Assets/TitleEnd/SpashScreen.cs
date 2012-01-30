using UnityEngine;
using System.Collections;

public class SpashScreen : MonoBehaviour {
	
	public string level;
	
	public GameObject currentScreen;
	
	//Sponser Screens
	public Texture screenOne;
	public Texture screenTwo;
	public Texture screenThree;
	
	public float waitTime;
	
	IEnumerator Start()
	{
		currentScreen.renderer.material.mainTexture = screenOne;
		yield return new WaitForSeconds(waitTime);
		currentScreen.renderer.material.mainTexture = screenTwo;
		yield return new WaitForSeconds(waitTime);
		currentScreen.renderer.material.mainTexture = screenThree;
		
		yield return new WaitForSeconds(.75f);
		
		Application.LoadLevel(level);
	}
}
