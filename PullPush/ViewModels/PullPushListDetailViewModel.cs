using Common;

namespace PullPush.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class PullPushListDetailViewModel : BaseViewModel
{
    #region 即時プロパティ

    /// <summary>
    /// 表示対象
    /// </summary>
    [ObservableProperty]
    PullPushViewVuewDataModel item;


    #endregion


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
