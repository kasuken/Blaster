using Blaster.Abstracts;
using Blaster.Core;
using BlasterConsumer.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlasterConsumer.Client.Pages;

public class BookStateBase : ComponentBase, IDisposable
{
    [Inject] private IBlasterService Blaster { get; set; }

    protected SelectedBook Book = default!;

    protected int CurrentCount = 0;

    protected override void OnInitialized()
    {
        Blaster.NotificationReceived += OnNotificationReceived;

        base.OnInitialized();
    }

    protected void IncrementCount()
    {
        CurrentCount++;
    }

    private void OnNotificationReceived(object? sender, BlasterNotification notification)
    {
        Book = (SelectedBook)notification.Entity;
        StateHasChanged();
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

    ~BookStateBase()
    {
        Dispose(false);
    }
    #endregion
}