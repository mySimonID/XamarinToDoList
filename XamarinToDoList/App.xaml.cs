using MasterDetail.Services;
using Xamarin.Forms;
using XamarinToDoList.Views;

namespace XamarinToDoList
{
  public partial class App : Application
  {

    public App()
    {
      InitializeComponent();

      DependencyService.Register<mongoDB>();
      MainPage = new MainPage();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
