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
				Debug.Log("Input manager doesn't exist yet");
				// try to load prefab
				Object managerPrefab = Resources.Load("InputManager");
				if (managerPrefab != null) {
					Debug.Log("LOADED PREFAB!");
					Object prefab = Instantiate(managerPrefab);
					prefab.name = "InputManager"; // otherwise creates a game object with "(Clone)" appended to the name
				} else if (UnityEngine.Object.FindObjectOfType(typeof(InputManager)) == null) {
					// no prefab, create new input manager
					Debug.Log("Creating input manager");
					GameObject gameObject = new GameObject("InputManager");
					gameObject.AddComponent<InputManager>();
					DontDestroyOnLoad(gameObject);
//					gameObject.hideFlags = HideFlags.HideInHierarchy;
				}
				_inputManager = UnityEngine.Object.FindObjectOfType(typeof(InputManager)) as InputManager;
			}

			Debug.Log("Enable: " + _inputManager.KeyMappings.Mappings.Count);
		}

		public void OnDisable() {
			Debug.Log("Disable: " + _inputManager.KeyMappings.Mappings.Count);

			GameObject inputManager = GameObject.Find("InputManager");
			PrefabUtility.CreatePrefab("Assets/UnityMidiControl/Resources/InputManager.prefab", inputManager);
			AssetDatabase.Refresh();
		}

		public void OnGUI() {
			EditorGUIUtility.labelWidth = 90;

			for (int i = _inputManager.KeyMappings.Mappings.Count - 1; i >= 0; --i) {
				Mapping m = _inputManager.KeyMappings.Mappings[i];

				GUILayout.BeginHorizontal();
				m.trigger = EditorGUILayout.IntField("Note Number:", m.trigger, GUILayout.MaxWidth(130)); // TODO: validate that this is a valid note number
				m.key = EditorGUILayout.TextField("Triggers Key:", m.key, GUILayout.MaxWidth(160)); // TODO: validate that this is a real key
				if (GUILayout.Button("Remove", GUILayout.MaxWidth(70))) {
					_inputManager.RemoveMapping(m.trigger, m.key);
					EditorUtility.SetDirty(_inputManager);
				}
				GUILayout.EndHorizontal();
			}

			if (GUILayout.Button("New Key Mapping", GUILayout.MaxWidth(369))) {
				_inputManager.MapKey(-1, "");
				EditorUtility.SetDirty(_inputManager);
			}
		}
	}
}