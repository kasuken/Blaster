﻿using Microsoft.AspNetCore.Components;

namespace BlasterConsumer.Client.Pages;

public class ChildComponentBase : ComponentBase, IDisposable
{
    protected int CurrentCount = 0;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected void IncrementCount()
    {
        CurrentCount++;
    }

    #region Dispose
    public void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ChildComponentBase()
    {
        Dispose(false);
    }
    #endregion
}