namespace PullPush.Views;

public partial class ContentLinkListDetailPage : BaseViewClass
{
	public ContentLinkListDetailPage(ContentLinkListDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
