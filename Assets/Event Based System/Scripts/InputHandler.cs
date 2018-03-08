using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	void Update(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			EventManager.TriggerEvent("MoveEvent", (new Vector3(-1,0,0)));	
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			EventManager.TriggerEvent("MoveEvent", (new Vector3(1,0,0)));	
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			EventManager.TriggerEvent("MoveEvent", (new Vector3(0,0,1)));	
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			EventManager.TriggerEvent("MoveEvent", (new Vector3(0,0,-1)));	
		}
		if( Input.GetMouseButton( 0 ) ){
			EventManager.TriggerEvent("SelectionEvent", Vector3.zero);
		}
	}

}
