using UnityEngine;
using System;
using System.Collections;

namespace UnityMidiControl {
	public sealed class InputManager : MonoBehaviour {
		private static InputManager _instance;

		void Awake() {
			if (_instance != null) {
				Debug.LogWarning("Attempting to create more than one input manager. Additional instances will be destroyed.");
				UnityEngine.Object.Destroy(this);
				return;
			}

			_instance = this;
		}

		void Update() {
		}
	}
}