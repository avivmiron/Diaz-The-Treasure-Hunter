/***************************************************************
* file: PauseMenu.cs
* author: Ofir Miron, Aviv Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This script controls the pause menu,
* and stops the game from running until it is resumed.
*
****************************************************************/ 

using UnityEngine;

public class PauseMenu : MonoBehaviour {

    // Pause canvas
    public Canvas canvas;
	
    // Initialize the pause menu
	private void Start () {
        // Initialized paused state
		GameManager.isPaused = false;

        // Disable canvas
        canvas.enabled = false;

        // Hide cursor and lock it in the screen.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Listen for the ESC key
	private void Update () {
        // Pause the game
		if (!GameManager.isPaused && Input.GetButtonDown ("Cancel")) {
			pause ();
		}
        // Resume the game
		else if (GameManager.isPaused && (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Fire"))) {
			resume ();
		}
    }

    // Pause the game and show cursor and canvas
	private void pause() {
		// Toggle isPaused
		GameManager.isPaused = true;

		// Show cursor
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;

		// Show canvas
		canvas.enabled = true;

		// Stop time
		Time.timeScale = 0;
	}

    // Resume the game and hide cursor and canvas
	private void resume() {
		// Toggle isPaused
		GameManager.isPaused = false;

		// Resume time
		Time.timeScale = 1;

		// Hide cursor
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		// Show canvas
		canvas.enabled = false;
	}
}
