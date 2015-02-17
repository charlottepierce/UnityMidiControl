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
				EditorGUILayout.IntField("Note Number: ", m.trigger);
				EditorGUILayout.TextField("Triggers Key:", m.key);
				GUILayout.EndHorizontal();
				// TODO: make the changes of values persist
			}

			if (GUILayout.Button("Add Key Mapping")) {
				NewKeyMap();
			}
		}

		private void NewKeyMap() {
			_keyMappings.MapKey(-1, "");
		}
	}
}