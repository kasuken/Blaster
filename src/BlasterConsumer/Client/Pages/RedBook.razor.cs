using Blaster.Abstracts;
using BlasterConsumer.Shared.Events;
using BlasterConsumer.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlasterConsumer.Client.Pages;

public class RedBookBase : ComponentBase, IDisposable
{
    [Inject] private IBlasterService Blaster { get; set; }

    private readonly Guid _redBookId = Guid.NewGuid();

    protected async Task SetRedBook()
    {
        var bookSelected = new BookSelected(_redBookId, "Red Book");
        await Blaster.UpdateStateAsync<SelectedBook>(bookSelected);
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

    ~RedBookBase()
    {
        Dispose(false);
    }
    #endregion
}