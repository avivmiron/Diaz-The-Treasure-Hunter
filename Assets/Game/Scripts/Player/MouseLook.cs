/***************************************************************
* file: MouseLook.cs
* author: Aviv Miron, Ofir Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This script governs the mouse look of the first person view.
*
****************************************************************/ 

using UnityEngine;

public class MouseLook : MonoBehaviour {

    // Rotation axes
	public enum RotationAxes { MouseX = 1, MouseY = 2 }
	public RotationAxes axes;

    // Mouse sensitivity
	private float sensitivityX = 5F;
	private float sensitivityY = 5F;

    // Thresholds to reduce minor vibrations
	private float minimumY = -60F;
	private float maximumY = 60F;

    // Initial Y rotation
	private float rotationY = 0F;

    // Update mouse look every frame
	void Update () {
		// Pause
		if (GameManager.isPaused) {
			return;
		}

        // Update X orientation
		if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
        // Update Y orientation
		else {
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}
}