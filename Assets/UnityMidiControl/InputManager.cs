using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl.Input {
//	[Serializable]
	public sealed class InputManager : MonoBehaviour {
		public KeyMappings KeyMappings = new KeyMappings();

		private static InputManager _instance;
		private void Awake() {
			if (UnityEngine.Object.FindObjectOfType(typeof(InputManager)) == null) {
				GameObject gameObject = new GameObject("InputManager");
				gameObject.AddComponent<InputManager>();
				DontDestroyOnLoad(gameObject);
				gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			
			_instance = UnityEngine.Object.FindObjectOfType(typeof(InputManager)) as InputManager;
		}

		public void MapKey(int trigger, string key) {
			KeyMappings.MapKey(trigger, key);
		}

		public void RemoveMapping(int trigger, string key) {
			KeyMappings.RemoveMapping(trigger, key);
		}
		
//		public static bool GetKey(string name) {
//			if (_instance.KeyMappings.MapsKey(name)) {
//				List<int> triggers = _instance.KeyMappings.GetTriggers(name);
//				bool triggered = false;
//				foreach (int t in triggers) {
//					if (MidiInput.GetKey(t) > 0.0f) {
//						triggered = true;
//						break;
//					}
//				}
//
//				return triggered || UnityEngine.Input.GetKey(name);
//			} else {
//				return UnityEngine.Input.GetKey(name);
//			}
//		}

		public static bool GetKeyDown(string name) {
			if ((_instance != null) && _instance.KeyMappings.MapsKey(name)) {
				List<int> triggers = _instance.KeyMappings.GetTriggers(name);
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

//		public static bool GetKeyUp(string name) {
//			if (_instance.KeyMappings.MapsKey(name)) {
//				List<int> triggers = _instance.KeyMappings.GetTriggers(name);
//				bool triggered = false;
//				foreach (int t in triggers) {
//					if (MidiInput.GetKeyUp(t)) {
//						triggered = true;
//						break;
//					}
//				}
//				
//				return triggered || UnityEngine.Input.GetKeyDown(name);
//			} else {
//				return UnityEngine.Input.GetKeyUp(name);
//			}
//		}
	}
}