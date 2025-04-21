namespace EnviromentalApp;

public partial class App : Application
{
   public App()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.SensorPage), typeof(Views.SensorPage));

        MainPage = new AppShell();

    }
}
