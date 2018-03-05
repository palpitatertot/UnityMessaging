using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MessageMover : MonoBehaviour {
	NavMeshAgent agent;

	private Vector3 target;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MSGSetPosition(Vector3 position){
		agent.destination = position;
	}
}
