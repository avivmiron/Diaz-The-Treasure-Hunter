/******************************************************
 * 
 * file: Check.cs
 * author: Justin Han
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: This script checks if all the enemy is killed in the maze. If it is, the diamonds appears, else it is gone.
 ******************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {
	GameObject diamond;

	//Method name: Start
	//purpose: Starts when initialized. Initializes the diamond object
	void Start() {
		diamond = GameObject.Find ("diamond");
	}

	//Method name: Update
	//purpose: Keeps checking if the enemies are killed. If they are, the diamond appears, else it is gone.
	void Update() {
		if (GameObject.FindGameObjectWithTag ("Enemy") == null) {
			diamond.SetActive (true);
			(GetComponent("Check") as MonoBehaviour).enabled = false;
		} else {
			diamond.SetActive (false);
		}
	}
}

