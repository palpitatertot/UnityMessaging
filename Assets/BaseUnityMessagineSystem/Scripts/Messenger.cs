using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Messenger : MonoBehaviour {
	GameObject[] listeners;

	void Start() {
	}

	void Update() {
		if (false && Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			listeners = GameObject.FindGameObjectsWithTag("MessageReceiver");
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				foreach (GameObject o in listeners){
					o.SendMessage ("MSGSetPosition", hit.point);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			listeners = GameObject.FindGameObjectsWithTag("MessageReceiver");
			foreach (GameObject o in listeners){
				o.SendMessage ("MSGMove", new Vector3(-1,0,0));
			}	
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			listeners = GameObject.FindGameObjectsWithTag("MessageReceiver");
			foreach (GameObject o in listeners){
				o.SendMessage ("MSGMove", new Vector3(1,0,0));
			}	
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			listeners = GameObject.FindGameObjectsWithTag("MessageReceiver");
			foreach (GameObject o in listeners){
				o.SendMessage ("MSGMove", new Vector3(0,0,1));
			}	
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			listeners = GameObject.FindGameObjectsWithTag("MessageReceiver");
			foreach (GameObject o in listeners){
				o.SendMessage ("MSGMove", new Vector3(0,0,-1));
			}	
		}
		if( Input.GetMouseButton( 0 ) ){
			listeners = GameObject.FindGameObjectsWithTag("MessageReceiver");
			foreach (GameObject o in listeners){
				o.SendMessage ("MSGSelect", 1);
			}	
		}

	}
}
