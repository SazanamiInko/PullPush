namespace PullPush.ViewModels;

public partial class ContentLinkListViewModel : BaseViewModel
{
	readonly SampleDataService dataService;

	[ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	ObservableCollection<SampleItem> items;

	public ContentLinkListViewModel(SampleDataService service,
		             LoggingService logging):base(logging)
	{
		dataService = service;
	}

	[RelayCommand]
	private async void OnRefreshing()
	{
		this.IsRefreshing = true;

		try
		{
			await LoadDataAsync();
		}
		finally
		{
			this.IsRefreshing = false;
		}
	}

	[RelayCommand]
	public async Task LoadMore()
	{
		var items = await dataService.GetItems();

		foreach (var item in items)
		{
			Items.Add(item);
		}
	}

	public async Task LoadDataAsync()
	{
		Items = new ObservableCollection<SampleItem>(await dataService.GetItems());
	}

	[RelayCommand]
	private async void GoToDetails(SampleItem item)
	{
		await Shell.Current.GoToAsync(nameof(ContentLinkListDetailPage), true, new Dictionary<string, object>
		{
			{ "Item", item }
		});
	}
}
