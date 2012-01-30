/// <summary>
/// Game light script
/// </summary>
using UnityEngine;
using System.Collections;

public class GameLight : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(this);
	}
}
