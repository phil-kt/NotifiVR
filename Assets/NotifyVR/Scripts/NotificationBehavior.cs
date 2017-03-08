using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NotificationBehavior : System.Object {
	public NotificationType notificationType = NotificationType.PHONE_TEXT_MESSAGE;
	public AudioOutput audioOutput;
	public VisualOutput visualOutput;
	public HapticOutput hapticOutput;
}
