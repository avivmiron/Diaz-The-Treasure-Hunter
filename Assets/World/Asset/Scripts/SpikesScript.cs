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

public class SpikesScript : MonoBehaviour {
	private Animator animator;
	public AudioSource audio;   
	public AudioClip spikeSound;

	//Method name: Awake
	//purpose: Initialize data when the GameObject is created
	void Awake() {
		animator = GetComponent <Animator> ();
		audio = GetComponent<AudioSource> ();
	}

	//Method name: OnTriggerEnter
	//purpose: When the player steps on the platform of the spike, spike appears and kills the player with a delay
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//If player collides with trap floor, activate spikes
			audio.PlayOneShot(spikeSound,1f);
			animator.SetBool ("Open", true);

			//add 3 second delay before killing player
			StartCoroutine(Delay (.5f, other.gameObject));

		} 
	}

	//Method name: Delay
	//purpose: After a delay, kill the player
	IEnumerator Delay(float delay, GameObject player)
	{
		yield return new WaitForSeconds(delay);
		Destroy (player);
	}

	//Method name: OnTriggerExit
	//purpose: When the player exits the platform of the spike, the spike goes back into the platform.
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player") {
			//if player exits turn off spike
			animator.SetBool ("Open", false);
		}
	}
}
