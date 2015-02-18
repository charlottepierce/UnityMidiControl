using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl.Input {
	[Serializable]
	public sealed class InputManager : MonoBehaviour {
		[SerializeField] private KeyMappings _keyMappings = new KeyMappings();
		public KeyMappings KeyMappings {
			get {
				return _keyMappings;
			}
		}

		private static InputManager _instance;
		public static InputManager Instance {
			get {
				if (_instance == null) {
					InputManager existing = (InputManager)FindObjectOfType(typeof(InputManager));
					if (existing) {
						_instance = existing;
					} else {
						GameObject inputManager = new GameObject("_MidiInputManager"); // underscore to remember the object is hidden
						_instance = inputManager.AddComponent<InputManager>();
						DontDestroyOnLoad(inputManager);
						inputManager.hideFlags = HideFlags.HideInHierarchy;
					}
				}

				return _instance;
			}
		}

		public static void AddKeyMapping(string key, int trigger) {
			Instance._keyMappings.MapKey(trigger, key);
		}

		public static void ClearKeyMappings() {
			Instance._keyMappings.ClearMappings();
		}

		public static bool GetKey(string name) {
			if (Instance._keyMappings.MapsKey(name)) {
				List<int> triggers = Instance._keyMappings.GetTriggers(name);
				bool triggered = false;
				foreach (int t in triggers) {
					if (MidiInput.GetKey(t) > 0.0f) {
						triggered = true;
						break;
					}
				}

				return triggered || UnityEngine.Input.GetKey(name);
			} else {
				return UnityEngine.Input.GetKey(name);
			}
		}

		public static bool GetKeyDown(string name) {
			if (Instance._keyMappings.MapsKey(name)) {
				List<int> triggers = Instance._keyMappings.GetTriggers(name);
				bool triggered = false;
				foreach (int t in triggers) {
					if (MidiInput.GetKeyDown(t)) {
						triggered = true;
						break;
					}
				}

				return triggered || UnityEngine.Input.GetKeyDown(name);
			} else {
				return UnityEngine.Input.GetKeyDown(name);
			}
		}

		public static bool GetKeyUp(string name) {
			if (Instance._keyMappings.MapsKey(name)) {
				List<int> triggers = Instance._keyMappings.GetTriggers(name);
				bool triggered = false;
				foreach (int t in triggers) {
					if (MidiInput.GetKeyUp(t)) {
						triggered = true;
						break;
					}
				}
				
				return triggered || UnityEngine.Input.GetKeyDown(name);
			} else {
				return UnityEngine.Input.GetKeyUp(name);
			}
		}
	}
}