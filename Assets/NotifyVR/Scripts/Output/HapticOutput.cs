using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HapticOutput : Output {
	public void TriggerPulse(int controllerIdx, ushort vibrationTime) {
		SteamVR_Controller.Input(controllerIdx).TriggerHapticPulse(vibrationTime);
	}
}
