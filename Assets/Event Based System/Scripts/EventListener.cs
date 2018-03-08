using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventListener : MonoBehaviour {
	UnitSelectionComponent us;
	Vector3 moveVector = new Vector3(0,0,0);
	GameObject go;
	Material mat;
	bool moving, upswing;
  
    // Use this for initialization
    void Start () {
		EventManager.StartListening ("MoveEvent", MoveEventHandler);
		EventManager.StartListening ("SelectionEvent", SelectionEventHandler);
		go = this.gameObject;
		us = Camera.main.GetComponent<UnitSelectionComponent> ();
		mat = GetComponent<Renderer> ().material;
		mat.color = Color.blue;
		upswing = true;
		moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		float rand = UnityEngine.Random.Range (-.1f, 1f);
		Vector3 localMoveVector = moveVector * rand;
		transform.position += localMoveVector;
		Vector3 t = transform.position;
		if (moving && upswing) {
			//Debug.Log ("UPSWING");
			transform.position = t + new Vector3(0,.5f,0) * rand;
			if (transform.position.y >= .5f) {
				upswing = false;
				transform.position = new Vector3 (t.x, .5f, t.z);
			}
		} else if (transform.position.y > 0) {
			transform.position -= new Vector3(0,.66f,0); 
		} else if (transform.position.y <= 0){
			transform.position = new Vector3 (t.x, 0, t.z);
			upswing = true;
		}
    }  

	public void MoveEventHandler(Vector3 parameter) {
		Debug.Log (parameter);
		if (mat.color == Color.red) {
			if (moveVector == parameter) {
				moveVector = new Vector3 (0, 0, 0);
				moving = false;
			} else {
				moveVector = parameter;
				moving = true;
				upswing = true;
			}
		}
    }

	public void SelectionEventHandler(Vector3 parameter) {
		Debug.Log ("Selecting");
		if (us.IsWithinSelectionBounds (go)) {
			mat.color = Color.red;
		} else {
			mat.color = Color.blue;
		}
	}
}
