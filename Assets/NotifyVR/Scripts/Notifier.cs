using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Notifier: MonoBehaviour {
	[SerializeField] public GameObject objectPrefab;
	[SerializeField] public List<NotificationBehavior> notificationBehavior = new List<NotificationBehavior>();

	protected Dictionary<NotificationType, NotificationBehavior> notificationTypeMap;
	protected GameObject displayObject;

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

		displayObject = Instantiate (objectPrefab);
		displayObject.transform.parent = this.gameObject.transform;
		displayObject.transform.position = this.gameObject.transform.position;
		Vector3 cameraPosition = Camera.main.transform.position;

		displayObject.transform.localPosition = Vector3.MoveTowards (displayObject.transform.localPosition, cameraPosition, this.gameObject.transform.localScale.z);
		displayObject.SetActive (false);
	}
	public bool CanHandle(NotificationType notificationType) {
		return notificationTypeMap.ContainsKey (notificationType);
	}

	public virtual void TriggerNotification(NotificationType notificationType) {
	}

	public virtual void DismissNotification(NotificationType notificationType) {
	}

	public virtual void DismissAllNotifications() {
	}

	public List<NotificationType> getNotificationTypes() {
		return new List<NotificationType>(notificationTypeMap.Keys);
	}
}
