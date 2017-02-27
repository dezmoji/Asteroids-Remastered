using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: Handles starting the game
 * */
public class StartManager : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if the user presses S
		if (Input.GetKey (KeyCode.S) == true) 
		{
			// load the Game Scene
			Application.LoadLevel("Game");
		}
	}
}
