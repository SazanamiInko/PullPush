namespace PullPush.Views;

public partial class PullPushListDetailPage : ContentPage
{
	public PullPushListDetailPage(PullPushListDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.Loaded += PullPushListDetailPage_Loaded;
	}

    private void PullPushListDetailPage_Loaded(object sender, EventArgs e)
    {
      var vm= BindingContext as PullPushListDetailViewModel;
        vm.SetSubjects();
    }
}
