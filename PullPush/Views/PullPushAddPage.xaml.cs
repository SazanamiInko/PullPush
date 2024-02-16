namespace PullPush.Views;

public partial class PullPushAddPage : ContentPage
{
	public PullPushAddPage(PullPushAddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
