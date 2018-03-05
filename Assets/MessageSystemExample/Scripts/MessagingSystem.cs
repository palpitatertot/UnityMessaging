﻿using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MessagingSystem : SingletonAsComponent<MessagingSystem> {
	public static MessagingSystem Instance {
		get { return ((MessagingSystem)_Instance); }
		set { _Instance = value; }
	}
	public delegate bool MessageHandlerDelegate(BaseMessage message);

	private Dictionary<string,List<MessageHandlerDelegate>> _listenerDict = new Dictionary<string,List<MessageHandlerDelegate>>();


	public bool AttachListener(System.Type type, MessageHandlerDelegate handler){
		if (type == null) {
			Debug.Log("MessagingSystem: AttachListener failed due to no message type specified");
				return false;
				}
				string msgName = type.Name;
				if (!_listenerDict.ContainsKey(msgName)) {
					_listenerDict.Add(msgName, new List<MessageHandlerDelegate>());
				}
				List<MessageHandlerDelegate> listenerList = _listenerDict[msgName];
				if (listenerList.Contains(handler)) {
					return false; // listener already in list
				}
				listenerList.Add(handler);
				return true;
	}

	private Queue<BaseMessage> _messageQueue = new Queue<BaseMessage>();
	public bool QueueMessage(BaseMessage msg) {
		if (!_listenerDict.ContainsKey(msg.name)) {
			return false;
		}
		_messageQueue.Enqueue(msg);
		return true;
	}

	private float maxQueueProcessingTime = 0.16667f;
	void Update() {
		float timer = 0.0f;
		while (_messageQueue.Count > 0) {
			if (maxQueueProcessingTime > 0.0f) {
				if (timer > maxQueueProcessingTime)
					return;
			}
			BaseMessage msg = _messageQueue.Dequeue();
			if (!TriggerMessage(msg))
				Debug.Log("Error when processing message: " + msg.name);
			if (maxQueueProcessingTime > 0.0f)
				timer += Time.deltaTime;
		}

	}

	public bool TriggerMessage(BaseMessage msg) {
		string msgName = msg.name;
		if (!_listenerDict.ContainsKey(msgName)) {
			Debug.Log("MessagingSystem: Message \"" + msgName + "\" has no listeners!");
				return false; // no listeners for message so ignore it
				}
				List<MessageHandlerDelegate> listenerList = _listenerDict[msgName];
				for(int i = 0; i < listenerList.Count; ++i) {
					if (listenerList[i](msg))
						return true; // message consumed by the delegate
				}
				return true;
	}

	public bool DetachListener(System.Type type, MessageHandlerDelegate
		handler)
	{
		if (type == null) {
			Debug.Log("MessagingSystem: DetachListener failed due to no message type specified");
				return false;
				}
				string msgName = type.Name;
				if (!_listenerDict.ContainsKey(type.Name)) {
					return false;
				}
				List<MessageHandlerDelegate> listenerList = _listenerDict[msgName];
				if (!listenerList.Contains (handler)) {
					return false;
				}
				listenerList.Remove(handler);
				return true;
				}

}
