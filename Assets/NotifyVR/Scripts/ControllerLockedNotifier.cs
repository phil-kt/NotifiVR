using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLockedNotifier : SpawnedObjectNotifier {
	// Update is called once per frame
	void Update () {
		LockToController ();
	}

	public virtual void LockToController() {
		//TODO: Implement.
	}
}
