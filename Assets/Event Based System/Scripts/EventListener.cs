using Assets.Event_Based_System.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventListener : MonoBehaviour {

    public MyVector3Event Event;
    public EventTrigger.TriggerEvent customCallback;
    private Vector3 moveVector = new Vector3(0,0,0);
  
    // Use this for initialization
    void Start () {
        if (Event == null)
            Event = new MyVector3Event();

        //Event.AddListener(Move);

       // EventManager.Event = Event;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 localMoveVector = moveVector * Random.Range(-.1f, 1f);
       // Debug.Log("Position:" + transform.position.ToString());
        transform.position += localMoveVector;
    }  

    public void Move() {
        moveVector = EventManager.globalVector;
     //   Debug.Log("I told you to move");
    }
}
