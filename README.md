# Basic Use: #

1. Copy the contents of the __Assets__ folder into your own project
	* alternatively, open the project as-is
2. Click __MIDI Input > Edit Key Mappings__ to open the editor GUI
3. Add key mappings as desired
4. When testing for input, use methods from the class `UnityMidiControl.Input.InputManager` instead of the built-in Unity `Input` class
5. Before running your project, ensure your MIDI device is connected, and the desktop application _MIDI Bridge_ ([Windows](https://github.com/keijiro/unity-midi-bridge/raw/master/midi-bridge-windows.zip); ([OSX](https://github.com/keijiro/unity-midi-bridge/raw/master/midi-bridge-osx.zip))) is running

## Test Script: ##

Prints out messages when _KeyDown_ and _KeyUp_ events are triggered for the 'a', 'b', 'c' and 'd' keys.
To check if the MIDI input is working correctly, create a new `GameObject` and add the __Test__ script to it as an asset.
Then, create mappings for any note numbers to the 'a', 'b', 'c' or 'd' keys.
Run the project and press the note numbers you have mapped on your input device -- this should cause debug messages to print.