using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Listener : MonoBehaviour {

	NavMeshAgent agent;

	void Start() {
		MessagingSystem.Instance.AttachListener(typeof(MoveToMessage),
			this.HandleMoveToMessage);
		agent = GetComponent<NavMeshAgent>();
	}

	bool HandleMoveToMessage(BaseMessage msg) {
		MoveToMessage castMsg = msg as MoveToMessage;
		agent.destination = castMsg._vecValue;
		return false;
	}

	void OnDestroy() {
		if (MessagingSystem.IsAlive) {
			MessagingSystem.Instance.DetachListener(typeof(MoveToMessage),
				this.HandleMoveToMessage);
		}
	}

}
