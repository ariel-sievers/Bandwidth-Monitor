# Bandwidth-Monitor
A CLI tool to monitor Window's bandwidth usage, developed with C#.

# Running
To run, open project and all of its files inside a compapitble editor (recommend Visual Studio), then build and run.
The command line window should show statistics.

# How does this work?
There are two main files being used: `Monitor.cs` and `Program.cs`.

## Monitor.cs
Most of the work happens in the `Monitor` class, as this is how available networks are collected and how
the statistics should be shown. A few important functions include:

### `GetNetworkInterfaces()`
Get the current available networks and store into a local array.

### `GetBytesSent(NetworkInterface netInt)`
-Return the bytes sent by a particular network.

### `GetBytesReceived(NetworkInterface netInt)`
-Return the bytes received by a particular network.

### `ShowUsage()`
- Get the available networks by calling `GetNetworkInterfaces()`. For each network found,
print the bytes sent and the bytes received in the command line.
- Call another method to format the text being printed.

## Program.cs
This file is responsible for starting the program. It has a couple of functions as well, including the main:

### `StartTimer()`
- Every five seconds, call `UpdateUsage()`.

### `UpdateUsage()`
- Ensure the cursor is in the top left of the command line.
- Call `Monitor.ShowUsage()`.

### `Main()`
- Runs the program.
- Hide the cursor.
- Start the timer with `StartTimer()` and call the first `Monitor.ShowUsage()`.

## TODO
There are a few other files for database usage and the potential to incorporate updates via email. Particularly, email messages would
be handled with `Report.cs`.
