using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Author: Dezmon Gilbert
 * Purpose: Handles the spawning of first level asteroids 
 * */
public class FirstLevelSpawn : MonoBehaviour 
{
	// create an array for the different First Level prefabs to be held
	private GameObject[] flPrefabs;
	public GameObject flPrefab1;
	public GameObject flPrefab2;
	public GameObject flPrefab3;

	// GameObject that will be created
	private GameObject flAsteroid;

	// need ship and info to test for collisions
	public GameObject ship;
	private SpriteInfo shipInfo;
	private SpriteInfo asteroidInfo;

	// will hold the position where the asteroid is created
	private Vector3 position;
	
	// Use this for initialization
	void Start () 
	{
		// initialize and set the array
		flPrefabs = new GameObject[3];
		flPrefabs[0]= flPrefab1;
		flPrefabs[1]= flPrefab2;
		flPrefabs[2]= flPrefab3;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	// This will create and return a First Level Asteroid
	public GameObject SpawnFirstLevel()
	{
		// loop to continuously create an asteroid until one is fit enough to be returned
		while(true) 
		{
			// pick a random position for the asteroid
			position = new Vector3 (Random.Range (-9, 9), Random.Range (-9, 9), 0);

			// instaniate a random FL Asteroid
			flAsteroid = (GameObject)Instantiate(flPrefabs[Random.Range(0,3)],position,Quaternion.identity);

			// obtain the information needed to check for collisions
			// this will prevent asteroids from being created directly on top of the ship
			shipInfo = ship.GetComponent<SpriteInfo> ();
			asteroidInfo = flAsteroid.GetComponent<SpriteInfo> ();
			
			// find the distance between the two sprites from their centers
			float distanceSqrd = ((shipInfo.center.x - asteroidInfo.center.x)*(shipInfo.center.x - asteroidInfo.center.x))+
				((shipInfo.center.y - asteroidInfo.center.y) * (shipInfo.center.y - asteroidInfo.center.y));
			
			// add the radii squared together
			float radiusSqrdTotal = shipInfo.radiusSqrd + asteroidInfo.radiusSqrd;

			// if there is a possible collision
			if (distanceSqrd < radiusSqrdTotal) 
			{
				// destroy the asteroid and try again
				Destroy(flAsteroid);
			}

			// no collisions
			else
			{
				// return the created asteroid
				return flAsteroid;
			}
		}
	}



}