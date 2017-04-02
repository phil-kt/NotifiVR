using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Model : MonoBehaviour {
	public AudioSource mAudioSource;
	public HapticSource mHapticSource;

	public abstract void OnSpawn ();
	public abstract void OnAccept ();
	public abstract void OnReject ();
	public abstract void OnIgnore();
	public abstract void OnSnooze(float snoozeTime);

	// To be used with Audio Expand
	public abstract void OnAudioExpand ();


}
