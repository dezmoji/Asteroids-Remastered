using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: Handles the movement of each asteroid
 * */
public class AsteroidMovement : MonoBehaviour 
{
	// vectors need for movement
	private Vector3 direction;
	private Vector3 velocity;
	private Vector3 acceleration;

	// property
	public Vector3 Direction
	{
		get{return direction;}
		set{ direction = value;}
	}

	// Use this for initialization
	void Start () 
	{
		// deterimine a random direction and velocity
		direction = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0);
		velocity = new Vector3 (Random.Range(-1f,1f),Random.Range(-1f,1), 0);
		acceleration = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// normalize direction
		direction.Normalize();

		// find acceleration
		acceleration = direction * 1.1f * Time.deltaTime;

		// add acceleration to velocity
		velocity += acceleration;

		// limit the velocity
		velocity = Vector3.ClampMagnitude (velocity, 2.5f);

		// update the position
		transform.position += velocity * Time.deltaTime;
	}
}
