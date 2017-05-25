/******************************************************
 * 
 * file: LedgeUncouple.cs
 * author: Jason Zhang
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: When a player moves off the moving platform, he should be detached from the moving platform.
 ******************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeUncouple : MonoBehaviour {

	public GameObject ThePlayer;

	//Method name: OnTriggerEnter
	//purpose: When the player moves off the moving platform, he should not move with the moving animation.
	void OnTriggerEnter() {
		var position = ThePlayer.transform.position;
		ThePlayer.transform.parent = null;
		ThePlayer.transform.position = position;
	}
}
