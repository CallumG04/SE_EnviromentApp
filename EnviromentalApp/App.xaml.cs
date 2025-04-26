namespace EnviromentalApp;

public partial class App : Application
{
   public App()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.AllSensorsPage), typeof(Views.AllSensorsPage));
        Routing.RegisterRoute(nameof(Views.SensorPage), typeof(Views.SensorPage));
        Routing.RegisterRoute(nameof(Views.AllUsersPage), typeof(Views.AllUsersPage));
        Routing.RegisterRoute(nameof(Views.ManageUserPage), typeof(Views.ManageUserPage));
        Routing.RegisterRoute(nameof(Views.AllSensorAccountsPage), typeof(Views.AllSensorAccountsPage));
        Routing.RegisterRoute(nameof(Views.ManageSensorAccountPage), typeof(Views.ManageSensorAccountPage));
        Routing.RegisterRoute(nameof(Views.AllTicketsPage), typeof(Views.AllTicketsPage));
        Routing.RegisterRoute(nameof(Views.TicketPage), typeof(Views.TicketPage));
        Routing.RegisterRoute(nameof(Views.AllWeatherMeasurementsPage), typeof(Views.AllWeatherMeasurementsPage));
        Routing.RegisterRoute(nameof(Views.WeatherMeasurementPage), typeof(Views.WeatherMeasurementPage));
        Routing.RegisterRoute(nameof(Views.AllAirQualityMeasurementsPage), typeof(Views.AllAirQualityMeasurementsPage));

        MainPage = new AppShell();

    }
}
