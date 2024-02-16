namespace PullPush.Views;

public partial class ContentLinkListDetailPage : ContentPage
{
	public ContentLinkListDetailPage(ContentLinkListDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
