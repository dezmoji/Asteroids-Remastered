using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: To create a bullet for shooting
 * */
public class CreateBullet: MonoBehaviour 
{
	// needed for creating a bullet
	public GameObject bulletPrefab;
	private GameObject bullet;

	// stores the position of the ship
	private Vector3 position;

	// Use this for initialization
	void Start () 
	{
		position = gameObject.GetComponent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// update the position of the ship every frame
		position = gameObject.GetComponent<Transform> ().position;
		ShootBullet ();
	}

	// creates a bullet when Space is pressed once
	void ShootBullet()
	{
		// Space must be tapped to fire, meaning no rapid fire bursts
		if (Input.GetKeyDown(KeyCode.Space) == false && Input.GetKeyUp(KeyCode.Space)== true )
		{
			// create a bullet GameObject
			bullet = (GameObject)Instantiate(bulletPrefab,position,Quaternion.identity);
		}
		
		//Destroy (bullet, 4);
	}
}