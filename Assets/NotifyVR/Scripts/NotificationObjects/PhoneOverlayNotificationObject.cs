using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This class defines the behavior of a notifier that overlays itself ontop of the controller when a notification is present.
 */

public class PhoneOverlayNotificationObject : ControllerLockedNotificationObject {
	// Locks to COM of controller.
	public override void LockToController() {
		// TODO: Implement
	}

	public override void TriggerNotification(NotificationType notificationType) {
		base.TriggerNotification (notificationType);
		var gcolor = gameObject.GetComponent<Renderer> ().material.color;
		gcolor = new Color (gcolor.r, gcolor.g, gcolor.b, 1f);
		gameObject.GetComponent<Renderer>().material.color = gcolor;

		var dcolor = displayObject.GetComponent<Renderer> ().material.color;
		dcolor = new Color (dcolor.r, dcolor.g, dcolor.b, .9f);
		displayObject.GetComponent<Renderer>().material.color = dcolor;
	}
}
