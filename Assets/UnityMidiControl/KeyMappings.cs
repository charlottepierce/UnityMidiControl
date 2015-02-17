using UnityEngine;
using System.Collections.Generic;

namespace UnityMidiControl.Input {
	public class KeyMappings {
		private List<Mapping> _mappings = new List<Mapping>();

		public void MapKey(int trigger, string key) {
			_mappings.Add(new Mapping(trigger, key));
		}

		public bool MapsKey(string key) {
			foreach (Mapping m in _mappings) {
				if (m.key == key) return true;
			}

			return false;
		}

		public List<int> GetTriggers(string key) {
			List<int> triggers = new List<int>();
			foreach (Mapping m in _mappings) {
				if (m.key == key) triggers.Add(m.trigger);
			}

			return triggers;
		}
	}

	class Mapping {
		public int trigger; // note number (e.g., 60)
		public string key; // key activated (e.g., "x")
		
		public Mapping(int trigger, string key) {
			this.trigger = trigger;
			this.key = key;
		}
	}
}