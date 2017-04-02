using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VisualOutput : Output {
	public GameObject modelPrefab;
	public VisualOutputBehavior outputBehavior;

	protected GameObject modelObj;

	public void Start() {
		modelObj = Instantiate (modelPrefab);
		SpawnModel ();
	}
	public override void TriggerNotification(NotificationType notificationType) {
		switch (outputBehavior) {
		case VisualOutputBehavior.SPAWN_MODEL:
			modelObj.SetActive (true);
			break;
		case VisualOutputBehavior.MODEL_DEFAULT:
			break;
		}
	}

	public void SpawnModel() {
		NotificationObject notificationObject = gameObject.GetComponent<NotificationObject> ();
		if (notificationObject != null) {
			notificationObject.SpawnObject (modelObj, true, false);
		}
	}
}
