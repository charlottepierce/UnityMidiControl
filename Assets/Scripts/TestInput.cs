using UnityEngine;
using System.Collections;
using UnityMidiControl.Input;

public class TestInput : MonoBehaviour {
	void Update () {
		if (InputManager.GetKeyDown("x")) {
			Debug.Log("'x' key pressed");
		}

		if (InputManager.GetKeyUp("x")) {
			Debug.Log("'x' key released");
		}
	}
}
