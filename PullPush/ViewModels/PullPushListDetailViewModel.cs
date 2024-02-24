using Common;

namespace PullPush.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class PullPushListDetailViewModel : BaseViewModel
{
	[ObservableProperty]
    PullPushViewVuewDataModel item;

    #region コンストラクタ
    public PullPushListDetailViewModel(LoggingService logging) : base(logging)
    {
    }
    #endregion

}
