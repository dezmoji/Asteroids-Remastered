using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: To hold the methods needed for collision
 * */
public class CollisionDetection : MonoBehaviour 
{
	// needed to obtain info about the sprites needed for bounds
	private SpriteInfo shipInfo;
	private SpriteInfo asteroidInfo;
	private SpriteInfo bulletInfo;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// check for bullet and asteroid collision
	// uses bounding circle and point-to-shape
	public bool BulletCollision(GameObject bullet, GameObject asteroid)
	{
		bulletInfo = bullet.GetComponent<SpriteInfo> ();
		asteroidInfo = asteroid.GetComponent<SpriteInfo> ();

		// find the distance between the two sprites from their centers
		float distanceSqrd = ((bulletInfo.center.x - asteroidInfo.center.x)*(bulletInfo.center.x - asteroidInfo.center.x))+
			((bulletInfo.center.y - asteroidInfo.center.y) * (bulletInfo.center.y - asteroidInfo.center.y));

		// add the radii squared together
		float radiusSqrdTotal = bulletInfo.radiusSqrd + asteroidInfo.radiusSqrd;

		//
		if (distanceSqrd < radiusSqrdTotal) 
		{
			// potential collision
			return true;
		}

		// no collision
		return false;
	}	
}
