using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl.Input {
	public sealed class InputManager : MonoBehaviour {
		private KeyMappings _keyMappings = new KeyMappings();

		private static InputManager _instance;
		private static InputManager instance {
			get {
				if (_instance == null) {
					InputManager existing = (InputManager)FindObjectOfType(typeof(InputManager));
					if (existing) {
						Debug.LogWarning("MIDI input manager is automatically initialised. Don't assign the InputManager behaviour to an object.");
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
			instance._keyMappings.MapKey(trigger, key);
		}

		public static bool GetKey(string name) {
			if (instance._keyMappings.MapsKey(name)) {
				List<int> triggers = instance._keyMappings.GetTriggers(name);
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
			if (instance._keyMappings.MapsKey(name)) {
				List<int> triggers = instance._keyMappings.GetTriggers(name);
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
			if (instance._keyMappings.MapsKey(name)) {
				List<int> triggers = instance._keyMappings.GetTriggers(name);
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