using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace UnityMidiControl.Editor {
	public class KeyMapEditor : EditorWindow {
		private Dictionary<int, string> _keyMappings = new Dictionary<int, string>(); // key = trigger; value = key activated; e.g., key = note number 44, value = 'x'

		[MenuItem("MIDI Input/Edit Key Mappings")]
		public static void ShowWindow() {
			EditorWindow win = EditorWindow.GetWindow(typeof(KeyMapEditor)); // show editor window; create it if it doesn't exist
			win.title = "MIDI Controls";
		}

		public void OnGUI() {
			foreach (int trigger in _keyMappings.Keys) {
				string key = _keyMappings[trigger];

				GUILayout.BeginHorizontal();
				EditorGUILayout.IntField("Note Number: ", trigger);
				EditorGUILayout.TextField("Triggers Key:", "");
				GUILayout.EndHorizontal();
				// TODO: make the changes of values persist
			}

			if (GUILayout.Button("Add Key Mapping")) {
				NewKeyMap();
			}
		}

		private void NewKeyMap() {
			_keyMappings.Add(-1, "");
		}
	}
}