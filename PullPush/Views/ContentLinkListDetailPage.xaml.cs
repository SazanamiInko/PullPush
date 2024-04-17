namespace PullPush.Views;

public partial class ContentLinkListDetailPage : BaseViewClass
{
	public ContentLinkListDetailPage(ContentLinkListDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        Loaded += ContentLinkListDetailPage_Loaded;
	}

    private void ContentLinkListDetailPage_Loaded(object sender, EventArgs e)
    {
        var viewmodel = BindingContext as ContentLinkListDetailViewModel;
        viewmodel.SetSubjects();
    }
}
