/******************************************************
 * 
 * file: Diamond.cs
 * author: Justin Han
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: If player collides with the diamond, then the  diamond disappears
 ******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

	//Method name: OnCollisionEnter
	//purpose: When a player collides with the diamond, the diamond disappears.
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			gameObject.SetActive (false);
		}
	}
}
