namespace PullPush.Views;

public partial class SubjectListDetailPage : ContentPage
{
	public SubjectListDetailPage(SubjectListDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
