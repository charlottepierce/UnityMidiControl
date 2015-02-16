using UnityEngine;
using System.Collections;
using UnityMidiControl;

public class TestInput : MonoBehaviour {
	void Start() {
		InputManager.AddKeyMapping("x", "b");
		Debug.Log("Added mapping for 'x' to be triggered by 'b' key");
	}

	void Update () {
		if (InputManager.GetKeyDown("x")) {
			Debug.Log("'x' key pressed");
		}
		if (InputManager.GetKeyDown("b")) {
			Debug.Log("'b' key pressed");
		}
	}
}
