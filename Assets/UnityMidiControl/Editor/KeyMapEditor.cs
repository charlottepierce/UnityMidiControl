using UnityEngine;
using UnityEditor;
using UnityMidiControl.Input;
using System.Collections.Generic;

namespace UnityMidiControl.Editor {
	public class KeyMapEditor : EditorWindow {
		[SerializeField] private InputManager _inputManager;

		[MenuItem("MIDI Input/Edit Key Mappings")]
		public static void ShowWindow() {
			EditorWindow win = EditorWindow.GetWindow(typeof(KeyMapEditor)); // show editor window; create it if it doesn't exist
			win.title = "MIDI Controls";
		}

		public void OnEnable() {
			_inputManager = InputManager.Instance;
		}

		public void OnGUI() {
			for (int i = _inputManager.KeyMappings.Mappings.Count - 1; i >= 0; --i) {
				Mapping m = _inputManager.KeyMappings.Mappings[i];

				GUILayout.BeginHorizontal();
				m.trigger = EditorGUILayout.IntField("Note Number: ", m.trigger); // TODO: validate that this is a valid note number
				m.key = EditorGUILayout.TextField("Triggers Key:", m.key); // TODO: validate that this is a real key
				if (GUILayout.Button("Remove")) {
					_inputManager.KeyMappings.Mappings.RemoveAt(i);
					Debug.Log("Key Maps: " + _inputManager.KeyMappings.Mappings.Count);
				}
				GUILayout.EndHorizontal();
			}

			if (GUILayout.Button("Add Key Mapping")) {
				InputManager.AddKeyMapping("", -1);
				Debug.Log("Key Maps: " + _inputManager.KeyMappings.Mappings.Count);
			}
		}
	}
}