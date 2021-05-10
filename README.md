Allows for a connection from an X-Input Controller, connected to a Windows PC, to an Arduino, connected to an Gamecube Port.
Effectively, having the X-Input Controller control behave like a Gamecube Controller.

There are a few frames of delay, and at times there are connection issues for a frame.
If there are any connection issues ending in no data to be send, the Data of the prior frame is getting reused.
The chance that you made a big change on that one frame is relatively slim, making it pretty much unnoticeble.

Usecases:
Connecting an XBox Controller to a GC
Using a program like Parsec to get Friends to play on your real Gamecube by sending their Inputs as a Virtual XBox 360 Pad (There seem to be some issues on this).
Using this as a Jumping off point for things like Twitch Plays using an actual GameCube.

Setup the Arduino:
You'll need
- an 16MHz Arduino (I'm using an Arduino Nano, though Uno and most other Models should work just as fine.)
-- Make sure you can connect it to your PC. The Nano and Uno both have a USB Port, making that very simple.
- A Logic Level Converter (those are really cheap and are going to prevent you from frying your gamecube)
- A 1kΩ Resistor
- A Gamecube Extension Cord
- (Optional)
-- Breadboards. Those make it simple to quickly assemble stuff, but are big.
-- A Project Box. Those are not very expensive, but are easily modifiable with some tools and make the Adapter look very finished, compared to just some PCBs dangling off your GameCube

- Soldering Iron or Crimp Equipment.
-- The Soldering would be simple and might be required for any Arduino that doesn't come with simple 