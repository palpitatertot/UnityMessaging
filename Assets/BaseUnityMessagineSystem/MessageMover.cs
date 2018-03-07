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
	// Use this for initialization
	void Start () {
		go = this.gameObject;
		us = Camera.main.GetComponent<UnitSelectionComponent> ();
		mat = GetComponent<Renderer> ().material;
		mat.color = Color.blue;	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 localMoveVector = moveVector * UnityEngine.Random.Range (-.1f, 1f);
		transform.position += localMoveVector;
	}

	public void MSGSetPosition(Vector3 position){
	}

	public void MSGMove(Vector3 move){
		if (mat.color == Color.red) {
			if (moveVector == move) {
				moveVector = new Vector3 (0, 0, 0);
			} else {
				moveVector = move;
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
