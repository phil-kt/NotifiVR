using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NotificationObject: MonoBehaviour {
	protected Dictionary<NotificationType, List<Output>> notificationTypeMap;

	public void Awake() {
		//TODO: This will need to be changed once outputs allow multiple notification types.
		Output[] attachedOutputs = gameObject.GetComponents<Output> ();
		notificationTypeMap = new Dictionary<NotificationType, List<Output>> ();
		for (int i = 0; i < attachedOutputs.Length; i++) {
			List<Output> list;
			if (!notificationTypeMap.TryGetValue(attachedOutputs [i].notificationType, out list)) {
				list = new List<Output> ();
				notificationTypeMap [attachedOutputs [i].notificationType] = list;
			} 

			list.Add(attachedOutputs[i]);
		}
	}
		
	public virtual bool CanHandle(NotificationType notificationType) {
		return notificationTypeMap.ContainsKey (notificationType);
	}

	public virtual void TriggerNotification (NotificationType notificationType) {
		List<Output> outputList = notificationTypeMap [notificationType];
		if (outputList != null) {
			for (int i = 0; i < outputList.Count; i++) {
				outputList [i].TriggerNotification (notificationType);
			}
		}
	}

	public virtual void DismissNotification (NotificationType notificationType) {
	}

	public void DismissAllNotifications() {
	}

	public List<NotificationType> getNotificationTypes() {
		return new List<NotificationType>(notificationTypeMap.Keys);
	}

	public void SpawnObject(GameObject obj, bool isRelative, bool isActive) {
		obj.transform.parent = this.gameObject.transform;
		if (isRelative) {
			obj.transform.position = this.gameObject.transform.position;
			Vector3 cameraPosition = Camera.main.transform.position;

			obj.transform.localPosition = Vector3.MoveTowards (obj.transform.localPosition, cameraPosition, this.gameObject.transform.localScale.z);
			obj.SetActive (isActive);
		}
	}
}
