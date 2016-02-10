﻿using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	// Prefab for instantiating apples
	public GameObject applePrefab;

	//Speed at which the AppleTree moves in meters/seconds. 
	public float speed = 1f;

	//Distance where AppleTree turns around
	public float leftAndRightEdge = 10f;

	//Chance that APpleTree will change directions.
	public float chanceToChangeDirections = 0.1f;

	//Rate at which Apples will be instantiated
	public float secondsBetweenAppleDrops = 1f;


	// Use this for initialization
	void Start () {
				//Dropping apples every second.
	}
	
	// Update is called once per frame
	void Update () {
				//Basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
			    //Changing directions.
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); //Move right
		
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);  //Move left.
		} else if (Random.value < chanceToChangeDirections) {
			speed *= -1; // Change direction.
		}
	
	}
}