using UnityEngine;
using UnityEngine.SceneManagement;

// This is a script that controls the menu screen.
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
		SceneManager.LoadScene ("Game");
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
