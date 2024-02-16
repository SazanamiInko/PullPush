namespace PullPush.Views;

public partial class ContentLinkAddPage : ContentPage
{
	public ContentLinkAddPage(ContentLinkAddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
