using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingSpawner : MonoBehaviour {
	public GameObject prefab;
	public int NumThings;

	// Use this for initialization
	void Start () {
		NumThings = NumThings / 2;
		for (int i=0;i<NumThings;i++){
			float a = i / 10;
			Instantiate(prefab, new Vector3(a, 1, a), Quaternion.identity);
			Instantiate(prefab, new Vector3(-a, 1, -a), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
