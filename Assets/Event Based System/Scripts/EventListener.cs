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

	public void MoveEventHandler(Vector3 parameter) {
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
		if (us.IsWithinSelectionBounds (go)) {
			mat.color = Color.red;
		} else {
			mat.color = Color.blue;
		}
	}
}
