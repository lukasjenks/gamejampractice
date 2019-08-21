using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public string mouseXInputName, mouseYInputName;
	public float mouseSensitivity;
	public Transform playerBody;

	private float xClamp;

	private void cameraRotation() {
		float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

		// prevent player from being able to look up/down further than
		// 90 degrees
		xClamp += mouseY;

		if (xClamp > 90.0f) {
			xClamp = 90.0f;
			mouseY = 0.0f;
		}
		else if (xClamp < -90.0f) {
			xClamp = -90.0f;
			mouseY = 0.0f;
		}

		transform.Rotate(Vector3.left * mouseY);
		playerBody.Rotate(Vector3.up * mouseX);
	}

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;	
		xClamp = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		cameraRotation();
	}
}
