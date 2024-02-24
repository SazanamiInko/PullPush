using Common;

namespace PullPush.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class PullPushListDetailViewModel : BaseViewModel
{
	[ObservableProperty]
    PullPushViewVuewDataModel item;

    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logging">ロギング</param>
    public PullPushListDetailViewModel(LoggingService logging) : base(logging)
    {
    }
    #endregion

}
