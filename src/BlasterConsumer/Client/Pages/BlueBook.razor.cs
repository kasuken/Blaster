using Blaster.Abstracts;
using BlasterConsumer.Shared.Events;
using BlasterConsumer.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlasterConsumer.Client.Pages;

public class BlueBookBase : ComponentBase, IDisposable
{
    [Inject] private IBlasterService Blaster { get; set; }

    private readonly Guid _blueBookId = Guid.NewGuid();

    protected async Task SetBlueBook()
    {
        var bookSelected = new BookSelected(_blueBookId, "Blue Book");
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

    ~BlueBookBase()
    {
        Dispose(false);
    }
    #endregion
}