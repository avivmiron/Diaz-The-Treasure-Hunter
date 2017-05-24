/******************************************************
 * 
 * file: DoorScript.cs
 * author: Ubaldo Jimenez Prieto
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: This script purpose is control when to open or close the door 
 * for the first stage room. It also plays soundeffects when appropiate. 
 ******************************************************/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	private Animator animator;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Method name: OnTriggerEnter
	//purpose: When the player enters the collider dimensions this method is 
	//is triggered. The door opens.
	void OnTriggerEnter(Collider Other)
	{
		if (Other.tag == "Player") {
			animator.SetBool ("Open", true);
			animator.SetBool ("Close", false);
		} 
	}

	//Method name: OnTriggerExxit
	//purpose: When the player exits the collider dimensions this method is 
	//is triggered. The door closes. 
	void OnTriggerExit(Collider Other)
	{
		if (Other.tag == "Player") {
					
			animator.SetBool ("Open", false);
			animator.SetBool ("Close", true);
		} 
	}

	//Method name: playSound
	//purpose: Everytime the door animates it, it plays a sound effect
	void PlaySound()
	{
		audioSource.Play ();
	}
}
