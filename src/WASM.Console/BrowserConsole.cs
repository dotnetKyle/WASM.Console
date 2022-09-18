using Microsoft.JSInterop;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WASM.Console;

public class BrowserConsole
{
    private readonly IJSRuntime js;

    public BrowserConsole(IJSRuntime js)
    {
        this.js = js;
    }

    public async void Log(string message)
        => await js.InvokeVoidAsync("console.log", message);
    
    public async void Debug(string message)
        => await js.InvokeVoidAsync("console.debug", message);

    public async void Error(string message)
        =>  await js.InvokeVoidAsync("console.error", message);

    public async void Info(string message)
        => await js.InvokeVoidAsync("console.info", message);

    public async void Warn(string message)
        => await js.InvokeVoidAsync("console.warn", message);

    public async void Clear()
        => await js.InvokeVoidAsync("console.clear");

    public async void Count()
        => await js.InvokeVoidAsync("console.count");
    public async void Count(string label)
        => await js.InvokeVoidAsync("console.count", label);

    public async void CountReset()
        => await js.InvokeVoidAsync("console.countReset");
    public async void CountReset(string label)
        => await js.InvokeVoidAsync("console.countReset", label);

    public async void Dir(object obj)
        => await js.InvokeVoidAsync("console.dir", obj);

    public async void Group()
        => await js.InvokeVoidAsync("console.group");
    public async void Group(string label)
        => await js.InvokeVoidAsync("console.group", label);

    public async void GroupEnd()
        => await js.InvokeVoidAsync("console.groupEnd");
    public async void GroupEnd(string label)
        => await js.InvokeVoidAsync("console.groupEnd", label);

    public async void GroupCollapsed()
            => await js.InvokeVoidAsync("console.groupCollapsed");
    public async void GroupCollapsed(string label)
        => await js.InvokeVoidAsync("console.groupCollapsed", label);

    public async void Table(IEnumerable<object> objs)
        => await js.InvokeVoidAsync("console.table", objs);
    public async void Table<TObject>(IEnumerable<TObject> objs)
        => await js.InvokeVoidAsync("console.table", objs);

    public async void Time(string label)
        => await js.InvokeVoidAsync("console.time", label);
    public async void TimeEnd(string label)
        => await js.InvokeVoidAsync("console.timeEnd", label);

    public async void Trace()
        => await js.InvokeVoidAsync("console.trace");

}
