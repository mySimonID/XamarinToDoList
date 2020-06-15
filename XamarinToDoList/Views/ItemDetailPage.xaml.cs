using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinToDoList.Models;
using XamarinToDoList.ViewModels;

namespace XamarinToDoList.Views
{
  // Learn more about making custom code visible in the Xamarin.Forms previewer
  // by visiting https://aka.ms/xamarinforms-previewer

  [DesignTimeVisible(false)]
  public partial class ItemDetailPage : ContentPage
  {
    ItemDetailViewModel viewModel;

    public ItemDetailPage(ItemDetailViewModel viewModel)
    {
      InitializeComponent();

      BindingContext = this.viewModel = viewModel;
    }

    public ItemDetailPage()
    {
      InitializeComponent();

      var item = new Item
      {
        Text = "Item 1",
        Description = "This is an item description."
      };

      viewModel = new ItemDetailViewModel(item);
      BindingContext = viewModel;
    }

    async void Save_Clicked(object sender, EventArgs e)
    {
      MessagingCenter.Send(this, "UpdateItem", viewModel.Item);
      MessagingCenter.Send(this, "UpdateList", viewModel.Item);
      await Navigation.PopAsync();
    }

    async void Delete_Clicked(object sender, EventArgs e)
    {
      var answer = await DisplayAlert("Exit", "Do you want to delete this todo item?", "Yes", "No");
      if (answer)
      {
        MessagingCenter.Send(this, "DeleteItem", viewModel.Item);
        await Navigation.PopAsync(); ;
      }

    }
  }
}