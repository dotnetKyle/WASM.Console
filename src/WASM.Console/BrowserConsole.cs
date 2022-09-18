using Microsoft.JSInterop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
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
    public async void Log(string message)
        => await js.InvokeVoidAsync("console.log", message);

    /// <summary>
    /// Output a debug message to the browser console.
    /// <para>Debug messages usually are hidden in the browser console, you must set the browser to verbose to see them.</para>
    /// </summary>
    /// <param name="message">The message to output</param>
    public async void Debug(string message)
        => await js.InvokeVoidAsync("console.debug", message);

    /// <summary>
    /// Output an error message to the browser console.
    /// </summary>
    /// <param name="message">The message to output</param>
    public async void Error(string message)
        =>  await js.InvokeVoidAsync("console.error", message);

    /// <summary>
    /// Output an Info message to the browser console.
    /// </summary>
    /// <param name="message">The message to output</param>
    public async void Info(string message)
        => await js.InvokeVoidAsync("console.info", message);

    /// <summary>
    /// Output a Warn message to the browser console.
    /// </summary>
    /// <param name="message">The message to output</param>
    public async void Warn(string message)
        => await js.InvokeVoidAsync("console.warn", message);

    /// <summary>
    /// Clear the browser console.
    /// </summary>
    public async void Clear()
        => await js.InvokeVoidAsync("console.clear");

    /// <summary>
    /// Count the number of times this counter has been called.
    /// </summary>
    public async void Count()
        => await js.InvokeVoidAsync("console.count");

    /// <summary>
    /// Count the number of times this counter has been called (with a specific label).
    /// </summary>
    /// <param name="label"></param>
    public async void Count(string label)
        => await js.InvokeVoidAsync("console.count", label);

    /// <summary>
    /// Reset the default counter (no label).
    /// </summary>
    public async void CountReset()
        => await js.InvokeVoidAsync("console.countReset");

    /// <summary>
    /// Reset a specific counter (using a label).
    /// </summary>
    /// <param name="label"></param>
    public async void CountReset(string label)
        => await js.InvokeVoidAsync("console.countReset", label);

    /// <summary>
    /// Print out all of the properties of an object to the console.
    /// </summary>
    /// <param name="obj">The object to print out</param>
    public async void Dir(object obj)
        => await js.InvokeVoidAsync("console.dir", obj);

    /// <summary>
    /// Group a series of console messages together.
    /// </summary>
    public async void Group()
        => await js.InvokeVoidAsync("console.group");

    /// <summary>
    /// Group a series of console messages together with a specific label.
    /// </summary>
    public async void Group(string label)
        => await js.InvokeVoidAsync("console.group", label);

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
    public async void GroupEnd()
        => await js.InvokeVoidAsync("console.groupEnd");

    /// <summary>
    /// Ends a specific group that has a label.
    /// </summary>
    /// <param name="label">The label of the group to end.</param>
    public async void GroupEnd(string label)
        => await js.InvokeVoidAsync("console.groupEnd", label);

    /// <summary>
    /// Start a group already collapsed.
    /// </summary>
    public async void GroupCollapsed()
            => await js.InvokeVoidAsync("console.groupCollapsed");

    /// <summary>
    /// Start a group already collapsed using a label.
    /// </summary>
    /// <param name="label">The label to use for the group.</param>
    public async void GroupCollapsed(string label)
        => await js.InvokeVoidAsync("console.groupCollapsed", label);

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
    public async void Table(IEnumerable<object> objs)
        => await js.InvokeVoidAsync("console.table", objs);

    /// <summary>
    /// Print a table of objects.
    /// </summary>
    /// <typeparam name="TObject">The type of object.</typeparam>
    /// <param name="objs">The objects to print up.</param>
    public async void Table<TObject>(IEnumerable<TObject> objs)
        => await js.InvokeVoidAsync("console.table", objs);

    /// <summary>
    /// Start a timer.
    /// </summary>
    /// <param name="label">The label to use for the timer.</param>
    public async void Time(string label)
        => await js.InvokeVoidAsync("console.time", label);

    /// <summary>
    /// Start a timer.
    /// </summary>
    /// <param name="label">The label to use for the timer.</param>
    public async void TimeEnd(string label)
        => await js.InvokeVoidAsync("console.timeEnd", label);

    /// <summary>
    /// Print out a browser stack trace.
    /// </summary>
    public async void Trace()
        => await js.InvokeVoidAsync("console.trace");
}
