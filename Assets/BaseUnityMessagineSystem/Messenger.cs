using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Messenger : MonoBehaviour {
	GameObject[] listeners;

	void Start() {
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			listeners = GameObject.FindGameObjectsWithTag("MessageReceiver");
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				foreach (GameObject o in listeners){
					o.SendMessage ("MSGSetPosition", hit.point);
				}
			}
		}
	}
}
