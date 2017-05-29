/***************************************************************
* file: EnemyAI.js
* author: Aviv Miron, Ofir Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This is a script that controls the A.I. behaivor of the enemies.
*
****************************************************************/ 

// Controllers
var target : Transform;
var controller : CharacterController;

// Damage and health
private var health = 300;
private var damage = 40;
private var attackRepeatTime = 1.5;

// Distances and speed
public var lookAtDistance = 25.0;
public var chaseRange = 20.0;
private var attackRange = 2.5;
private var moveSpeed = 10.0;
private var damping = 6.0;

// Other
private var gravity : float = 20.0;

// Variables
private var distance;
private var isDead = false;
private var attackTime : float;
private var MoveDirection : Vector3 = Vector3.zero;
private var currentAnimation = "";

// Set the attack time to current time
function Start() {
	attackTime = Time.time;
}

// Update the enemy every frame
function Update() {
	// React as long as enemy is not dead
	if(!isDead) {
		// Get distance from enemy to player
		distance = Vector3.Distance(target.position, transform.position);

		// Look at the player if close enough
		if (distance < lookAtDistance) {
			LookAt();
		}

		// Attack player if close enough
		if (distance < attackRange) {
			Attack();
		}

		// Chase player if close enough
		else if (distance < chaseRange) {
			Chase();
		}

		// Otherwise idle
		else {
			Idle();
		}
	}
}

// Change the rotation of the enemy to look at the player
function LookAt() {
	var rotation = Quaternion.LookRotation(target.position - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
}

// Make the enemy attack the player
function Attack() {
	// Animate enemy
	if (currentAnimation != "attack") {
		currentAnimation = "attack";
    	gameObject.GetComponent("EnemyAnimationController").AttackAnimation();
    }

    // Attack the player, respecting the attack time cooldown
	if (Time.time > attackTime) {
		// Send apply damage message
		target.SendMessage("ApplyDamage", damage);
		attackTime = Time.time + attackRepeatTime;
	}
}

// Make the enemy chase the player
function Chase() {	
	// Animate enemy
	if (currentAnimation != "fly" && currentAnimation != "hit") {
		currentAnimation = "fly";
		gameObject.GetComponent("EnemyAnimationController").FlyAnimation();
    }

    // Change direct and move
	moveDirection = transform.forward;
	moveDirection *= moveSpeed;
	controller.Move(moveDirection * Time.deltaTime);
}

// Make the enemy have idle animation
function Idle() {
	// Animate enemy
	if (currentAnimation != "idle") {
		currentAnimation = "idle";
		gameObject.GetComponent("EnemyAnimationController").IdleAnimation();
    }
}

// Apply damage to the enemy
function ApplyDamage(damage : int) {
	// Make sure that the enemy is still alive
	if(!isDead) {
		// Reduce health
		health -= damage;

		// Check if enemy was killed
		if(health <= 0) {
			Kill();
			return;
		}

		// Show hit animation
		currentAnimation = "hit";
		gameObject.GetComponent("EnemyAnimationController").HitAnimation();

		// Increase ranges and movement speed after each hit
		lookAtDistance += 40;
		chaseRange += 30;

		// Yield the enemy for 1 second
		yield WaitForSeconds(1.0);

		// Reset current animation
		currentAnimation = "";
	}
}

// Kill the enemy
function Kill() {
	// Make sure enemy is alive
	if (!isDead){
		isDead = true;

		// Animate
		gameObject.GetComponent("EnemyAnimationController").DieAnimation();
		(gameObject.GetComponent(Rigidbody) as Rigidbody).isKinematic = false;
		Destroy(gameObject, 60.0);
	}
}