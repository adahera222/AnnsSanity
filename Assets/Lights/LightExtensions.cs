using System;
using UnityEngine;
using System.Collections;

public static class LightExtensions  
{
	/// <summary>
	/// Fades to madness.
	/// </summary>
	public static IEnumerator FadeToMadness(this Light newLight, float duration, Action OnComplete)
	{
		//float startBlue = newLight.color.b;
		float newBlue = 1.0f;
		
		//float startGreen = newLight.color.g;
		float newGreen = 1.0f;
		
		while (newLight.color.b >= 0.0f)
		{
			newBlue -= Time.deltaTime * 1.0f/duration;
			newGreen -= Time.deltaTime * 1.0f/duration;
			
			newLight.color = new Color(1.0f, newBlue, newGreen);
			
			yield return null;
			
			if(OnComplete != null)
			{
				OnComplete();
			}
		}
		
	}
	
	/// <summary>
	/// Resets the light to white.
	/// <summary>
	public static void ResetLight(this Light light)
	{
		light.color = new Color(1.0f, 1.0f, 1.0f);
	}
}
