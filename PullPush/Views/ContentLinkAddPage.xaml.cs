namespace PullPush.Views;

public partial class ContentLinkAddPage : BaseViewClass
{
	public ContentLinkAddPage(ContentLinkAddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
