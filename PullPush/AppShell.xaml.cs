namespace PullPush;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(PullPushListDetailPage), typeof(PullPushListDetailPage));
		Routing.RegisterRoute(nameof(ContentLinkListDetailPage), typeof(ContentLinkListDetailPage));
		Routing.RegisterRoute(nameof(SubjectListDetailPage), typeof(SubjectListDetailPage));
	}
}
