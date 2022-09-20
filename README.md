# WASM.Console

A Blazor library for writing to the browser console in C#
using .

Supports: `console.log`, `console.debug`, `console.info`, `console.warn`, `console.error`, `console.dir`, and more.

Add the following nuget package:

```powershell
nuget install WASM.Console
```

Example:

```csharp
using WASM.Console;

var console = new BrowserConsole();

// The different log message types
await console.LogAsync("A simple log message.");
// you may need to turn on Verbose to see debug level messages
await console.DebugAsync("Logs an Debug level message.");
await console.InfoAsync("Logs an Info level message.");
await console.WarnAsync("Logs an Warning level message.");
await console.ErrorAsync("Logs an Error level message.");

// group messages together:
using(await console.GroupAsync())
{
	await console.LogAsync("Grouped log message 1.");
	await console.LogAsync("Grouped log message 2.");
	await console.LogAsync("Grouped log message 3.");
	// when the group is disposed console.GroupEnd() will automatically be called.
}

// print an object's properties
var obj = new {
	Prop1 = "Test Property 1",
	Prop2 = "Test Property 2"
};
await console.DirAsync(obj);

// print a table
var objArray = new[]
{
	new { Id = Guid.NewGuid(), Prop1 = "test prop 1" },
	new { Id = Guid.NewGuid(), Prop1 = "test prop 2" },
	new { Id = Guid.NewGuid(), Prop1 = "test prop 3" },
	new { Id = Guid.NewGuid(), Prop1 = "test prop 4" },
	new { Id = Guid.NewGuid(), Prop1 = "test prop 5" }
}
await console.TableAsync(objArray);

// start and end a timer
await console.TimeAsync("timer 1");
await console.TimeEndAsync("timer 1");
```