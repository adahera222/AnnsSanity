/// <summary>
/// Simple Title Screen
/// </summary>
using UnityEngine;
using System;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	public GameObject fadeScreen;
	
	public bool canStart;
	
	public GameObject titleQuote;
	
	IEnumerator Start()
	{
		titleQuote.renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
		yield return new WaitForSeconds(1.0f);
		Debug.Log("DoStuff");
		StartCoroutine(FadeTextureOut(fadeScreen, 3.0f, () => 
		{
			StartCoroutine(EnableStart());
		}));
	}
	
	void Update()
	{
		if(Input.anyKeyDown  && canStart)
		{
			canStart = false;
			Debug.Log("Clicked Something");
			StartCoroutine(FadeTextureIn(fadeScreen, 2.0f, () => 
			{
				StartCoroutine(ShowHideQuote());
			}));
		}
	}
	
	IEnumerator EnableStart()
	{
		yield return new WaitForSeconds(3.0f);
		canStart = true;
	}
	
	/// <summary>
	/// Shows and hides the quote.
	/// </summary>
	IEnumerator ShowHideQuote()
	{
		yield return new WaitForSeconds(3.0f);
		StartCoroutine(FadeTextureIn(titleQuote, 3.0f, null));
		yield return new WaitForSeconds(1.5f);
		StartCoroutine(FadeTextureOut(titleQuote, 2.0f, null));
		yield return new WaitForSeconds(4.0f);
		Application.LoadLevel("AnnasRoom");
	}
	
	/// <summary>
	/// Fades a texture in.
	/// </summary>
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
	
	/// <summary>
	/// Fades the texture out.
	/// </summary>
	/// <returns>
	public IEnumerator FadeTextureOut(GameObject texture, float duration, Action OnComplete)
	{
		float screenAlpha = 1.0f;
		
		while (texture.renderer.material.color.a > 0.0f)
		{
			screenAlpha -= Time.deltaTime * 1.0f/duration;
			texture.renderer.material.color = new Color(1.0f, 1.0f, 1.0f, screenAlpha);
			yield return null;
			
			if(OnComplete != null)
			{
				OnComplete();
			}
		}
	}
}
