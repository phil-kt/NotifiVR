using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class defines a notifier that will spawn some object into the environment to notify the user of a notification.
 */
public class SpawnedObjectNotificationObject : NotificationObject {
	[SerializeField] public NotificationType notificationType;
	[SerializeField] public GameObject objectPrefab;

	protected GameObject displayObject;


	public void Start () {
		displayObject = Instantiate (objectPrefab);

		SpawnObject (displayObject, true, false);
		List<Output> list;
		if (!notificationTypeMap.TryGetValue(notificationType, out list)) {
			list = new List<Output> ();
			// TODO: Create and add a default Output instead of doing this.
			notificationTypeMap [notificationType] = list;
		} 
	}

	public override void TriggerNotification (NotificationType notificationType) {
		base.TriggerNotification (notificationType);
		// Visual, haptic, audio	
		switch (notificationType) {
		case NotificationType.PHONE_INCOMING_CALL:
			Debug.Log ("received phone call notification");
			break;
		case NotificationType.PHONE_TEXT_MESSAGE:
			Debug.Log ("received phone call notification");
			break;
		}

		//notificationTypeMap [notificationType].hapticOutput.TriggerPulse (0, 4000);
		displayObject.SetActive (true);
		var gcolor = gameObject.GetComponent<Renderer> ().material.color;
		gcolor = new Color (gcolor.r, gcolor.g, gcolor.b, 1f);
		gameObject.GetComponent<Renderer>().material.color = gcolor;

		var dcolor = displayObject.GetComponent<Renderer> ().material.color;
		dcolor = new Color (dcolor.r, dcolor.g, dcolor.b, .9f);
		displayObject.GetComponent<Renderer>().material.color = dcolor;
	}

	public override void DismissNotification (NotificationType notificationType) {
	}
}
