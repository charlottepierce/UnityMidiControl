using UnityEngine;
using UnityEditor;
using UnityMidiControl.Input;
using System.Collections.Generic;

namespace UnityMidiControl.Editor {
	public class KeyMapEditor : EditorWindow {
		private InputManager _inputManager;
		private Vector2 _scrollPos = Vector2.zero;

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
			}
		}

		public void OnDisable() {
			SavePrefab();
		}

		public void OnGUI() {
			if (_inputManager == null) {
				OnEnable(); // reload input manager; required when editor window opens with unity (instead of being opened from the menu) and no prefab exists
			}

			EditorGUIUtility.labelWidth = 90;

			if (_inputManager.KeyMappings.Mappings.Count > 0) {
				EditorGUILayout.LabelField("Key Mappings: ", EditorStyles.boldLabel);

				_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
				for (int i = _inputManager.KeyMappings.Mappings.Count - 1; i >= 0; --i) {
					KeyMapping m = _inputManager.KeyMappings.Mappings[i];

					GUILayout.BeginHorizontal();
					m.trigger = EditorGUILayout.IntField(" Note Number:", m.trigger, GUILayout.MaxWidth(130)); // TODO: validate that this is a valid note number
					m.key = EditorGUILayout.TextField("Triggers Key:", m.key, GUILayout.MaxWidth(160)); // TODO: validate that this is a real key

					if (GUILayout.Button("Remove", GUILayout.MaxWidth(70))) {
						_inputManager.RemoveMapping(m.trigger, m.key);
					}
					GUILayout.EndHorizontal();
				}
				EditorGUILayout.EndScrollView();
			}

			// TODO: update for control mappings

			if (GUILayout.Button("New Key Mapping", GUILayout.MaxWidth(369))) {
				_inputManager.MapKey(-1, "");
			}
			if (GUILayout.Button("Save Mappings", GUILayout.MaxWidth(369))) {
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