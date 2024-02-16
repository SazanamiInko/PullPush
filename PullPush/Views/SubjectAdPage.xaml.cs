namespace PullPush.Views;

public partial class SubjectAdPage : ContentPage
{
	public SubjectAdPage(SubjectAdViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
