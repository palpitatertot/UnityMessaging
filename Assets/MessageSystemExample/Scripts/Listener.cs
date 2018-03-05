using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Listener : MonoBehaviour {

	NavMeshAgent agent;

	void Start() {
		MessagingSystem.Instance.AttachListener(typeof(MyCustomMessage),
			this.HandleMyCustomMessage);
		agent = GetComponent<NavMeshAgent>();
	}

	bool HandleMyCustomMessage(BaseMessage msg) {
		MyCustomMessage castMsg = msg as MyCustomMessage;
		if (castMsg._intValue == 5) {
			
				RaycastHit hit;

				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
					agent.destination = hit.point;
				}
		}
		return false;
	}

	void OnDestroy() {
		if (MessagingSystem.IsAlive) {
			MessagingSystem.Instance.DetachListener(typeof(MyCustomMessage),
				this.HandleMyCustomMessage);
		}
	}

}
