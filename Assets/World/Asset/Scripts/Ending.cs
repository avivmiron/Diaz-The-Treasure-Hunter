/******************************************************
 * 
 * file: Ending.cs
 * author: Justin Han
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: If player collides with the diamond, then the  diamond disappears and opens door
 ******************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

	//Method name: OnCollisionEnter
	//purpose: When the player collides with the diamond, diamond disappears and opens the door
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			GameObject temp = GameObject.Find ("EndingDoor");
			Door other = (Door)temp.GetComponent (typeof(Door));
			other.setComplete ();
			gameObject.SetActive (false);
		}
	}
}
