using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Listener : MonoBehaviour {


	UnitSelectionComponent us;
	Vector3 moveVector = new Vector3(0,0,0);
	GameObject go;
	Material mat;
	bool moving, upswing;

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
		moving = false;
		upswing = true;
	}

	void Update () {
		float rand = UnityEngine.Random.Range (-1f, 30f);
		Vector3 localMoveVector = moveVector * rand;
		transform.position += localMoveVector * Time.deltaTime;
		Vector3 t = transform.position;
		if (moving && upswing) {
			//Debug.Log ("UPSWING");
			transform.position = t + new Vector3(0,1f,0) * rand * Time.deltaTime;
			if (transform.position.y >= .5f) {
				upswing = false;
				transform.position = new Vector3 (t.x, .5f, t.z);
			}
		} else if (transform.position.y > 0) {
			transform.position -= new Vector3(0,4f,0) * Time.deltaTime; 
		} else if (transform.position.y <= 0){
			transform.position = new Vector3 (t.x, 0, t.z);
			upswing = true;
		}
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
				moving = false;
				return false;
			}
			moveVector = castMsg._vecValue;
			moving = true;
			upswing = true;
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
