namespace PullPush;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<SubjectListDetailViewModel>();
		builder.Services.AddTransient<SubjectListDetailPage>();

		builder.Services.AddSingleton<SubjectListViewModel>();

		builder.Services.AddSingleton<SubjectListPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<ContentLinkListDetailViewModel>();
		builder.Services.AddTransient<ContentLinkListDetailPage>();

		builder.Services.AddSingleton<ContentLinkListViewModel>();

		builder.Services.AddSingleton<ContentLinkListPage>();

		builder.Services.AddSingleton<SubjectAdViewModel>();

		builder.Services.AddSingleton<SubjectAdPage>();

		builder.Services.AddSingleton<ContentLinkAddViewModel>();

		builder.Services.AddSingleton<ContentLinkAddPage>();

		builder.Services.AddSingleton<PullPushEditViewModel>();

		builder.Services.AddSingleton<PullPushEditPage>();

		builder.Services.AddSingleton<PullPushAddViewModel>();

		builder.Services.AddSingleton<PullPushAddPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<PullPushListDetailViewModel>();
		builder.Services.AddTransient<PullPushListDetailPage>();

		builder.Services.AddSingleton<PullPushListViewModel>();

		builder.Services.AddSingleton<PullPushListPage>();

		return builder.Build();
	}
}
