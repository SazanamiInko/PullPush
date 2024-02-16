namespace PullPush.Views;

public partial class PullPushListDetailPage : ContentPage
{
	public PullPushListDetailPage(PullPushListDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
