using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HapticOutput : Output {
	public HapticSource hapticOutputSource;
	public HapticOutputBehavior outputBehavior;

	public void TriggerPulse(int controllerIdx, ushort vibrationTime) {
		SteamVR_Controller.Input(controllerIdx).TriggerHapticPulse(vibrationTime);
	}

	public override void TriggerNotification(NotificationType notificationType) {
	}
}
