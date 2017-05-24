/******************************************************
 * 
 * file: Door.cs
 * author: Justin Han
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: If the player picks up the diamond the door opens.
 ******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	private int complete;
	private Animator animator;
	public AudioSource audio;   
	public AudioClip doorOpen;
	public AudioClip doorClose;

	//Method name: Start
	//purpose: Initialize date
	void Start() {
		animator = GetComponent <Animator> ();
		audio = GetComponent<AudioSource> ();
		complete = 0;
	}

	//Method name: OnTriggerEnter
	//purpose: When a player exits, the door closes and plays a sound
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player" && complete == 1) {
			//if player exits close door
			animator.SetInteger("Complete", 2);
			audio.PlayOneShot (doorClose, 1f);
			complete = 2;
		}
	}

	//Method name: setComplete()
	//purpose: This script means that the diamond is collected, so the door opens with a sound.
	public void setComplete() {
		complete = 1;
		audio.PlayOneShot(doorOpen,1f);
		animator.SetInteger ("Complete", 1);
	}
}
