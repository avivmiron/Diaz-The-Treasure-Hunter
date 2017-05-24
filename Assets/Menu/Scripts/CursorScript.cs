/***************************************************************
* file: CursorScript.cs
* author: Ofir Miron, Aviv Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This class is used to replace the default system cursor
*
****************************************************************/ 

using UnityEngine;

public class CursorScript : MonoBehaviour {

    // Cursor properties
	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;

    // Change the cursor when the game begins
	void Awake() {
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
	}
}
