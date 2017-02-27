using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: This handles the movement of the ship including acceleration, deceleration, and rotation
 * */

public class ShipMovement : MonoBehaviour 
{
	// create the vectors that will be used for movement
	private Vector3 position;
	private Vector3 direction;
	private Vector3 velocity;
	private Vector3 acceleration;

	// will be used to for movement
	private float accelRate = 2.3f;
	private float decelRate = .95f;

	// will be used for rotation
	private float rotation = 0;
	private float angle = 2f;

	// Getting the camera for wrapping
	public Camera cam;
	float camSize;

	//properties
	public Vector3 Direction
	{
		get{ return direction;}
	}

	public Vector3 Velocity
	{
		get{ return velocity;}
	}

	//property
	public float Rotation
	{
		get{ return rotation;}
	}
		
	// Use this for initialization
	void Start () 
	{
		// get the size of the camera
		camSize = cam.orthographicSize;

		// initialize the vectors
		position = new Vector3 (0, 0, 0);
		direction = new Vector3 (0, 1, 0); // points up
		velocity = new Vector3 (0, 0, 0);
		acceleration = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangePosition ();
		RotateShip ();
		ScreenWrap ();
		UpdateTransform ();
	}

	// will change the position of the ship via acceleration and deceleration
	void ChangePosition()
	{
		// while the up arrow is being pressed, acceleration occurs
		if (Input.GetKey (KeyCode.UpArrow))
		{
			// normalize the direction
			direction.Normalize();

			// find acceleration
			acceleration = direction * accelRate * Time.deltaTime;

			// add acceleration to velocity
			velocity += acceleration;

			// limit the velocity
			velocity = Vector3.ClampMagnitude (velocity, 5f);
		}

		// deceleration occurs when the up arrow is released
		else 
		{
			// decelerate
			velocity *= decelRate;

			// once the velocity reaches 0
			if(velocity.sqrMagnitude < 0.0001f)
			{
				// set the velocity to 0
				velocity = Vector3.ClampMagnitude(velocity,0);
			}
		}

		// add velocity to position
		position += velocity * Time.deltaTime;
	}

	// rotates the ship
	void RotateShip()
	{
		// rotate left
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			// new direction vector
			direction = Quaternion.Euler (0,0,angle) * direction;
			rotation += angle;
		}

		// rotate right
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			// new direction vector
			direction = Quaternion.Euler (0,0,-angle) * direction;
			rotation -= angle;
		}
	}	

	// wraps the vehicle around the screens
	void ScreenWrap()
	{
		if (position.x > camSize) 
		{
			// put the object on the opposite side of the screen
			position.x = -camSize;
		}
		
		if (position.y > camSize) 
		{
			// put the object on the opposite side of the screen
			position.y = -camSize;
		}
		
		if (position.x < -camSize) 
		{
			// put the object on the opposite side of the screen
			position.x = camSize;
		}
		
		if (position.y < -camSize) 
		{
			// put the object on the opposite side of the screen
			position.y = camSize;
		}
	}

	// update the transform of the ship
	void UpdateTransform()
	{
		transform.rotation = Quaternion.Euler (0, 0, rotation);
		transform.position = position;
	}
}
