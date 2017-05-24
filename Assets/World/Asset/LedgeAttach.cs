/******************************************************
 * 
 * file: LedgeAttach.cs
 * author: Jason Zhang
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: When the player moves onto the moving platform, it should attach him to that platform.
 ******************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeAttach : MonoBehaviour {

	public GameObject TheLedge;
	public GameObject ThePlayer;

	//Method name: OnTriggerEnter
	//purpose: When the player moves onto moving platform, he should move along with the animation.
	void OnTriggerEnter() {
		ThePlayer.transform.parent = TheLedge.transform;

	}
}
