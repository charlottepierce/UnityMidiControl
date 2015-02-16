using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl {
	public sealed class InputManager : MonoBehaviour {
		private static InputManager _instance;

		private Dictionary<string, int> _keyMappings; // key = key activated, value = trigger; e.g., key = 'x', value = note number 44

		void Awake() {
			if (_instance != null) {
				Debug.LogWarning("Attempting to create more than one input manager. Additional instances will be destroyed.");
				UnityEngine.Object.Destroy(this);
				return;
			}

			_instance = this;
			_keyMappings = new Dictionary<string, int>();
		}

		public static void AddKeyMapping(string key, int trigger) {
			_instance._keyMappings.Add(key, trigger);
		}

		public static bool GetKeyDown(string name) {
			if (_instance._keyMappings.ContainsKey(name)) {
				int trigger = _instance._keyMappings[name];
				return MidiInput.GetKeyDown(trigger) || UnityEngine.Input.GetKeyDown(name);
			} else {
				return UnityEngine.Input.GetKeyDown(name);
			}
		}

		public static bool GetKeyUp(string name) {
			if (_instance._keyMappings.ContainsKey(name)) {
				int trigger = _instance._keyMappings[name];
				return MidiInput.GetKeyUp(trigger) || UnityEngine.Input.GetKeyUp(name);
			} else {
				return UnityEngine.Input.GetKeyUp(name);
			}
		}
	}
}