using AutoMapper;
using Common;
using FLayer.APIs;
using FLayer.Responses;
using Interfaces.DataModel;
using Interfaces.Response;

namespace PullPush.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class ContentLinkListDetailViewModel : BaseViewModel
{
	[ObservableProperty]
    SubContebtViewViewDataModel item;


    /// <summary>
    /// 科目
    /// </summary>
    [ObservableProperty]
    ObservableCollection<SubjectViewDataModel> subjects;

    /// <summary>
    /// 選択されてる科目
    /// </summary>
    [ObservableProperty]
    SubjectViewDataModel selctedSubhect;

    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logging"></param>
    public ContentLinkListDetailViewModel(LoggingService logging) : base(logging)
    {
        this.InitializeVM();
        API.InitializeAPI(logging);
    }
    #endregion

    #region イベント

    [RelayCommand]
    public void Edit()
    {

        DoEdit();
    }


   

    #endregion

    #region メソッド

    /// <summary>
    /// 初期化
    /// </summary>
    public void InitializeVM()
    {

        var config = new MapperConfiguration(cfg => { cfg.CreateMap<ISubject, SubjectViewDataModel>(); });
        Mapper map = new Mapper(config);

        Logging.WriteLog(() => {
            IResponse response = API.GetSubjextItems();

            if (!response.Success)
            {
                return;
            }

            if (response is SubjectResponse)
            {
                SubjectResponse subres = response as SubjectResponse;

                this.Subjects = new ObservableCollection<SubjectViewDataModel>();
                subres.Items.ForEach(record =>
                {
                    SubjectViewDataModel item = map.Map<SubjectViewDataModel>(record); ;
                    this.Subjects.Add(item);
                });

                if(Item==null)
                {
                    return;
                }

                if (subres.Items.Count > 0)
                {
                    var selected = this.Subjects.Where(record => record.Id == item.Subject)
                    .FirstOrDefault();
                    this.SelctedSubhect = selected;
                }
            }
        });

    }

    /// <summary>
    /// 編集
    /// </summary>
    public void DoEdit()
    {
        if (string.IsNullOrEmpty(Item.Name))
        {
            this.DisplayAlert("ルール名が空白です");
            return;
        }

        if (string.IsNullOrEmpty(Item.Content))
        {
            this.DisplayAlert("含む取引名が空白です");
            return;
        }

        Item.Subject = SelctedSubhect.Id;
       var res= API.UpdateSubContent(Item);
        if(res.Success)
        {
            this.DisplayAlert("紐づけルールを更新しました");
        }
        else
        {
            this.DisplayAlert(res.Message);
        }
    }

    /// <summary>
    /// 科目の取得
    /// </summary>
    public void SetSubjects()
    {
        if (Item == null)
        {
            return;
        }

        if (Subjects.Count > 0)
        {
            var selected = this.Subjects.Where(record => record.Id == item.Subject)
            .FirstOrDefault();
            this.SelctedSubhect = selected;
        }
    }
        #endregion
    }
