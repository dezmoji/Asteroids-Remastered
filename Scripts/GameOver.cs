using UnityEngine;
using System.Collections;

/*
 * Author: Dezmon Gilbert
 * Purpose: To allow the user to restart the game whithout having to restart the executable.
 * */
public class GameOver : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if the user presses R
		if (Input.GetKey (KeyCode.R) == true) 
		{
			// reload the Game Scene
			Application.LoadLevel("Game");
		}
	}

	// will show text on screen
	void OnGUI()
	{
		GUI.Box (new Rect (140, 140, 200, 25), "Press R to restart game");
	}
}
