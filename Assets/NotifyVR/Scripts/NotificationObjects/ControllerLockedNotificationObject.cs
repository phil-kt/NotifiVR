using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLockedNotificationObject : SpawnedObjectNotificationObject {
	// Update is called once per frame
	void Update () {
		LockToController ();
	}

	public virtual void LockToController() {
		//TODO: Implement.
	}
}
