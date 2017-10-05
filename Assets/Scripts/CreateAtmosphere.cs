using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Gabryel (Gabe) Dworman
/// Purpose: To impelement elements of gameplay (light and sound) that create immersion in the simulation.
/// Restrictions/Known Bugs: It's probably a bad idea to jump off the world and wait for too long with the
/// first person controller in play because its speed will incrase over time and this might cause unity to crash.
/// </summary>
public class CreateAtmosphere : MonoBehaviour {


	AudioSource music;

	Vector3 lastPosition;

	public Light globalLight;

	public Matrix4x4 inverseProjectionMatrix;
	public Camera PlayerCamera;
	// Use this for initialization
	void Start () {
		//Make sure lastPosition isnt null;
		lastPosition = transform.position;
			music = gameObject.GetComponent<AudioSource>();

		//Invert the projection matrix of the first person character
		inverseProjectionMatrix = PlayerCamera.projectionMatrix.inverse;

	}
	
	// Update is called once per frame
	void Update () {


		//Change the pitch of the music depending on the change in location / rotation since the last frame. 
		music.pitch = .95f + (transform.position - lastPosition).magnitude*.1f;
		lastPosition = transform.position;

		//Change the lighting of the scene depending on pitch of the music
		globalLight.intensity = Mathf.Pow (music.pitch, 1.5f);
		globalLight.colorTemperature =  Mathf.Pow (music.pitch, 1.5f);

		//If the player tries running with shift, distort the screen (so that they really feel like Sonic).
		if ( (Input.GetKey(KeyCode.LeftShift) ||Input.GetKey(KeyCode.RightShift) )&& Input.GetKey(KeyCode.W)) {
			PlayerCamera.projectionMatrix = inverseProjectionMatrix;
		} else {
			PlayerCamera.ResetProjectionMatrix ();
		}
	}
}
