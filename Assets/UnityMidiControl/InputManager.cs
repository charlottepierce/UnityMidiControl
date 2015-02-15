using UnityEngine;
using System;
using System.Collections;

namespace UnityMidiControl {
	public sealed class InputManager : MonoBehaviour {
		private static InputManager _instance;

		private InputMap _inputMap;

		void Awake() {
			if (_instance != null) {
				Debug.LogWarning("Attempting to create more than one input manager. Additional instances will be destroyed.");
				UnityEngine.Object.Destroy(this);
				return;
			}

			_instance = this;
			_inputMap = new InputMap(); // TODO: initialisation method? if InputMap becomes an interface need to choose this somehow
		}

		void Update() {
			// check for input from the 
			// register input as necessary
			// map to keypress

			// quick test:
			if (GetKeyDown("x")) {
				Debug.Log("'X' key pressed");
			}
		}

		public static bool GetKeyDown(string name) {
			if (_instance._inputMap.KeyMapped(name)) {
				// check if mapped MIDI input occurred
				// return appropriate value based on this result
				return false;
			}

			// either no MIDI event maps to this key or the mapped event did
			// not occur - check for a direct key press
			return UnityEngine.Input.GetKeyDown(name);
		}
	}
}