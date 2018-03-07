using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour {
	public void Update() {
		if (false && Input.GetMouseButtonDown(0)) {
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				MessagingSystem.Instance.QueueMessage(new MoveToMessage(hit.point));
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			MessagingSystem.Instance.QueueMessage(new MoveMessage(new Vector3(-1,0,0)));	
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			MessagingSystem.Instance.QueueMessage(new MoveMessage(new Vector3(1,0,0)));
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			MessagingSystem.Instance.QueueMessage(new MoveMessage(new Vector3(0,0,1)));
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			MessagingSystem.Instance.QueueMessage(new MoveMessage(new Vector3(0,0,-1)));
		}
        
	}
}
