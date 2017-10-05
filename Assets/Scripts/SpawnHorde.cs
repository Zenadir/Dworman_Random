using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: Gabryel (Gabe) Dworman
/// Purpose: Generate a number of gameObjects (clone) in a gaussian distribution behind the gameObject that this script is equipped to. 
/// This should be used by the character prefab to create other characters
/// Restrictions/Known Bugs: None currently.
/// </summary>
public class SpawnHorde : MonoBehaviour {

	//Used to instantiate copies of itself (without altered characteristics, to be safe)
	GameObject clone;

	//Stores all of the characters created by multiply
	GameObject[] hordeCharacters;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Puprpose: It takes a gameObject (whatever the script is attatched to) and it copies it a number of times 
	/// according to a non-uniform random probabiliy with a guassian random distribution.
	/// Restrictions/Known Bugs: None at the moment.
	/// </summary>
	public void Multiply(){

		//Sample the current game object to copy.
		//This can't be in start because the script is given to the leaders
		clone = GameObject.Find("Horde");
	
		//Used with non-uniform random to decide how many copies ot make.
		int quanDetermine;

		//The number of characters to spawn. 
		//Initialized to 0 for bugtesting purposes.
		int hordeNumber = 0;

		quanDetermine = Random.Range (1, 11);

		if (quanDetermine <= 5) {

			hordeNumber = 7;

		}

		if (quanDetermine > 5 && quanDetermine <= 8) {
			
			hordeNumber = 9;

		}

		if (quanDetermine > 8) {
			
			hordeNumber = 10;

		} 

		if (hordeNumber == 0) {
			Debug.Log("error, something has gone wrong with the non-uniform random");
		}

		//Create and store a number of clones and move them a distance from the spawner according to the values of a
		//gaussian distribution. 
		hordeCharacters = new GameObject[hordeNumber];

			for (int i = 0; i < hordeNumber; i++) {

			hordeCharacters[i] = Instantiate(clone);

			hordeCharacters[i].transform.position = transform.position;

				hordeCharacters[i].transform.Translate( new Vector3( 0 , 0, Mathf.Abs( Gaussian( 7, 40f) )));

			}
	
	}

	/// <summary>
	/// Purpose: to generate a random number within a gaussian distribution
	/// Restrictions/Known Bugs: None at the moment.
	/// </summary>

	float Gaussian(float mean, float stdDev){

		float val1 = Random.Range (0f, 1f);

		float val2 = Random.Range (0f, 1f);

		float guassValue = Mathf.Sqrt (-2.0f * Mathf.Log(val1)) * Mathf.Sin (2.0f * Mathf.PI * val2);

		return mean + stdDev * guassValue;

	}


}
