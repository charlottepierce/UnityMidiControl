Use MIDI instruments as game controllers!

This Unity interface allows you to map MIDI inputs to keyboard buttons - play the mapped input on your instrument to trigger the corresponding key press.
Any instrument detected by UnityMidiBridge ([Windows](https://github.com/keijiro/unity-midi-bridge/raw/master/midi-bridge-windows.zip); [OSX](https://github.com/keijiro/unity-midi-bridge/raw/master/midi-bridge-osx.zip)) should work with this interface.

The interface currently supports `GetKey`, `GetKeyDown` and `GetKeyUp` events for all keyboard buttons.
Direct button presses (i.e., using the keyboard rather than a mapped instrument) will still be detected.

UnityMidiControl was tested on Unity version __4.6.2f1__ and is known to cause crashes on Unity version 4.6.1f1.

## Use: ##

1. Import keijiro's [MIDI Jack](https://github.com/keijiro/MidiJack) into your Unity project
2. Copy the appropriate .dll from `MidiJack/Plugins/` to the __root__ folder of your Unity project
3. Copy the contents of __Assets__ into the _Assets_ folder of your project
4. In Unity, click __MIDI Input > Edit Key Mappings__ to open the editor GUI
5. Add key mappings as desired
	* mappings can be removed using the '-' buttons
6. Click __Save Mappings__
7. In your game code, replace calls to `Input.GetKey`, `Input.GetKeyDown` and `Input.GetKeyUp` with `UnityMidiControl.Input.InputManager.GetKey`, `UnityMidiControl.Input.InputManager.GetKeyDown` and `UnityMidiControl.Input.InputManager.GetKeyUp`, respectively
8. Before running your project, ensure your MIDI device is connected

## Example Use: ##

The following note mappings trigger:

* the 'x' key when note number 36 is played
* the 'd' key when note number 50 is played
* the 'a' key when a control knob on channel 22 has a value between 3 (exclusive) and 75 (inclusive)

![Example key mappings](https://bitbucket.org/charlottepierce/unitymidicontrol/raw/master/example_mappings.png)

These keypresses may be detected programmatically using the following code:

	if (UnityMidiControl.Input.InputManager.GetKeyDown("x")) {
		Debug.Log("'x' down");
	}
	if (UnityMidiControl.Input.InputManager.GetKeyDown("d")) {
		Debug.Log("'d' down");
	}
	if (UnityMidiControl.Input.InputManager.GetKeyDown("a")) {
		Debug.Log("'a' down");
	}
	
Using key codes rather than string arguments will also work:

	if (UnityMidiControl.Input.InputManager.GetKeyUp(KeyCode.X)) {
		Debug.Log("'x' up");
	}
	if (UnityMidiControl.Input.InputManager.GetKeyUp(KeyCode.D)) {
		Debug.Log("'d' up");
	}
	if (UnityMidiControl.Input.InputManager.GetKeyUp(KeyCode.A)) {
		Debug.Log("'a' up");
	}