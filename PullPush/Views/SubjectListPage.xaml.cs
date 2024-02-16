namespace PullPush.Views;

public partial class SubjectListPage : ContentPage
{
	SubjectListViewModel ViewModel;

	public SubjectListPage(SubjectListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
