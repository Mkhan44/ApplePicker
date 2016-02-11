using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	
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

	void OnCollisionEnter(Collision coll) {
		//Find out what hit this basket
		GameObject collidedWith = coll.gameObject;

		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}
	}
}
