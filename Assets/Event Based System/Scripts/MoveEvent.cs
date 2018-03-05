using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEvent : MonoBehaviour {

   // GameObject[] listeners;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        EventManager.StartListening("Move", Move);
    }

    void OnDisable()
    {
        EventManager.StopListening("Move", Move);
    }

    void Move()
    {
        RaycastHit hit;
       // listeners = GameObject.FindGameObjectsWithTag("MessageReceiver");
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            agent.destination = hit.point;
        }
    }
}
