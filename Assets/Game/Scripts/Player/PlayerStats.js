// Import
import UnityEngine.SceneManagement;

// Blood textures
var bloodTexture1 : Texture;
var bloodTexture2 : Texture;
var bloodTexture3 : Texture;

// Health
private var startingHealth = 100;
private var currentHealth : float;
private var regenerationSpeed : float = 5;

// Gun damage
private var maximumHitPoints : float = 100;
private var hitPoints : float;

// Sounds
var damageSound : AudioClip;

// Collectables
private var numberOfItemsCollected = 0;

// Variables
private var time : float = 0.0;

// Initialize starting health
function Start() {
	currentHealth = startingHealth;
}

// Apply damage
function ApplyDamage(damageAmount : int) {
	// Reduce current health by the damage amount
	currentHealth -= damageAmount;
	time += damageAmount/7;

	// Play hit sound
	GetComponent.<AudioSource>().PlayOneShot(damageSound, 1.0);

	// Check if player died
	if(currentHealth <= 0) {
		Kill();
	}
}

// Kill the player and transfer to game over scene
function Kill() {
	SceneManager.LoadScene("Gameover");
}

// On awake, reset player's progress
function Awake() {
	GameManager.progress = 0;
}

// Regenerate health
function Update() {
	// Regenerate health only if player has not died and less than full health
	if (currentHealth > 0 && currentHealth < startingHealth) {
		currentHealth += regenerationSpeed * Time.deltaTime;
		if (currentHealth > startingHealth) {
            currentHealth = startingHealth;
        }
	}
}

// Show blood textures when the player is hit
 function OnGUI() {
 	if (currentHealth < 30){
     	GUI.DrawTexture(Rect(0,0,Screen.width,Screen.height), bloodTexture3);
    }
    else if (currentHealth < 70){
     	GUI.DrawTexture(Rect(0,0,Screen.width,Screen.height), bloodTexture2);
    }
    else if (currentHealth < 100){
     	GUI.DrawTexture(Rect(0,0,Screen.width,Screen.height), bloodTexture1);
    }
 }