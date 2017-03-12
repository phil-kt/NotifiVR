using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class defines a notifier object that appears slightly behind the controller, such as a smart watch.
 */
public class SmartWatchNotifier : ControllerLockedNotifier {

	public override void TriggerNotification(NotificationType notificationType) {
		base.TriggerNotification (notificationType);
		notificationTypeMap [notificationType].hapticOutput.TriggerPulse (0, 4000);
	}

	public override void DismissNotification (NotificationType notificationType) {
	}

	// Locks behind the controller, where the wrist would be.
	public override void LockToController () {
		// TODO: Lock the object to the controller.
	}
}
