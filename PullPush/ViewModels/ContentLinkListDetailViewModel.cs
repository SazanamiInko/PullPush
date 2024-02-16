namespace PullPush.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class ContentLinkListDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;
}
