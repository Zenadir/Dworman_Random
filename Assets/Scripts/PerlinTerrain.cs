using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
	/// Author: Gabryel Dworman
    /// Purpose: Modify a terrain using perlin noise and random values
	/// Restrictions / Known Errors: None are known currently.
/// </summary>
public class PerlinTerrain : MonoBehaviour {

	//The resolution for the terrain
	int resolution = 129;

	TerrainData landData;

	//Used to store the data from perlin noise
	float[,] terrainHeights;

	Vector3 terrainSize = new Vector3(200,50,200);

	//Generate perlin noise values, initialize an array to hold them, 
	//Set the value of the heights of the terrain according to the perlin values, and the size of the world according to terrainSize.
	void Start () {

		landData = gameObject.GetComponent<TerrainCollider>().terrainData;

		float perlinRandomizer = 3 *.0045f;
			
		terrainHeights = new float[resolution, resolution];


		landData.heightmapResolution = resolution;



		for (int i = 0; i < resolution; i++) {

			for (int j = 0; j < resolution; j++) {

					terrainHeights [i, j] = Mathf.PerlinNoise ( i * perlinRandomizer, j * perlinRandomizer );

			}

		}

		landData.SetHeights( 0, 0, terrainHeights);

		landData.size = terrainSize;

	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
