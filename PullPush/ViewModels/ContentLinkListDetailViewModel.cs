namespace PullPush.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class ContentLinkListDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;

    #region MyRegion
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logging"></param>
    public ContentLinkListDetailViewModel(LoggingService logging) : base(logging)
    {
    }
    #endregion

}
