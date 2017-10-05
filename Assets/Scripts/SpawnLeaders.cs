using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Gabryel (Gabe) Dworman
/// Purpose: Spawn a number of character objects (leaders) in semi-randomized line.
/// Leaders make copies of themselves using the SpawnHorde script
/// Restrictions/Known Bugs: None currently. 
/// </summary>
public class SpawnLeaders : MonoBehaviour {

	public int maxLeaders= 10;

	//The object used by the scripted gameObject to spawn.
	public GameObject cloneObject;

	GameObject[] leaders;

	//used by the leaders to share the terrain with the copies they create using the SpawnHorde script's multiply method.
	public Terrain ground;


	//Spawn a number of leaders at different times (to preserve unique randomness).
	void Start () {

		leaders = new GameObject[maxLeaders];

		for (int i = 0; i < maxLeaders; i++) {

			StartCoroutine (SpawnLeader(i));
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/// <summary>
	/// Purpose: Creates a number of leader objects, gives them SpawnHorde scripts and calls SpawnHorde.Multiply to spawn more gameobjects (the horde) behind them.
	/// Restrictions/Known Bugs: Don't set maxLeaders to 0 or a negative number in the inspector: the method wont work.
	/// </summary>
	IEnumerator SpawnLeader(int index)
	{

		//This try is used mostly to catch indexes of 0 or less, good for bugtesting
		try {


			
			leaders [index] = Instantiate(cloneObject);

			//If a leader has been made already, create a leader at a distance remotely aligned with the last leader. 
			try{

				leaders [index].transform.position = new Vector3 (leaders [index - 1].transform.position.x  + Random.Range (5f, 7f), leaders [index - 1].transform.position.y , leaders [index-1].transform.position.z + Random.Range(-3f, 4f));

			}

			//If a leader hasn't been made, create a leader at the position of the gameobject using this script (the spawner).
			catch{

				leaders [index].transform.position = transform.position;

			}


			//Give each leader the terrain so it can put itself on top of the ground.
			leaders [index].GetComponent<CharacterBehavior> ().objGround = ground; 



			//Give each leader a SpawnHorde script so that it can copy itself and make it copy itself. 
			leaders [index].AddComponent<SpawnHorde> ();
			leaders [index].GetComponent<SpawnHorde>().Multiply();


		} catch (System.Exception ex) {

			Debug.Log (ex.Message);
		}
		


		//Wait until the end of the frame to ensure propper randomization. 
		yield return new WaitForEndOfFrame ();

	}


}
