using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class communicates with the sensors and determines when there is a notification. Notification information is sent to the corresponding 
 * notifiers which handle how the the notification information is output into the environment.
 */ 
[System.Serializable]
public class NotificationManager : MonoBehaviour {
	protected Dictionary<NotificationType, List<Notifier>> notifierObjMap;

	public void Start() {
		notifierObjMap = new Dictionary<NotificationType, List<Notifier>> ();
		Notifier[] notifierObjects = (Notifier[])FindObjectsOfType (typeof(Notifier));
		Debug.Log ("Notifier objects found in scene: " + notifierObjects.Length);
		for (int i = 0; i < notifierObjects.Length; i++) {
			Notifier n = notifierObjects [i];
			List<NotificationType> types = n.getNotificationTypes ();
			for (int j = 0; j < types.Count; j++) {
				NotificationType currType = types [j];
				if (!notifierObjMap.ContainsKey (currType)) {
					notifierObjMap [currType] = new List<Notifier> ();
				}

				notifierObjMap [currType].Add (n);
			}
		}
	}

	public void Update (){
		// Listen for notifications
		if (Input.GetKeyDown("space")) {
			if (notifierObjMap.ContainsKey(NotificationType.PHONE_INCOMING_CALL)) {
				List<Notifier> notifierList = notifierObjMap[NotificationType.PHONE_INCOMING_CALL];
				for (int i = 0; i < notifierList.Count; i++) {
					if (notifierList[i].CanHandle (NotificationType.PHONE_INCOMING_CALL)) {
						notifierList[i].TriggerNotification (NotificationType.PHONE_INCOMING_CALL);
					}
				}
			}
		}
	}
}
