using Common;

namespace PullPush.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class SubjectListDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;

    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logging"></param>
    public SubjectListDetailViewModel(LoggingService logging) : base(logging)
    {
    }
    #endregion


}
