/******************************************************
 * 
 * file: KillEnemyScript.cs
 * author: Justin Han
 * class: CS470 Game Development
 * 
 * assignment: Final Project
 * date last modified: 5/23/2017
 * 
 * purpose: If player collides with the enemy, the enemy is destroyed
 ******************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyScript : MonoBehaviour {
	//Method name: OnCollisionEnter
	//purpose: When the player collides with the enemy, kill the enemy
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
