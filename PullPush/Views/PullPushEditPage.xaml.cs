namespace PullPush.Views;

public partial class PullPushEditPage : ContentPage
{
	public PullPushEditPage(PullPushEditViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
