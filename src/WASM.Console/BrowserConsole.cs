using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WASM.Console;

public class BrowserConsole
{
    private readonly IJSRuntime js;

    public BrowserConsole(IJSRuntime js)
    {
        this.js = js;
    }

    /// <summary>
    /// Output a typical log message to the browser console.
    /// </summary>
    /// <param name="message">The message to output</param>
    public async Task LogAsync(string message)
        => await js.InvokeVoidAsync("console.log", message);

    /// <summary>
    /// Output a debug message to the browser console.
    /// <para>Debug messages usually are hidden in the browser console, you must set the browser to verbose to see them.</para>
    /// </summary>
    /// <param name="message">The message to output</param>
    public async Task DebugAsync(string message)
        => await js.InvokeVoidAsync("console.debug", message);

    /// <summary>
    /// Output an error message to the browser console.
    /// </summary>
    /// <param name="message">The message to output</param>
    public async Task ErrorAsync(string message)
        =>  await js.InvokeVoidAsync("console.error", message);

    /// <summary>
    /// Output an Info message to the browser console.
    /// </summary>
    /// <param name="message">The message to output</param>
    public async Task InfoAsync(string message)
        => await js.InvokeVoidAsync("console.info", message);

    /// <summary>
    /// Output a Warn message to the browser console.
    /// </summary>
    /// <param name="message">The message to output</param>
    public async Task WarnAsync(string message)
        => await js.InvokeVoidAsync("console.warn", message);

    /// <summary>
    /// Clear the browser console.
    /// </summary>
    public async Task ClearAsync()
        => await js.InvokeVoidAsync("console.clear");

    /// <summary>
    /// Count the number of times this counter has been called.
    /// </summary>
    public async Task CountAsync()
        => await js.InvokeVoidAsync("console.count");

    /// <summary>
    /// Count the number of times this counter has been called (with a specific label).
    /// </summary>
    /// <param name="label"></param>
    public async Task CountAsync(string label)
        => await js.InvokeVoidAsync("console.count", label);

    /// <summary>
    /// Reset the default counter (no label).
    /// </summary>
    public async Task CountResetAsync()
        => await js.InvokeVoidAsync("console.countReset");

    /// <summary>
    /// Reset a specific counter (using a label).
    /// </summary>
    /// <param name="label"></param>
    public async Task CountResetAsync(string label)
        => await js.InvokeVoidAsync("console.countReset", label);

    /// <summary>
    /// Print out all of the properties of an object to the console.
    /// </summary>
    /// <param name="obj">The object to print out</param>
    public async Task DirAsync(object obj)
        => await js.InvokeVoidAsync("console.dir", obj);

    /// <summary>
    /// Group a series of console messages together.
    /// </summary>
    /// <returns>Returns an IDisposable that ends the group when disposed.</returns>
    public async Task<IDisposable> GroupAsync()
    {
        await js.InvokeVoidAsync("console.group");
        return new GroupScope(js);
    }

    /// <summary>
    /// Group a series of console messages together with a label.
    /// </summary>
    /// <param name="label"></param>
    /// <returns>Returns an IDisposable that ends the group when disposed.</returns>
    public async Task<IDisposable> GroupAsync(string label)
    {
        await js.InvokeVoidAsync("console.group", label);
        return new GroupScope(js, label);
    }

    /// <summary>
    /// Ends the current group
    /// </summary>
    public async Task GroupEndAsync()
        => await js.InvokeVoidAsync("console.groupEnd");

    /// <summary>
    /// Ends a specific group that has a label.
    /// </summary>
    /// <param name="label">The label of the group to end.</param>
    public async Task GroupEndAsync(string label)
        => await js.InvokeVoidAsync("console.groupEnd", label);

    /// <summary>
    /// Ends a specific group that has a label.
    /// </summary>
    /// <param name="label">The label of the group to end.</param>
    public async Task GroupEndAsync(GroupScope groupScope)
        => await js.InvokeVoidAsync("console.groupEnd", groupScope.Label);

    /// <summary>
    /// Start a group that automatically ends itself.
    /// </summary>
    /// <returns>Returns an IDisposable that ends the group when disposed.</returns>
    public async Task<IDisposable> GroupCollapsedAsync()
    {
        await js.InvokeVoidAsync("console.groupCollapsed");
        return new GroupScope(js);
    }

    /// <summary>
    /// Start a group with a label that automatically ends itself.
    /// </summary>
    /// <param name="label">The label to use for the group.</param>
    /// <returns>Returns an IDisposable that ends the group when disposed.</returns>
    public async Task<IDisposable> GroupCollapsedAsync(string label)
    {
        await js.InvokeVoidAsync("console.groupCollapsed", label);
        return new GroupScope(js, label);
    }

    /// <summary>
    /// Print a table of objects.
    /// </summary>
    /// <param name="objs">The objects to print up.</param>
    public async Task TableAsync(IEnumerable<object> objs)
        => await js.InvokeVoidAsync("console.table", objs);

    /// <summary>
    /// Print a table of objects.
    /// </summary>
    /// <typeparam name="TObject">The type of object.</typeparam>
    /// <param name="objs">The objects to print up.</param>
    public async Task TableAsync<TObject>(IEnumerable<TObject> objs)
        => await js.InvokeVoidAsync("console.table", objs);

    /// <summary>
    /// Start a timer.
    /// </summary>
    /// <param name="label">The label to use for the timer.</param>
    public async Task TimeAsync(string label)
        => await js.InvokeVoidAsync("console.time", label);

    /// <summary>
    /// Start a timer.
    /// </summary>
    /// <param name="label">The label to use for the timer.</param>
    public async Task TimeEndAsync(string label)
        => await js.InvokeVoidAsync("console.timeEnd", label);

    /// <summary>
    /// Print out a browser stack trace.
    /// </summary>
    public async Task TraceAsync()
        => await js.InvokeVoidAsync("console.trace");
}
