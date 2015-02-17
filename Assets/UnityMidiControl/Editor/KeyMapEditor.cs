using UnityEngine;
using UnityEditor;

namespace UnityMidiControl.Editor {
	public class KeyMapEditor : EditorWindow {
		[MenuItem ("MIDI Input/Edit Key Mappings")]
		public static void ShowWindow() {
			EditorWindow.GetWindow(typeof(KeyMapEditor)); // show editor window; create it if it doesn't exist
		}

		public void OnGUI() {}
	}
}