namespace PullPush.Views;

public partial class PullPushListPage : ContentPage
{
	PullPushListViewModel ViewModel;

	public PullPushListPage(PullPushListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override  void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		ViewModel.LoadDataAsync();
	}
}
