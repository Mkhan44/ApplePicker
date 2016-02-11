using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	public static float bottomY = -20f;
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.y < bottomY) {
			Destroy ( this.gameObject);
			//Reference ApplePicker comp of Main Camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker> ();
			//Call the public APpleDestroyed() method of apScript
			apScript.AppleDestroyed ();
		}

	
	}
}
