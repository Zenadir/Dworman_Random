using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Gabryel (Gabe) Dworman
/// Purpose: Spawns a number of random characters across a terrain
/// Restrictions/Known Bugs: Set maxCharacters to a reasonable number: Not 1,000,000 or anything remotely close.
/// </summary>
public class SpawnRandomCharacters : MonoBehaviour {

	public GameObject character;

	//Each object is passed a terrain so that they can adjust their vertical position to match the ground. 
	public Terrain ground;

	GameObject[] characterArray;

	public int maxCharacters = 40;

	// Use this for initialization
	void Start () {

		//Create a number of character objects, set their position using a random number within the range of the terrain that they are assigned to.
		//Give each object their terrain
		characterArray= new GameObject[maxCharacters];
		for (int i = 0; i < maxCharacters; i++) {
			characterArray [i] = Instantiate (character);
			characterArray [i].transform.position = new Vector3 (Random.Range (1, ground.terrainData.size.x - 1), 0,  Random.Range (1, ground.terrainData.size.z - 1));
			characterArray [i].GetComponent<CharacterBehavior>().objGround = ground;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
