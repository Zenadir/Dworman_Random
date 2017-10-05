using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Gabryel (Gabe) Dworman
/// Purpose: Defines the behavior of any given character
/// Restrictions/Known Bugs: None currently.
/// </summary>
public class CharacterBehavior : MonoBehaviour {

	//Used to position itself on top of the ground automatically. 
	public Terrain objGround;
	public GameObject player;

	void Start () {
		
		//All of the characters should look at the player as they move. 
		player = GameObject.Find ("FPSController");

		//When character is created, change its size to be slightly random and move it to the top of the terrain. 
		StartCoroutine(SetSize ());
		transform.Translate( new Vector3( 0, objGround.SampleHeight (transform.position), 0));
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform);
	}

	/// <summary>
	/// Purpose: Set the width and height of every gameobject to a random value within a guassian distribution.
		/// Do this at a slightly randomized time to reduce the likelyhood of identical characteristics. 
	/// Restrictions/Known Bugs: None currently.
	/// </summary>

	public IEnumerator SetSize(){
		float width = Gaussian (1, .25f);

		transform.localScale = new Vector3 (width, Gaussian (1, .25f), width); 

		//Wait a small random number of milliseconds to make sure the set size is random.
		yield return new WaitForSeconds ( (float) Random.Range(1, 100) * .0001f);

	}


	/// <summary>
	/// Purpose: Generate a number within the parameterized Gaussian Curve and Standard Deviation
	/// Restrictions/Known Bugs: None currently. 
	/// </summary>
	float Gaussian(float mean, float stdDev){

		float val1 = Random.Range (0f, 1f);

		float val2 = Random.Range (0f, 1f);

		float guassValue = Mathf.Sqrt (-2.0f * Mathf.Log(val1)) * Mathf.Sin (2.0f * Mathf.PI * val2);

		return mean + stdDev * guassValue;

	}


}
