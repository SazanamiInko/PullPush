using AutoMapper;
using Common;
using FLayer.APIs;
using FLayer.Responses;
using Interfaces.DataModel;

namespace PullPush.ViewModels;

public partial class PullPushListViewModel : BaseViewModel
{
    #region 即時プロパティ

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<IPullPushView> items;

    #endregion

    #region コンストラクタ

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="logging"></param>
    public PullPushListViewModel(LoggingService logging) : base(logging)
    {
        this.Items = new ObservableCollection<IPullPushView>();
    }

    #endregion

    #region イベント

    /// <summary>
    /// 再表示
    /// </summary>
    [RelayCommand]
    private async void OnRefreshing()
    {
        IsRefreshing = true;

        try
        {
            LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    /// <summary>
    /// もっと読む
    /// </summary>
    [RelayCommand]
    public void LoadMore()
    {

        this.SetData();
    }

    /// <summary>
    /// データ読み込み
    /// </summary>
    public void LoadDataAsync()
    {
        this.SetData();
    }

    /// <summary>
    /// 詳細表示移動
    /// </summary>D
    /// <param name="item">詳細表示</param>
    [RelayCommand]
    private async void GoToDetails(PullPushViewVuewDataModel item)
    {
        await Shell.Current.GoToAsync(nameof(PullPushListDetailPage), true, new Dictionary<string, object>
        {
            { "Item", item }
        });
    }

    #endregion

    #region 処理
   /// <summary>
   /// データをセット
   /// </summary>
    private void SetData()
    {
        var res = API.GetPullPush();
        if (res == null)
        {
            return;
        }

        if (res is PullPushResponse)
        {
            PullPushResponse resp = res as PullPushResponse;
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<IPullPushView, PullPushViewVuewDataModel>(); });
            Mapper map = new Mapper(config);
            foreach (var item in resp.Items)
            {

                Items.Add(map.Map<PullPushViewVuewDataModel>(item));
            }

        }
    }
    #endregion


}
