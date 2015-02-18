using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	void Update () {
		if (UnityMidiControl.Input.InputManager.GetKeyDown("a")) {
			Debug.Log("a pressed");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyDown("b")) {
			Debug.Log("b pressed");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyDown("c")) {
			Debug.Log("c pressed");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyDown("d")) {
			Debug.Log("d pressed");
		}
	}
}