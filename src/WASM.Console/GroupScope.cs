using Microsoft.JSInterop;
using System;

namespace WASM.Console;

public class GroupScope : IDisposable
{
    public string? Label { get; init; }
    readonly IJSRuntime js;

    public GroupScope(IJSRuntime js, string label)
    {
        this.js = js;
        this.Label = label;
    }
    public GroupScope(IJSRuntime js)
    {
        this.js = js;
        Label = null;
    }

    public async void Dispose()
    {
        if (Label is null)
            await js.InvokeVoidAsync("console.groupEnd");
        else
            await js.InvokeVoidAsync("console.groupEnd", Label);
    }
}
