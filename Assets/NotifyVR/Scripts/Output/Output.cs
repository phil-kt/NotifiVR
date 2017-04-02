using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Extend this class to account for the different types of output (ex. haptic, audio, visual)
 */
using System;

[System.Serializable]
public abstract class Output : MonoBehaviour {
	public NotificationType notificationType;
	public InteractionControlType acceptBy;
	public InteractionControlType ignoreBy;
	public InteractionControlType rejectBy;
	public InteractionControlType expandBy;

	public void Awake() {
		if (gameObject.GetComponent<NotificationObject> () == null) {
			Debug.LogWarning ("No NotificationObject script is attached to a game object with an Ouptut script. The Output script will not execute.");
		} else if (gameObject.GetComponents<NotificationObject> ().Length > 1) {
			throw new Exception ("Multiple NotificationObject scripts are not allowed on the same game object.");
		}
	}

	public abstract void TriggerNotification(NotificationType type);
}