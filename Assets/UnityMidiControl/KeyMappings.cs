using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl.Input {
	[Serializable]
	public class KeyMappings {
		public List<Mapping> Mappings = new List<Mapping>();

		public void ClearMappings() {
			Mappings = new List<Mapping>();
		}

		public void MapKey(int trigger, string key) {
			Mappings.Add(new Mapping(trigger, key));
		}

		public bool MapsKey(string key) {
			foreach (Mapping m in Mappings) {
				if (m.key == key) return true;
			}

			return false;
		}

		public List<int> GetTriggers(string key) {
			List<int> triggers = new List<int>();
			foreach (Mapping m in Mappings) {
				if (m.key == key) triggers.Add(m.trigger);
			}

			return triggers;
		}
	}

	[Serializable]
	public class Mapping {
		public int trigger; // note number (e.g., 60)
		public string key; // key activated (e.g., "x")
		
		public Mapping(int trigger, string key) {
			this.trigger = trigger;
			this.key = key;
		}
	}
}