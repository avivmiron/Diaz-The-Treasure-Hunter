// Gun movment
private var MoveAmount : float = 1;
private var MoveSpeed : float = 2;
private var MoveOnX : float;
private var MoveOnY : float;
private var DefaultPos : Vector3;
private var NewGunPos : Vector3;

// Character movement
private var movingForward = false;

// Initialization
function Start() {
	// Save default gun position. Used to calculate gun movment.
	DefaultPos = transform.localPosition;
}

// Update gun movement and animation every frame
function Update () {
	// Pause
	if (GameManager.isPaused) {
		return;
	}

	// Move gun based on mouse movment
	MoveOnX = Input.GetAxis( "Mouse X" ) *Time.deltaTime * MoveAmount;
	MoveOnY = Input.GetAxis( "Mouse Y" ) *Time.deltaTime * MoveAmount;
	NewGunPos = new Vector3 ( DefaultPos.x+ MoveOnX, DefaultPos.y+ MoveOnY, DefaultPos.z);
	GetComponent(Transform).localPosition = Vector3.Lerp(GetComponent(Transform).localPosition, NewGunPos , MoveSpeed * Time.deltaTime);

	// Gun animations:
	// Play fire animation when shooting
	if(Input.GetButtonDown("Fire") && GameManager.ammo > 0) {
	  GetComponent.<Animation>().Play("Fire", PlayMode.StopAll);
 	}

 	// Play sprint animation when player starts running
	else if(Input.GetButtonDown("Run") && movingForward) {
	  	GetComponent.<Animation>().Play("Sprint", PlayMode.StopAll);
	}

	// Play jump animation when player jumps
	else if(Input.GetButtonDown("Jump")) {
	  GetComponent.<Animation>().Play("Jump", PlayMode.StopAll);
	}

 	// Play walking animation when character starts walking
	else if(!movingForward && Input.GetAxis("Vertical") >= 0.5) {
		movingForward = true;
	 	GetComponent.<Animation>().Play("Walk", PlayMode.StopAll);
	}

	// Play idle animation when player stops moving
	else if(movingForward && Input.GetAxis("Vertical") < 0.5) {
		movingForward = false;
		GetComponent.<Animation>().Play("Idle", PlayMode.StopAll);
	}

	// Play idle animation when player stops running
	else if(Input.GetButtonUp("Run")) {
		GetComponent.<Animation>().Play("Idle", PlayMode.StopAll);
	}
}