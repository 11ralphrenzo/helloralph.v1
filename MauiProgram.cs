using CommunityToolkit.Maui;
using helloralph.Custom;
using helloralph.Interfaces;
using helloralph.Services;
using helloralph.Utilities.DefaultHttpClient;
using helloralph.ViewModels;
using helloralph.Views;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.ListView.Hosting;

namespace helloralph;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSkiaSharp()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Inter-Bold.otf", "InterBold");
                fonts.AddFont("Crafty-Regular.ttf", "CraftyRegular");
                fonts.AddFont("Jaldi-Bold.ttf", "JaldiBold");
                fonts.AddFont("Jaldi-Regular.ttf", "JaldiRegular");
                fonts.AddFont("Lato-Regular.ttf", "LatoRegular");
                fonts.AddFont("fontello.ttf", "Icons");

            });

        //Services - Views
        builder.Services.AddSingleton<AboutMePage>();
        builder.Services.AddSingleton<WelcomePage>();
        builder.Services.AddSingleton<ColorMakerPage>();
        builder.Services.AddSingleton<PerfectPayPage>();
        builder.Services.AddSingleton<CodeQuotesPage>();
        builder.Services.AddSingleton<HangmanPage>();
        builder.Services.AddSingleton<BMICalculatorPage>();
        builder.Services.AddSingleton<MenuPage>();
        builder.Services.AddTransient<ConverterPage>();
        builder.Services.AddSingleton<CalculatorPage>();
        builder.Services.AddSingleton<WeatherPage>();
        builder.Services.AddSingleton<TaskerPage>();
        builder.Services.AddTransient<AddNewTaskPage>();
        builder.Services.AddSingleton<ProsperDailyPage>();
        builder.Services.AddSingleton<SfAvatarPage>();
        builder.Services.AddSingleton<SfBarcodeGeneratorPage>();
        builder.Services.AddSingleton<SfBadgePage>();
        builder.Services.AddSingleton<SfBusyIndicatorPage>();
        builder.Services.AddSingleton<AppInfoPage>();
        builder.Services.AddSingleton<DeviceInfoPage>();
        builder.Services.AddSingleton<BatteryInfoPage>();
        builder.Services.AddSingleton<RESTIntegrationPage>();
        builder.Services.AddTransient<ExecuteRESTPage>();
        builder.Services.AddTransient<UserDetailsPage>();
        builder.Services.AddTransient<AddEditUserPage>();
        builder.Services.AddSingleton<GeocodingPage>();
        builder.Services.AddTransient<GetLocationPage>();
        builder.Services.AddSingleton<GeolocationPage>();
        builder.Services.AddSingleton<MediaPickerPage>();
        builder.Services.AddTransient<PickOrCapturePhotoPage>();
        builder.Services.AddSingleton<BiometricsPage>();
        builder.Services.AddSingleton<DrawingPage>();


        //Services - ViewModels
        builder.Services.AddSingleton<BaseViewModel>();
        builder.Services.AddSingleton<AboutMeViewModel>();
        builder.Services.AddSingleton<ColorMakerViewModel>();
        builder.Services.AddSingleton<PerfectPayViewModel>();
        builder.Services.AddSingleton<CodeQuotesViewModel>();
        builder.Services.AddSingleton<HangmanViewModel>();
        builder.Services.AddSingleton<BMICalculatorViewModel>();
        builder.Services.AddSingleton<MenuViewModel>();
        builder.Services.AddTransient<ConverterPage>();
        builder.Services.AddSingleton<CalculatorViewModel>();
        builder.Services.AddSingleton<WeatherViewModel>();
        builder.Services.AddSingleton<TaskerViewModel>();
        builder.Services.AddTransient<AddNewTaskViewModel>();
        builder.Services.AddSingleton<ProperDailyViewModel>();
        builder.Services.AddTransient<ConverterViewModel>();
        builder.Services.AddSingleton<SfAvatarViewModel>();
        builder.Services.AddSingleton<SfBarcodeGeneratorViewModel>();
        builder.Services.AddSingleton<SfBadgeViewModel>();
        builder.Services.AddSingleton<SfBusyIndicatorViewModel>();
        builder.Services.AddSingleton<AppInfoViewModel>();
        builder.Services.AddSingleton<DeviceInfoViewModel>();
        builder.Services.AddSingleton<BatteryInfoViewModel>();
        builder.Services.AddTransient<ExecuteRESTViewModel>();
        builder.Services.AddTransient<UserDetailsViewModel>();
        builder.Services.AddTransient<AddEditUserViewModel>();
        builder.Services.AddScoped<GeocodingViewModel>();
        builder.Services.AddTransient<GetLocationViewModel>();
        builder.Services.AddScoped<GeolocationViewModel>();
        builder.Services.AddScoped<MediaPickerViewModel>();
        builder.Services.AddTransient<PickOrCapturePhotoViewModel>();
        builder.Services.AddSingleton<BiometricsViewModel>();
        builder.Services.AddSingleton<DrawingViewModel>();

        // Services - Others
        builder.Services.AddSingleton<AppHttpClient>();
        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IBattery>(Battery.Default);
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeocoding>(Geocoding.Default);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMediaPicker>(MediaPicker.Default);
        builder.Services.AddSingleton<IFingerprint>(CrossFingerprint.Current);
        builder.Services.AddSingleton<IBiometricsService>(BiometricsService.Current);

        // Syncfusion
        builder.ConfigureSyncfusionListView();

        return builder.Build();
	}
}
