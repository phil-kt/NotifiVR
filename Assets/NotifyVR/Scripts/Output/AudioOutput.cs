using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioOutput : Output {
	// The game object on which to direct the audio spatially.
	public GameObject modelPrefab;
	public AudioOutputBehavior outputBehavior;

	public override void TriggerNotification(NotificationType notificationType) {
	}
}