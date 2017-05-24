/***************************************************************
* file: Shooting.js
* author: Aviv Miron, Ofir Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This class is responsible for controlling the player shooting
* and aiming down sight system. It also keeps track of the user ammo.
*
****************************************************************/ 

// Require the audio component
@script RequireComponent(AudioSource)

// Audio clips
var shotAudio : AudioClip;
var noAmmoAudio : AudioClip;

// Effect when shooting
var Effect : Transform;

// Default damage per shot
private var damage = 100;

// Aim
private var Aim = false;
var Cam : GameObject;
var mask : LayerMask; // Used to disable character from shooting himself. In inspector set mask to default and ignore raycast

// HUD Ammo text
var ammoText : UnityEngine.UI.Text;

// Initialize aim and camera on start
function Start () {
	// Start not aiming
	Aim = false;
	Cam.SetActive(false);

	// Reset ammo count
	GameManager.ammo = 10;
}

// Control the player aiming down the sight, firing, and running
function Update () {
	// Pause
	if (GameManager.isPaused) {
		return;
	}

	// Aiming
	if(Input.GetButton("Aim")){
		Aim = true;
		Cam.SetActive(true);
	}
	else {
		Aim = false;
		Cam.SetActive(false);
	}

	// Stop aim when runnning
	if(Input.GetButton("Run")){
		Aim = false;
		Cam.SetActive(false);
	}

	// Update ammo in HUD
	ammoText.text = "" + GameManager.ammo;

	// Shooting
	if (Input.GetButtonDown("Fire")) {
		if (GameManager.ammo > 0) {
			// Play sound
			GetComponent.<AudioSource>().PlayOneShot(shotAudio, 1.0);

			// Raycast shooting
			var hit : RaycastHit;
			var ray : Ray = Camera.main.ScreenPointToRay(Vector3(Screen.width*0.5, Screen.height*0.5, 0));

			if (Physics.Raycast (ray, hit, 100, mask)) {
				var particleClone = Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(particleClone.gameObject, 0.75);

				// Collision
				if (hit.collider.gameObject.name != "First Person Controller") {
					hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
				}
			}

			// Reduce ammo count
			GameManager.ammo--;
		}
		else {
			// Play no ammo sound
			GetComponent.<AudioSource>().PlayOneShot(noAmmoAudio, 1.0);
		}
	}
}