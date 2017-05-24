/***************************************************************
* file: Menu.cs
* author: Ofir Miron, Aviv Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This is a script that controls the menu screen and transitions
* to the about screen, how to play screen, and game.
*
****************************************************************/ 

using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    // UI elements
	public Canvas MainCanvas;
	public Canvas AboutCanvas;
	public Canvas HowCanvas;

	// Devil
	public GameObject devilGameObject;


	// Setup menus during initialization
	void Awake() {
        // Show cursor
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;

        // Disable all other canvases when the scene shows
        AboutCanvas.enabled = false;
		HowCanvas.enabled = false;
	}

    // Player starts game
	public void StartOn() {
		SceneManager.LoadScene ("World");
	}

    // Player presses about button
	public void AboutOn() {
		MainCanvas.enabled = false;
		AboutCanvas.enabled = true;
		HowCanvas.enabled = false;
	}

    // Player presses how to play button
	public void HowOn() {
		devilGameObject.SetActive(false);
		MainCanvas.enabled = false;
		AboutCanvas.enabled = false;
		HowCanvas.enabled = true;
	}

    // Player presses back button
	public void BackOn() {
		devilGameObject.SetActive(true);
		MainCanvas.enabled = true;
		AboutCanvas.enabled = false;
		HowCanvas.enabled = false;
	}

    // Player presses exit button
	public void ExitOn() {
		Application.Quit();
	}
}
