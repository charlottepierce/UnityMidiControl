using UnityEngine;
using System.Collections;
using UnityMidiControl;

public class TestInput : MonoBehaviour {
	void Start() {
		InputManager.AddKeyMapping("x", 60);
		Debug.Log("Added mapping for 'x' to be triggered by note number 60 (middle C)");
	}

	void Update () {
		if (InputManager.GetKeyDown("x")) {
			Debug.Log("'x' key pressed");
		}

		if (InputManager.GetKeyUp("x")) {
			Debug.Log("'x' key released");
		}

		if (InputManager.GetKey("x")) {
			Debug.Log("'x' key held");
		}
	}
}
