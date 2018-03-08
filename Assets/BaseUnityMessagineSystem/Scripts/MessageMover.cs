using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MessageMover : MonoBehaviour {
	GameObject go;
	Vector3 moveVector = new Vector3(0,0,0);
	UnitSelectionComponent us;
	Material mat;
	bool moving;
	bool upswing;
	// Use this for initialization
	void Start () {
		go = this.gameObject;
		us = Camera.main.GetComponent<UnitSelectionComponent> ();
		mat = GetComponent<Renderer> ().material;
		mat.color = Color.blue;	
		moving = false;
		upswing = true;
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

	public void MSGSetPosition(Vector3 position){
	}

	public void MSGMove(Vector3 move){
		if (mat.color == Color.red) {
			if (moveVector == move) {
				moveVector = new Vector3 (0, 0, 0);
				moving = false;
			} else {
				moveVector = move;
				moving = true;
				upswing = true;
			}
		}
	}

	public void MSGSelect(int z){
		if (us.IsWithinSelectionBounds (go)) {
			mat.color = Color.red;
		} else {
			mat.color = Color.blue;
		}
	}
}
