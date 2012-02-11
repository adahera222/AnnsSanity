/// <summary>
/// The Loader/Quote screen.
/// </summary>
using UnityEngine;
using System.Collections;

public class QuoteScreen : MonoBehaviour {
	
	//Enum which picks the verse
	public enum Verse{One, Two, Three, Four, Five}
	public Verse verse;
	
	//booleans which track which verse played
	public static bool verseOne;
	static bool verseTwo;
	static bool verseThree;
	static bool verseFour;
	static bool verseFive;
	
	//The Current verse we're displaying
	public GameObject currentVerse;
	
	//Poem objects
	public GameObject poemOne;
	public GameObject poemTwo;
	public GameObject poemThree;
	public GameObject poemFour;
	public GameObject poemFive;
	
	//The current audio piece being played
	public AudioSource currentAudio;
	
	//Audio objects
	public AudioClip clipOne;
	public AudioClip clipTwo;
	public AudioClip clipThree;
	public AudioClip clipFour;
	public AudioClip clipFive;
	
	//the player
	CrazyBastard player;
	//The inventory
	Inventory inventory;
	
	void Start()
	{
		ChooseVerse();
	}
	
	IEnumerator SetUpLevel()
	{
		TimeManagment.isTimePaused = true;
		
		yield return new WaitForSeconds(1.5f);
		try
		{
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<CrazyBastard>();
		}
		catch(System.Exception)
		{
			Debug.LogWarning("Cannot find player");
		}
		
		try
		{
			inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();	
		}
		catch(System.Exception)
		{
			Debug.LogWarning("Cannot find inventory");
		}
		
		if(player)
		player.EnableMove = false;
		
		if(inventory && inventory.ShowInterface)
		{
			inventory.ToggleInterface();
		}
		yield return new WaitForSeconds(animation["QuoteAnimation"].length - 1.75f);
		
		if(player)
		player.EnableMove = true;
		
		TimeManagment.isTimePaused = false;

	}
	
	/// <summary>
	/// Chooses the proper verse
	/// </summary>
	void ChooseVerse()
	{
		switch(verse)
		{
			
		case Verse.One:
			if(!verseOne)
			{
				currentVerse.renderer.material.mainTexture = poemOne.renderer.material.mainTexture;
				currentAudio.clip = clipOne;
				verseOne = true;
				PlayQuote();
				StartCoroutine(SetUpLevel());
				break;
			}
			else
			{
				goto default;
			}
			
		case Verse.Two:
			if(!verseTwo)
			{
				currentVerse.renderer.material.mainTexture = poemTwo.renderer.material.mainTexture;
				currentAudio.clip = clipTwo;
				verseTwo = true;
				PlayQuote();
				StartCoroutine(SetUpLevel());
				break;
			}
			else
			{
				goto default;
			}
			
		case Verse.Three:
			if(!verseThree)
			{
				currentVerse.renderer.material.mainTexture = poemThree.renderer.material.mainTexture;
				currentAudio.clip = clipThree;
				verseThree = true;
				PlayQuote();
				StartCoroutine(SetUpLevel());
				break;
			}
			else
			{
				goto default;
			}
			
		case Verse.Four:
			if(!verseFour)
			{
				currentVerse.renderer.material.mainTexture = poemFour.renderer.material.mainTexture;
				currentAudio.clip = clipFour;
				verseFour = true;
				PlayQuote();
				StartCoroutine(SetUpLevel());
				break;
			}
			else
			{
				goto default;
			}
			
		case Verse.Five:
			if(!verseFive)
			{
				currentVerse.renderer.material.mainTexture = poemFive.renderer.material.mainTexture;
				currentAudio.clip = clipFive;
				verseFive = true;
				PlayQuote();
				StartCoroutine(SetUpLevel());
				break;
			}
			else
			{
				goto default;
			}

		default:
			currentVerse.renderer.enabled = false;
			gameObject.renderer.enabled = false;
			break;
			
		}
	}
	
	/// <summary>
	/// Plays the quote and voice over
	/// </summary>
	void PlayQuote()
	{
		animation.Play();
		currentAudio.Play();
	}
	
	
}
