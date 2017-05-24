/***************************************************************
* file: PlayerMovement.js
* author: Aviv Miron, Ofir Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This class is responsible for the player movement,
* including running and jumping.
*
****************************************************************/ 

// Default movement constants
private var walkSpeed = 12.0;
private var runSpeed = 18.0;
private var jumpSpeed = 20.0;
private var gravity = 50.0;

// Movememnt
private var moveDirection = Vector3.zero;
private var grounded = false;
private var controller : CharacterController;
private var myTransform : Transform;
private var speed : float;
 
 // Initialize the movement controller
function Start () {
	controller = GetComponent(CharacterController);
	myTransform = transform;
	speed = walkSpeed;
}
 
 // Update the movement speed and direction every frame
function FixedUpdate() { 
	if (grounded) {
		// Input
		var inputX = Input.GetAxis("Horizontal");
		var inputY = Input.GetAxis("Vertical");
		var inputModifyFactor = (inputX != 0.0 && inputY != 0.0)? .7071 : 1.0;

		// Movement speed
		if (Input.GetButton("Run"))
		{
			speed = runSpeed;
		}
		else {
			speed = walkSpeed;
		}

		// Move player
		moveDirection = Vector3(inputX * inputModifyFactor, 0, inputY * inputModifyFactor);
		moveDirection = myTransform.TransformDirection(moveDirection) * speed;

		// Jump
		if (Input.GetButton("Jump")){
			moveDirection.y = jumpSpeed;
		}
	}

	// Apply gravity
	moveDirection.y -= gravity * Time.deltaTime;
 
	// Move the controller, and set grounded true or false depending on whether we're standing on something
	grounded = (controller.Move(moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
}