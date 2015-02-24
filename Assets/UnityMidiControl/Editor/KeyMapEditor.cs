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
			_inputManager = UnityEngine.Object.FindObjectOfType(typeof(InputManager)) as InputManager;
			if (_inputManager == null) {
				// try to load prefab
				Object managerPrefab = Resources.Load("InputManager"); // looks inside all 'Resources' folders in 'Assets'
				if (managerPrefab != null) {
					Object prefab = Instantiate(managerPrefab);
					prefab.name = "InputManager"; // otherwise creates a game object with "(Clone)" appended to the name
				} else if (UnityEngine.Object.FindObjectOfType(typeof(InputManager)) == null) {
					// no prefab found, create new input manager
					GameObject gameObject = new GameObject("InputManager");
					gameObject.AddComponent<InputManager>();
					DontDestroyOnLoad(gameObject);
				}
				_inputManager = UnityEngine.Object.FindObjectOfType(typeof(InputManager)) as InputManager;
				_inputManager.hideFlags = HideFlags.HideInHierarchy;
			}
		}

		public void OnDisable() {
			SavePrefab();
		}

		public void OnGUI() {
			EditorGUIUtility.labelWidth = 90;

			for (int i = _inputManager.KeyMappings.Mappings.Count - 1; i >= 0; --i) {
				Mapping m = _inputManager.KeyMappings.Mappings[i];

				GUILayout.BeginHorizontal();
				m.trigger = EditorGUILayout.IntField("Note Number:", m.trigger, GUILayout.MaxWidth(130)); // TODO: validate that this is a valid note number
				m.key = EditorGUILayout.TextField("Triggers Key:", m.key, GUILayout.MaxWidth(160)); // TODO: validate that this is a real key
				if (GUI.changed) {
					SavePrefab();
				}

				if (GUILayout.Button("Remove", GUILayout.MaxWidth(70))) {
					_inputManager.RemoveMapping(m.trigger, m.key);
					EditorUtility.SetDirty(_inputManager);
					SavePrefab();
				}
				GUILayout.EndHorizontal();
			}

			if (GUILayout.Button("New Key Mapping", GUILayout.MaxWidth(369))) {
				_inputManager.MapKey(-1, "");
				EditorUtility.SetDirty(_inputManager);
				SavePrefab();
			}
		}

		private void SavePrefab() {
			if (!System.IO.Directory.Exists("Assets/UnityMidiControl/Resources")) {
				System.IO.Directory.CreateDirectory("Assets/UnityMidiControl/Resources");
			}

			GameObject inputManager = GameObject.Find("InputManager");
			PrefabUtility.CreatePrefab("Assets/UnityMidiControl/Resources/InputManager.prefab", inputManager);
			AssetDatabase.Refresh();
		}
	}
}