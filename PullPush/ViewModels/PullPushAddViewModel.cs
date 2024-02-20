using Common;

namespace PullPush.ViewModels;

/// <summary>
/// 引出預入登録
/// </summary>
public partial class PullPushAddViewModel : BaseViewModel
{
    #region コンストラクタ

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logging">ロギングサービス</param>
    public PullPushAddViewModel(LoggingService logging) : base(logging)
    {
    }

    #endregion

}
