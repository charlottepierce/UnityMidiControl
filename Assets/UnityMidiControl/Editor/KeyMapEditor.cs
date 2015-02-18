using UnityEngine;
using UnityEditor;
using UnityMidiControl.Input;
using System.Collections.Generic;

namespace UnityMidiControl.Editor {
	public class KeyMapEditor : EditorWindow {
		private InputManager _inputManager;

		[MenuItem("MIDI Input/Edit Key Mappings")]
		public static void ShowWindow() {
			EditorWindow win = EditorWindow.GetWindow(typeof(KeyMapEditor)); // show editor window; create it if it doesn't exist
			win.title = "MIDI Controls";
		}

		public void OnEnable() {
			_inputManager = InputManager.Instance;
		}

		public void OnGUI() {
			List<Mapping> remove = new List<Mapping>();
			foreach (Mapping m in _inputManager.KeyMappings.Mappings) {
				GUILayout.BeginHorizontal();
				m.trigger = EditorGUILayout.IntField("Note Number: ", m.trigger); // TODO: validate that this is a valid note number
				m.key = EditorGUILayout.TextField("Triggers Key:", m.key); // TODO: validate that this is a real key
				if (GUILayout.Button("Remove")) {
					remove.Add(m);
				}
				GUILayout.EndHorizontal();
			}

			foreach (Mapping m in remove) {
				_inputManager.KeyMappings.Mappings.Remove(m);
			}

			if (GUILayout.Button("Add Key Mapping")) {
				InputManager.AddKeyMapping("", -1);
			}
		}
	}
}