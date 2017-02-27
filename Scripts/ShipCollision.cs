using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: Handles ship vs asteroid collision
 * */
public class ShipCollision : MonoBehaviour 
{
	// stores a ship object
	private GameObject ship;

	// needed for collisions
	private SpriteInfo asteroidInfo;
	private SpriteInfo shipInfo;

	// needed to decrease the life count
	private SceneManager sm;


	// Use this for initialization
	void Start () 
	{
		// find the ship by tag
		ship = GameObject.FindGameObjectWithTag ("Ship");

		// find the SceneManager by tag to get the correct script
		sm = GameObject.FindGameObjectWithTag ("SceneManager").GetComponent<SceneManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		AsteroidShipCollide ();
	}

	// checks for collision between a ship and asteroid
	void AsteroidShipCollide()
	{
		// obtain the information needed for checking bounds
		shipInfo = ship.GetComponent<SpriteInfo> ();
		asteroidInfo = gameObject.GetComponent<SpriteInfo> ();
		
		// find the distance between the two sprites from their centers
		float distanceSqrd = ((shipInfo.center.x - asteroidInfo.center.x)*(shipInfo.center.x - asteroidInfo.center.x))+
			((shipInfo.center.y - asteroidInfo.center.y) * (shipInfo.center.y - asteroidInfo.center.y));
		
		// add the radii squared together
		float radiusSqrdTotal = shipInfo.radiusSqrd + asteroidInfo.radiusSqrd;
		
		// if the distance squared is less than the radius squared, there is a potential collision
		if (distanceSqrd < radiusSqrdTotal) 
		{
			// destroy the asteroid
			Destroy(gameObject);

			// decrease the life total
			sm.Lives--;
		}
	}
}
