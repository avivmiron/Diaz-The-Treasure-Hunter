/******************************************************
 * 
 * file: SlidingDoorScript.cs
 * author: Justin Han
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: Triggers to open/close the door
 ******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorScript : MonoBehaviour {
	private Animator animator;
	public AudioSource audio;   
	public AudioClip doorOpen;
	public AudioClip doorClose;

	//Method name: Awake
	//purpose: Initialize data when the GameObject is created
	void Awake() {
		animator = GetComponent <Animator> ();
		audio = GetComponent<AudioSource> ();
	}

	//Method name: OnTriggerEnter
	//purpose: When the player gets close to the door, open the door and play sound
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//If player enters open door
			audio.PlayOneShot(doorOpen,1f);
			animator.SetBool ("Open", true);
		} 
	}

	//Method name: OnTriggerExit
	//purpose: When the player gets far from the door, close the door and play sound
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player") {
			//if player exits close door
			animator.SetBool ("Open", false);
			audio.PlayOneShot (doorClose, 1f);
		}
	}
}
