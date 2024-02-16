namespace PullPush.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class SubjectListDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;
}
