using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinToDoList.Models;
using XamarinToDoList.Views;

namespace XamarinToDoList.ViewModels
{
  public class ItemsViewModel : BaseViewModel
  {
    public ObservableCollection<Item> Items { get; set; }
    public Command LoadItemsCommand { get; set; }

    public ItemsViewModel()
    {
      Title = "Browse";
      Items = new ObservableCollection<Item>();
      LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

      MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
      {
        var newItem = item as Item;
        await DataStore.AddItemAsync(newItem);
        Task.Run(async () => await ExecuteLoadItemsCommand()).Wait();
      });

      MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "UpdateItem", async (obj, item) =>
      {
        await DataStore.UpdateItemAsync(item);
        Task.Run(async () => await ExecuteLoadItemsCommand()).Wait();
      });

      MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "UpdateList", async (obj, item) =>
      {
        await ExecuteLoadItemsCommand();

      });

      MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "DeleteItem", async (obj, item) =>
      {
        await DataStore.DeleteItemAsync(item.Id);
        Task.Run(async () => await ExecuteLoadItemsCommand()).Wait();
      });

    }

    async Task ExecuteLoadItemsCommand()
    {
      IsBusy = true;

      try
      {
        Items.Clear();
        var items = await DataStore.GetItemsAsync(true);
        foreach (var item in items)
        {
          Items.Add(item);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }
      finally
      {
        IsBusy = false;
      }
    }
  }
}