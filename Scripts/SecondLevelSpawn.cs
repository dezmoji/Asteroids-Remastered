using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert 
 * Purpose: Handles spawning the second level asteroids
 * */
public class SecondLevelSpawn : MonoBehaviour 
{
	private GameObject[] slPrefabs;
	public GameObject slPrefab1;
	public GameObject slPrefab2;
	private GameObject[] slAsteroids;

	private Vector3 position;
	private Vector3 direction;

	// Use this for initialization
	void Start () 
	{
		slPrefabs = new GameObject[2];
		slAsteroids = new GameObject[2];
		position = gameObject.GetComponent<Transform> ().position;
		direction = gameObject.GetComponent<AsteroidMovement> ().Direction;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public GameObject[] SpawnSecondLevel()
	{
		slAsteroids[0] = (GameObject)Instantiate(slPrefab1, new Vector3(position.x+.5f,position.y,position.z),Quaternion.identity);
		slAsteroids[1] = (GameObject)Instantiate(slPrefab2,new Vector3(position.x-.5f,position.y+.5f,position.z),Quaternion.identity);
		return slAsteroids;
	}
}
