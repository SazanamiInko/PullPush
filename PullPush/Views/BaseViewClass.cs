namespace PullPush.Views
{
    /// <summary>
    /// ベースView
    /// </summary>
    public abstract class BaseViewClass:ContentPage
    {
        #region メソッド

        /// <summary>
        /// メッセージボックスの表示
        /// </summary>
        protected void DisplayMessage()
        {
            var viewmodel = this.BindingContext;

            if(viewmodel is BaseViewModel)
            { 
                BaseViewModel bvm = (BaseViewModel)viewmodel;
                DisplayAlert(this.Title, bvm.Message, "OK");
            }
        }

        /// <summary>
        /// ビューモデル変更イベント
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var viewmodel = this.BindingContext;

            if (viewmodel is BaseViewModel)
            {
                BaseViewModel bvm = (BaseViewModel)viewmodel;
                bvm.Messageaction = DisplayMessage;
            }
        }

        #endregion
    }
}
