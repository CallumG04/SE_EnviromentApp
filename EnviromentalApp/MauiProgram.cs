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
			//builder.Services.AddDbContext<NotesDbContext>(options => options.UseSqlServer(connectionString));
			builder.Services.AddDbContext<SensorsDbContext>(options => options.UseSqlServer(connectionString));

			builder.Services.AddSingleton<SensorsViewModel>();
			builder.Services.AddTransient<SensorViewModel>();

			builder.Services.AddSingleton<AllSensorsPage>();
			builder.Services.AddTransient<SensorPage>();




#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
