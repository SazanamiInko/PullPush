namespace PullPush.Views;

public partial class SubjectAdPage : BaseViewClass
{
	public SubjectAdPage(SubjectAdViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
