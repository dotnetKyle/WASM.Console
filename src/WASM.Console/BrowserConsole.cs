using Microsoft.JSInterop;
using System;

namespace WASM.Console;

public class BrowserConsole
{
    private readonly IJSRuntime js;

    public BrowserConsole(IJSRuntime js)
    {
        this.js = js;
    }

    public async void Log(string message)
    {
        await js.InvokeVoidAsync("console.log", message);
    }
    public async void Debug(string message)
    {
        await js.InvokeVoidAsync("console.debug", message);
    }

    public async void Error(string message)
    {
        await js.InvokeVoidAsync("console.error", message);
    }

    public async void Info(string message)
    {
        await js.InvokeVoidAsync("console.info", message);
    }

    public async void Warn(string message)
    {
        await js.InvokeVoidAsync("console.warn", message);
    }

    public async void Clear()
    {
        await js.InvokeVoidAsync("console.clear");
    }
    public async void Count()
    {
        await js.InvokeVoidAsync("console.count");
    }
    public async void Count(string label)
    {
        await js.InvokeVoidAsync("console.count", label);
    }
    public async void CountReset()
    {
        await js.InvokeVoidAsync("console.countReset");
    }
    public async void CountReset(string label)
    {
        await js.InvokeVoidAsync("console.countReset", label);
    }
}
