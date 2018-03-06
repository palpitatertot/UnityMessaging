using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingSpawner : MonoBehaviour {
	public GameObject prefab;

	// Use this for initialization
	void Start () {
		for (int i=0;i<2000;i++){
			float a = i / 50;
			Instantiate(prefab, new Vector3(a, 1, a), Quaternion.identity);
			Instantiate(prefab, new Vector3(-a, 1, -a), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
