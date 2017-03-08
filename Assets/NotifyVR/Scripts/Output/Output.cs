using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Extend this class to account for the different types of output (ex. haptic, audio, visual)
 */

[System.Serializable]
public abstract class Output : System.Object {
	public bool enabled;
	public Priority priority;
}