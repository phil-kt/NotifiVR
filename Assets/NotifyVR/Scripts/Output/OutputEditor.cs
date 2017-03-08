using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Output))]
public class OutputEditor : UnityEditor.Editor {
	SerializedObject Target;

	public override void OnInspectorGUI() {
	/*	Object outputClass = target;
		if (((Output)outputClass).enabled) {
			outputClass.priority = EditorGUILayout.EnumPopup (outputClass.priority); 
		}*/
		// TODO: implement
	}
}
