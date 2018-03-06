using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMessage : BaseMessage {
	
	public readonly Vector3 _vecValue;
	public MoveToMessage(Vector3 vecVal) {
		_vecValue = vecVal;
	}
}

public class MoveMessage : BaseMessage {
	public readonly Vector3 _vecValue;
	public MoveMessage(Vector3 vecVal) {
		_vecValue = vecVal;
	}
}
