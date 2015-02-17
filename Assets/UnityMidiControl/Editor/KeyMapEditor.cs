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
				m.trigger = EditorGUILayout.IntField("Note Number: ", m.trigger);
				m.key = EditorGUILayout.TextField("Triggers Key:", m.key);
				GUILayout.EndHorizontal();
			}

			if (GUILayout.Button("Add Key Mapping")) {
				_keyMappings.MapKey(-1, "");
			}
		}
	}
}