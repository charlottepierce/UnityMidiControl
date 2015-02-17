using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl {
	public sealed class InputManager : MonoBehaviour {
		private Dictionary<string, int> _keyMappings; // key = key activated, value = trigger; e.g., key = 'x', value = note number 44

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

		public void Awake() {
			_keyMappings = new Dictionary<string, int>();
		}

		public static void AddKeyMapping(string key, int trigger) {
			instance._keyMappings.Add(key, trigger);
		}

		public static bool GetKey(string name) {
			if (instance._keyMappings.ContainsKey(name)) {
				int trigger = instance._keyMappings[name];
				return (MidiInput.GetKey(trigger) > 0.0f) || UnityEngine.Input.GetKey(name);
			} else {
				return UnityEngine.Input.GetKey(name);
			}
		}

		public static bool GetKeyDown(string name) {
			if (instance._keyMappings.ContainsKey(name)) {
				int trigger = instance._keyMappings[name];
				return MidiInput.GetKeyDown(trigger) || UnityEngine.Input.GetKeyDown(name);
			} else {
				return UnityEngine.Input.GetKeyDown(name);
			}
		}

		public static bool GetKeyUp(string name) {
			if (instance._keyMappings.ContainsKey(name)) {
				int trigger = instance._keyMappings[name];
				return MidiInput.GetKeyUp(trigger) || UnityEngine.Input.GetKeyUp(name);
			} else {
				return UnityEngine.Input.GetKeyUp(name);
			}
		}
	}
}