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

  
    // Use this for initialization
    void Start () {
		EventManager.StartListening ("MoveEvent", MoveEventHandler);
		EventManager.StartListening ("SelectionEvent", SelectionEventHandler);
		go = this.gameObject;
		us = Camera.main.GetComponent<UnitSelectionComponent> ();
		mat = GetComponent<Renderer> ().material;
		mat.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 localMoveVector = moveVector * Random.Range(-.1f, 1f);
        transform.position += localMoveVector;
    }  

	public void MoveEventHandler(Vector3 parameter) {
		Debug.Log (parameter);
		if (mat.color == Color.red) {
			if (moveVector == parameter) {
				moveVector = new Vector3 (0, 0, 0);
			} else {
				moveVector = parameter;
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
