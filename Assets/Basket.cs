﻿using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;
	
	// Update is called once per frame
	void Update () {
	
		//Get the current screen position of the mouse from Input.
		Vector3 mousepos2D = Input.mousePosition;

		//The camera's z position sets the how far to push the mouse into 3D
		mousepos2D.z = -Camera.main.transform.position.z;

		//Convert the point from the 2D screen space into 3D game world space.
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousepos2D); 

		//Move the x position of this Basket to the x position of the Mouse.

		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;


	}

	void Start() {
		//Find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		//Get the GUIText comp of that GameObject
		scoreGT = scoreGO.GetComponent<GUIText> ();
		//Set the starting number of points to 0.
		scoreGT.text = "0";

	}

	void OnCollisionEnter(Collision coll) {
		//Find out what hit this basket
		GameObject collidedWith = coll.gameObject;

		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}

		//Parse the text of the scoreGT into an int
		int score = int.Parse (scoreGT.text);
		//Add points for catching the apple
		score += 100;
		//Convert the score back into a string and display it.
		scoreGT.text = score.ToString ();

		//Track the high score
		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}
