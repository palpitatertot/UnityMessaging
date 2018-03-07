using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Listener : MonoBehaviour {

	Vector3 moveVector = new Vector3(0,0,0);

	void Start() {
		MessagingSystem.Instance.AttachListener(typeof(MoveToMessage),
			this.HandleMoveToMessage);
		MessagingSystem.Instance.AttachListener(typeof(MoveMessage),
			this.HandleMoveMessage);
	}

	void Update() {
		Vector3 localMoveVector = moveVector * Random.Range (-.1f, 1f);
		transform.position += localMoveVector;
	}

	bool HandleMoveToMessage(BaseMessage msg) {
		MoveToMessage castMsg = msg as MoveToMessage;
		return false;
	}

	bool HandleMoveMessage(BaseMessage msg) {
		MoveMessage castMsg = msg as MoveMessage;
		if (moveVector == castMsg._vecValue) {
			moveVector = new Vector3(0,0,0);
			return false;
		}
		moveVector = castMsg._vecValue;
		return false;
	}
		
	void OnDestroy() {
		if (MessagingSystem.IsAlive) {
			MessagingSystem.Instance.DetachListener(typeof(MoveToMessage),
				this.HandleMoveToMessage);
		}
		if (MessagingSystem.IsAlive) {
			MessagingSystem.Instance.DetachListener(typeof(MoveMessage),
				this.HandleMoveMessage);
		}
	}

}
