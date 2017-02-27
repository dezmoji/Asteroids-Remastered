using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Author: Dezmon Gilbert 
 * Purpose: Handles collisions between bullets and asteroids
 * */
public class BulletCollision : MonoBehaviour 
{
	private List<GameObject> bullets;
	private SpriteInfo asteroidInfo;
	private SpriteInfo bulletInfo;
	private SceneManager sm;
	
	// Use this for initialization
	void Start () 
	{
		bullets = new List<GameObject> ();
		sm = GameObject.FindGameObjectWithTag ("SceneManager").GetComponent<SceneManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindGameObjectsWithTag ("Bullet").Length != 0) 
		{
			CheckBulletCollision ();
		}
	}

	void CheckBulletCollision()
	{
		foreach(GameObject b in GameObject.FindGameObjectsWithTag("Bullet"))
		{
			bullets.Add(b);
		}
		bullets.RemoveAll (delegate(GameObject obj) {return obj == null;});
		for(int i = 0; i < bullets.Count; i++)
		{
			if(bullets[i] == null)
			{
				break;
			}
			asteroidInfo = gameObject.GetComponent<SpriteInfo> ();
			bulletInfo = bullets[i].GetComponent<SpriteInfo> ();
			// find the distance between the two sprites from their centers
			float distanceSqrd = ((bulletInfo.center.x - asteroidInfo.center.x)*(bulletInfo.center.x - asteroidInfo.center.x))+
				((bulletInfo.center.y - asteroidInfo.center.y) * (bulletInfo.center.y - asteroidInfo.center.y));
			
			// add the radii squared together
			float radiusSqrdTotal = bulletInfo.radiusSqrd + asteroidInfo.radiusSqrd;
			
			// collision
			if (distanceSqrd < radiusSqrdTotal) 
			{
				if(bullets[i] != null)
				{
					GameObject bullet = bullets[i];
					bullets.Remove(bullet);
					Destroy(bullets[i]);
					Destroy(bullet);
					Destroy(gameObject);
					sm.TotalScore += 50;
				}
			}
		}

	}
}