using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This is a script that controls the gameover screen. It shows the correct achievement after the user loses/wins
public class Gameover : MonoBehaviour {

    // UI elements
	public Text title;
	public RawImage image;
	public Texture bronzeMedal;
	public Texture silverMedal;
	public Texture goldMedal;

	// Disable all other canvases when the scene shows
	void Awake() {
        // Show the cursor
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;

        // Show progress
		if (GameManager.progress == 0) {
			title.text = "Game Over";
			image.enabled = false;
		}
        else if (GameManager.progress == 1) {
			title.text = "You received a Bronze Medal";
			image.texture = bronzeMedal;
		}
        else if (GameManager.progress == 2) {
			title.text = "You received a Silver Medal";
			image.texture = silverMedal;
		}
        else if (GameManager.progress == 3) {
			title.text = "You received a Gold Medal";
			image.texture = goldMedal;
		}
	}

    // Player presses retry button
	public void RetryOn() {
		SceneManager.LoadScene ("World");
	}

    // Player presses meny button
	public void MenuOn() {
		SceneManager.LoadScene ("Menu");
	}
}
