using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: To make the bullet move in projectile like motion using vectors and rotation*/
public class BulletMovement : MonoBehaviour 
{
	// variables for bullet movement
	private Vector3 direction;
	private Vector3 velocity;
	private Vector3 position;

	// needed ot rotate the sprite
	private float rotation;

	// Use this for initialization
	void Start () 
	{
		// obtain information about the ship
		direction = GameObject.Find("Ship").GetComponent<ShipMovement>().Direction;
		rotation = GameObject.Find ("Ship").GetComponent<ShipMovement>().Rotation;
		velocity = GameObject.Find ("Ship").GetComponent<ShipMovement>().Velocity;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// normalize the direction vector
		direction.Normalize ();

		// get the velocity
		// the velocity is multiplied by 10 so that the bullet doesn't experience a slow acceleration
		velocity += direction * Time.deltaTime * 10;

		// clamp the magnitude
		velocity = Vector3.ClampMagnitude (velocity, 4.5f);

		// add velocity to the transform
		gameObject.transform.position += velocity * Time.deltaTime;

		// rotate the bullet so it points in the same direction as the ship
		transform.rotation = Quaternion.Euler (0, 0, rotation);
	}
}
