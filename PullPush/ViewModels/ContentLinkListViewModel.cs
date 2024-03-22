using AutoMapper;
using Common;
using FLayer.APIs;
using FLayer.Responses;
using Interfaces.DataModel;

namespace PullPush.ViewModels;

/// <summary>
/// 紐づけルール一覧画面ビューモデル
/// </summary>
public partial class ContentLinkListViewModel : BaseViewModel
{
    #region プロパティ
	/// <summary>
	/// 更新
	/// </summary>
    [ObservableProperty]
    bool isRefreshing;

	/// <summary>
	/// アイテム
	/// </summary>
    [ObservableProperty]
    ObservableCollection<ISubContentView> items;
    #endregion


    #region コンストラクタ
	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="logging">ロギング</param>
    public ContentLinkListViewModel(LoggingService logging) : base(logging)
    {
        Items = new ObservableCollection<ISubContentView>();
        SetData();
    }
    #endregion

    #region イベント
    /// <summary>
    /// 更新中
    /// </summary>
    [RelayCommand]
    private async void OnRefreshing()
    {
        this.IsRefreshing = true;

        try
        {
             SetData();
        }
        finally
        {
            this.IsRefreshing = false;
        }
    }

    [RelayCommand]
    public void LoadMore()
    {
        SetData();
    }

  

    [RelayCommand]
    private async void GoToDetails(SampleItem item)
    {
        await Shell.Current.GoToAsync(nameof(ContentLinkListDetailPage), true, new Dictionary<string, object>
        {
            { "Item", item }
        });
    }

    #endregion

    #region メソッド
    /// <summary>
    /// データをセット
    /// </summary>
    public void SetData()
    {
        Items.Clear();
        var res = API.GetSubContent();
        if (res == null)
        {
            return;
        }

        if (res is SubContentsResponse)
        {
            SubContentsResponse resp = res as SubContentsResponse;
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ISubContentView, SubContebtViewViewDataModel>(); });
            Mapper map = new Mapper(config);
            foreach (var item in resp.Items)
            {

                Items.Add(map.Map<SubContebtViewViewDataModel>(item));
            }

        }
    }
    #endregion
}
