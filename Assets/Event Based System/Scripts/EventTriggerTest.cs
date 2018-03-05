using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{
    
    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            EventManager.TriggerEvent("Move");
        }        
    }
}