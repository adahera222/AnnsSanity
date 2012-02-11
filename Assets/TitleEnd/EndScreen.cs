/// <summary>
/// End screen.
/// </summary>
using UnityEngine;
using System;
using System.Collections;

public class EndScreen : MonoBehaviour {
	
	public AudioSource endMusic;
	public QuoteScreen quoteScreen;
	
	public GameObject credits;
	
	
	
	// Use this for initialization
	IEnumerator Start () 
	{
		
		TimeManagment.isTimePaused = true;
		
		StartCoroutine(endMusic.FadeIn(endMusic.clip, 2.0f, null));
		QuoteScreen.verseOne = false;
		
		yield return new WaitForSeconds(1.0f);
		
		quoteScreen.enabled = true;
		
		yield return new WaitForSeconds(10.0f);
		
		StartCoroutine(FadeTextureIn(credits, 1.0f, null));
		
		yield return new WaitForSeconds(50);
		
		StartCoroutine(endMusic.FadeOut(endMusic.clip, 1.0f, null));
		
		Application.Quit();
		
	}
	
	void DestroyAnna()
	{
		try
		{
			CrazyBastard player = GameObject.FindGameObjectWithTag("Player").GetComponent<CrazyBastard>();
			Destroy(player.gameObject);
		}
		catch(System.Exception)
		{
			Debug.LogWarning("Cannot find player");
		}
	}
	
	public IEnumerator FadeTextureIn(GameObject texture, float duration, Action OnComplete)
	{
		float screenAlpha = 0.0f;
		
		while (texture.renderer.material.color.a < 1.0f)
		{
			screenAlpha += Time.deltaTime * 1.0f/duration;
			texture.renderer.material.color = new Color(1.0f, 1.0f, 1.0f, screenAlpha);
			yield return null;
			
			if(OnComplete != null)
			{
				OnComplete();
			}
		}
		
	}
	

}
