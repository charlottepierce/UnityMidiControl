using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl {
	public sealed class InputManager : MonoBehaviour {
		private static InputManager _instance;

		private Dictionary<string, string> _keyMappings; // key = key activated, value = trigger; e.g., key = 'x', value = note number 44

		void Awake() {
			if (_instance != null) {
				Debug.LogWarning("Attempting to create more than one input manager. Additional instances will be destroyed.");
				UnityEngine.Object.Destroy(this);
				return;
			}

			_instance = this;
			_keyMappings = new Dictionary<string, string>();
		}

		public static void AddKeyMapping(string key, string trigger) {
			_instance._keyMappings.Add(key, trigger);
		}

		public static bool GetKeyDown(string name) {
			if (_instance._keyMappings.ContainsKey(name)) {
				string trigger = _instance._keyMappings[name];
				return UnityEngine.Input.GetKeyDown(trigger) || UnityEngine.Input.GetKeyDown(name);
			} else {
				return UnityEngine.Input.GetKeyDown(name);
			}
		}
	}
}