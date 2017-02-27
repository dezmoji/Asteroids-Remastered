using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: To reduce the amount of work needed for collisions
 * */
public class SpriteInfo : MonoBehaviour 
{
	// information about the bounds of the sprite
	public Vector3 extents;
	public float radiusSqrd;

	// to help with distance for later
	public Vector3 center;

	// Use this for initialization
	void Start () 
	{
		// find the extents and center
		extents = gameObject.GetComponent<SpriteRenderer> ().bounds.extents;
		center = gameObject.GetComponent<SpriteRenderer> ().bounds.center;

		// square the extents to find the squared radius
		// working with the sqaured radius is less CPU intensive
		radiusSqrd = extents.sqrMagnitude;

	}
	
	// Update is called once per frame
	void Update () 
	{
		// update these for when the object moves
		center = gameObject.GetComponent<SpriteRenderer> ().bounds.center;
	}
}
