using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Gabryel (Gabe) Dworman
/// Purpose: To switch between any number of cameras in the scene
/// Restrictions/Known Bugs: It is probably a good idea to make sure that all the cameras in the scene are either in the array or not active.
	///This can cause the script to malfunction. 
/// </summary>
public class CameraManager : MonoBehaviour {

	//Camera array that holds a reference to every camera in the scene
	public Camera[] cameras;

	//Current Camera
	private int currentCameraIndex;

	// Use this for initialization
	void Start () {

		currentCameraIndex = 0;

		//Turn all cameras off (and their audio listeners, to be safe), except the first default one
		for (int i = 1; i < cameras.Length; i++) {
			cameras [i].gameObject.SetActive (false);
			cameras [i].GetComponent<AudioListener>().enabled = false;
		}

		//If any cameras were added to the controller, enable the first one and its audio listener.
		if (cameras.Length > 0) {
			cameras [0].gameObject.SetActive (true);
			cameras [0].GetComponent<AudioListener>().enabled = true;
		}
		
	}



	// Update is called once per frame
	void Update () {

		//If the user presses C, switch cameras, and turn the last camera off.
		if (Input.GetKeyDown (KeyCode.C)) {

			currentCameraIndex++;

			//If this camera is not the last, switch to the next camera in the arra.
			if (currentCameraIndex < cameras.Length) {
				cameras [currentCameraIndex - 1].gameObject.SetActive(false);
				cameras [currentCameraIndex].gameObject.SetActive (true);

				cameras [currentCameraIndex - 1].GetComponent<AudioListener> ().enabled = false;
				cameras [currentCameraIndex].GetComponent<AudioListener> ().enabled = true;

			}
			//If this camera is the last, switch back to the first
			else {

				cameras [currentCameraIndex - 1].gameObject.SetActive (false);
				cameras [currentCameraIndex - 1].GetComponent<AudioListener> ().enabled = false;

				currentCameraIndex = 0;

				cameras [currentCameraIndex].gameObject.SetActive (true);
				cameras [currentCameraIndex].GetComponent<AudioListener> ().enabled = true;
			}

		} 
			
	}

	//Give the user some instructions on how to switch cameras and tell them the current camera. 
	void OnGUI(){
		GUI.Box (new Rect (Screen.width / 8, Screen.height / 8,  200,100), "Press the 'c' button to \n switch between camera views.\n The current camera view is: \n" + cameras [currentCameraIndex].name);
	}
}
