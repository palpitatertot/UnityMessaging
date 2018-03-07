using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Listener : MonoBehaviour {


	UnitSelectionComponent us;
	Vector3 moveVector = new Vector3(0,0,0);
	GameObject go;
	Material mat;

	void Start() {
		MessagingSystem.Instance.AttachListener(typeof(MoveToMessage),
			this.HandleMoveToMessage);
		MessagingSystem.Instance.AttachListener(typeof(MoveMessage),
			this.HandleMoveMessage);
		MessagingSystem.Instance.AttachListener(typeof(SelectionMessage),
			this.HandleSelectionMessage);
		go = this.gameObject;
		us = Camera.main.GetComponent<UnitSelectionComponent> ();
		mat = GetComponent<Renderer> ().material;
		mat.color = Color.blue;
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
		if (mat.color == Color.red) {
			MoveMessage castMsg = msg as MoveMessage;
			if (moveVector == castMsg._vecValue) {
				moveVector = new Vector3(0,0,0);
				return false;
			}
			moveVector = castMsg._vecValue;
			return false;
		}

		return false;
	}

	bool HandleSelectionMessage(BaseMessage msg) {
		if (us.IsWithinSelectionBounds (go)) {
			mat.color = Color.red;
			return false;
		} else {
			mat.color = Color.blue;
		return false;
		}
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
		if (MessagingSystem.IsAlive) {
			MessagingSystem.Instance.DetachListener(typeof(SelectionMessage),
				this.HandleSelectionMessage);
		}
	}

}
