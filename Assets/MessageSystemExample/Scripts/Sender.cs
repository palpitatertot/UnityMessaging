using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour {
	public void Update() {
		if (Input.GetMouseButtonDown(0)) {
			MessagingSystem.Instance.QueueMessage(new MyCustomMessage(5));
		}
	}
}
