﻿using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl.Input {
	public class KeyMappings {
		public List<Mapping> Mappings = new List<Mapping>();

		public void ClearMappings() {
			Mappings = new List<Mapping>();
		}

		public void RemoveMapping(int trigger, string key) {
			for (int i = Mappings.Count - 1; i >= 0; --i) {
				Mapping m = Mappings[i];
				if ((m.trigger == trigger) && (m.key == key)) {
					Mappings.RemoveAt(i);
					return; // if there are multiple mappings with the same settings, only the first will be removed
				}
			}
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

	public class Mapping {
		public int trigger; // note number (e.g., 60)
		public string key; // key activated (e.g., "x")
		
		public Mapping(int trigger, string key) {
			this.trigger = trigger;
			this.key = key;
		}
	}
}