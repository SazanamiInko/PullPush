namespace PullPush.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    #region メッセージ

    /// <summary>
    /// メッセージ
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Messageアクション
    /// </summary>
    public Action Messageaction { get; set; }
    #endregion

    #region メソッド

    /// <summary>
    /// メッセージの表示
    /// </summary>
    /// <param name="message"></param>
    public void DisplayAlert(string message)
    {
        this.Message = message;
        this.Messageaction.Invoke();
    }
    #endregion
}
