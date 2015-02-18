using UnityEngine;
using UnityEditor;
using UnityMidiControl.Input;

namespace UnityMidiControl.Editor {
	public class KeyMapEditor : EditorWindow {
		private KeyMappings _keyMappings = new KeyMappings();

		[MenuItem("MIDI Input/Edit Key Mappings")]
		public static void ShowWindow() {
			EditorWindow win = EditorWindow.GetWindow(typeof(KeyMapEditor)); // show editor window; create it if it doesn't exist
			win.title = "MIDI Controls";
		}

		public void OnGUI() {
			foreach (Mapping m in _keyMappings.Mappings) {
				GUILayout.BeginHorizontal();
				m.trigger = EditorGUILayout.IntField("Note Number: ", m.trigger); // TODO: validate that this is a valid note number
				m.key = EditorGUILayout.TextField("Triggers Key:", m.key); // TODO: validate that this is a real key
				GUILayout.EndHorizontal();
			}

			if (GUILayout.Button("Add Key Mapping")) {
				_keyMappings.MapKey(-1, "");
			}

			if (GUILayout.Button("Apply")) {
				ApplyKeyMappings();
			}
		}

		private void ApplyKeyMappings() {
			InputManager.ClearKeyMappings();
			foreach (Mapping m in _keyMappings.Mappings) {
				InputManager.AddKeyMapping(m.key, m.trigger);
			}
			Debug.Log("MIDI key mappings updated");
		}
	}
}