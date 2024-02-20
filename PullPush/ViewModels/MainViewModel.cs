using Common;
using FLayer.APIs;

namespace PullPush.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logging"></param>
    public MainViewModel(LoggingService logging) : base(logging)
    {
        API.InitializeAPI(logging);
    }
    #endregion

}
