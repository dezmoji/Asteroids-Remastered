using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Author: Dezmon Gilbert
 * Purpose: To manager any other relevant game code
 * */
public class SceneManager : MonoBehaviour 
{
	// information for the player
	private int lives = 3;
	private int totalScore = 0;

	private CollisionDetection cd;
	private CreateBullet cb;
	private FirstLevelSpawn spawn;

	private GameObject[] bullets;
	private List<GameObject> asteroids;
	public GameObject ship;
	private GameObject[] asteroidArray;

	// properties
	public int Lives
	{
		get{return lives;}
		set{ lives = value;}
	}

	public int TotalScore
	{
		get{return totalScore;}
		set{ lives = totalScore;}
	}

	// Use this for initialization
	void Start () 
	{
		// obtain the scripts neccesary for an extra scene management
		cd = gameObject.GetComponent<CollisionDetection> ();
		spawn = gameObject.GetComponent<FirstLevelSpawn> ();
		cb = gameObject.GetComponent<CreateBullet> ();
		asteroids = new List<GameObject> ();

		for (int i = 0; i < 5; i++) 
		{
			asteroids.Add(spawn.SpawnFirstLevel());
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		asteroids.RemoveAll (delegate(GameObject obj) {return obj == null;});
		if (asteroids.Count < 5) 
		{
			asteroids.Add (spawn.SpawnFirstLevel());
		}

		// when the player dies
		if (lives <= 0) 
		{
			// load the GameOver scene
			Application.LoadLevel("GameOver");
		}
	}

	// Display relevant info to the user continuously
	void OnGUI()
	{
		GUI.Box (new Rect (0, 0, 100, 50), "Lives: " + lives + "\nScore: " + totalScore);
	}
}
