using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Notifier: MonoBehaviour {
	[SerializeField] public List<NotificationBehavior> notificationBehavior = new List<NotificationBehavior>();

	protected Dictionary<NotificationType, NotificationBehavior> notificationTypeMap;
	string metadata; // TODO: This should potentially be changed to a different datatype.

	public void Awake() {
		notificationTypeMap = new Dictionary<NotificationType, NotificationBehavior> ();
		for (int i = 0; i < notificationBehavior.Count; i++) {
			if (!notificationTypeMap.ContainsKey (notificationBehavior [i].notificationType)) {
				notificationTypeMap.Add (notificationBehavior [i].notificationType, notificationBehavior [i]);
			} else {
				throw new UnityException ("Only one of each notification type may be defined per script.");
			}
		}

	}
	public bool CanHandle(NotificationType notificationType) {
		return notificationTypeMap.ContainsKey (notificationType);
	}

	public abstract void TriggerNotification (NotificationType notificationType);

	public abstract void DismissNotification (NotificationType notificationType);

	public void DismissAllNotifications() {
	}

	public List<NotificationType> getNotificationTypes() {
		return new List<NotificationType>(notificationTypeMap.Keys);
	}
}
