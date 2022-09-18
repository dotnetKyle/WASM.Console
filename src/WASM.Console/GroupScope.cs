using Microsoft.JSInterop;
using System;

namespace WASM.Console;

public class GroupScope : IDisposable
{
    readonly string? label;
    readonly IJSRuntime js;

    public GroupScope(IJSRuntime js, string label)
    {
        this.js = js;
        this.label = label;
    }
    public GroupScope(IJSRuntime js)
    {
        this.js = js;
        label = null;
    }

    public async void Dispose()
    {
        if (label is null)
            await js.InvokeVoidAsync("console.groupEnd");
        else
            await js.InvokeVoidAsync("console.groupEnd", label);
    }
}
