using System.Reflection;
using EnviromentalApp.ViewModels;
using EnviromentalApp.Data;
using EnviromentalApp.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace EnviromentalApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

			var a = Assembly.GetExecutingAssembly();
			using var stream = a.GetManifestResourceStream("EnviromentalApp.appsettings.json");
				
			var config = new ConfigurationBuilder()
				.AddJsonStream(stream)
				.Build();
				
			builder.Configuration.AddConfiguration(config);

			var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
			builder.Services.AddDbContext<SensorsDbContext>(options => options.UseSqlServer(connectionString));
			builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(connectionString));
			builder.Services.AddDbContext<TicketsDbContext>(options => options.UseSqlServer(connectionString));
			builder.Services.AddDbContext<WeatherMeasurementDbContext>(options => options.UseSqlServer(connectionString));

			builder.Services.AddSingleton<SensorsViewModel>();
			builder.Services.AddTransient<SensorViewModel>();

			builder.Services.AddSingleton<AllSensorsPage>();
			builder.Services.AddTransient<SensorPage>();

			builder.Services.AddSingleton<ManageUsersViewModel>();
			builder.Services.AddTransient<ManageUserViewModel>();

			builder.Services.AddSingleton<AllUsersPage>();
			builder.Services.AddTransient<ManageUserPage>();

			builder.Services.AddSingleton<ManageSensorAccountsViewModel>();
			builder.Services.AddTransient<ManageSensorAccountViewModel>();

			builder.Services.AddSingleton<AllSensorAccountsPage>();
			builder.Services.AddTransient<ManageSensorAccountPage>();

			builder.Services.AddSingleton<TicketsViewModel>();
			builder.Services.AddTransient<TicketViewModel>();

			builder.Services.AddSingleton<AllTicketsPage>();
			builder.Services.AddTransient<TicketPage>();

			builder.Services.AddSingleton<AllWeatherMeasurementsViewModel>();
			builder.Services.AddTransient<WeatherMeasurementViewModel>();

			builder.Services.AddSingleton<AllWeatherMeasurementsPage>();
			builder.Services.AddTransient<WeatherMeasurementPage>();

    



#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
