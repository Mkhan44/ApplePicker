﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSPacingY = 2f;
	public IList<GameObject> basketList;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject> ();
		for (int i=0; i<numBaskets; i++) {
			GameObject tBasketGo = Instantiate(basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSPacingY * i );
			tBasketGo.transform.position = pos; 
			basketList.Add(tBasketGo);
		}
	
	}

	public void AppleDestroyed() {
		//Destroy all of the falling Apples.
		GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject tGO in tAppleArray) {
			Destroy (tGO);
		}

		int basketIndex = basketList.Count - 1;
		GameObject tBasketGO = basketList [basketIndex];
		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGO);	

		//Restart the game, which doesn't affect HighSCore.Score
		if (basketList.Count == 0) {
			Application.LoadLevel ("_Scene_0");
		}
	}

}