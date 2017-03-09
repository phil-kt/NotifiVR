using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartWatchNotifier : Notifier{

	public override void TriggerNotification(NotificationType notificationType) {
		// Visual, haptic, audio	
		switch (notificationType) {
		case NotificationType.PHONE_INCOMING_CALL:
			Debug.Log ("received phone call notification");
			break;
		case NotificationType.PHONE_TEXT_MESSAGE:
			Debug.Log ("received phone call notification");
			break;
		}
			
		notificationTypeMap [notificationType].hapticOutput.TriggerPulse (0, 4000);
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
