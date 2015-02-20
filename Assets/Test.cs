using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	void Update () {
		if (UnityMidiControl.Input.InputManager.GetKeyDown("a")) {
			Debug.Log("'a' down");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyDown("b")) {
			Debug.Log("'b' down");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyDown("c")) {
			Debug.Log("'c' down");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyDown("d")) {
			Debug.Log("'d' down");
		}

		if (UnityMidiControl.Input.InputManager.GetKeyUp("a")) {
			Debug.Log("'a' up");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyUp("b")) {
			Debug.Log("'b' up");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyUp("c")) {
			Debug.Log("'c' up");
		}
		if (UnityMidiControl.Input.InputManager.GetKeyUp("d")) {
			Debug.Log("'d' up");
		}
	}
}