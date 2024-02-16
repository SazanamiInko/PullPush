namespace PullPush.Views;

public partial class ContentLinkListPage : ContentPage
{
	ContentLinkListViewModel ViewModel;

	public ContentLinkListPage(ContentLinkListViewModel viewModel)
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
