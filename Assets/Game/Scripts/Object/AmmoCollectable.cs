/***************************************************************
* file: AmmoCollectable.cs
* author: Aviv Miron, Ofir Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This script governs how ammo boxes work.
* It adds the player more ammo once he/she collides with the ammo box.
*
****************************************************************/ 

using UnityEngine;

public class AmmoCollectable : MonoBehaviour {

    // Speed of rotation of the ammo box
	private float speed = 1;
	private Quaternion rotation;

    // Audio and target
	public Transform target;
	public AudioClip collectAudioClip;

	// Initialize the rotation of the ammo box
	void Start () {
		rotation = transform.rotation;
	}

	// Rotate the ammo box
	void Update () {
		rotation *=  Quaternion.AngleAxis(speed, Vector3.back);
		transform.rotation= Quaternion.Lerp (transform.rotation, rotation , 10 * Time.deltaTime); 
	}

    // User collides with the ammo box, add more ammo to the user and destroy the object
	void OnTriggerEnter(Collider col) {
		if (col.gameObject == target.gameObject) {
			target.GetComponent<AudioSource> ().PlayOneShot(collectAudioClip);
			GameManager.ammo += 10;
			Destroy(gameObject);
		}
	}
}
