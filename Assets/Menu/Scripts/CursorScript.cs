using UnityEngine;

// This class is used to replace the default system cursor with a new one
public class CursorScript : MonoBehaviour {

    // Cursor properties
	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;

    // Change the cursor when the game begins
	void Awake() {
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
	}
}
