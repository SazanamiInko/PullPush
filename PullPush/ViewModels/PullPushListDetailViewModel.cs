using AutoMapper;
using BLayer.DataModels;
using Common;
using FLayer.APIs;
using FLayer.Responses;
using Interfaces.DataModel;

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


    /// <summary>
    /// ルールも保存
    /// </summary>
    [ObservableProperty]
    bool isCheckRuleSaved;
    #endregion


    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logging">ロギング</param>
    public PullPushListDetailViewModel(LoggingService logging) : base(logging)
    {
        Subjects = new ObservableCollection<SubjectViewDataModel>();
    }
    #endregion

    #region イベント

    [RelayCommand]
    public void AtendSubject()
    {
        var res = API.SetSubject(Item.Id,
            SelctedSubhect.Id,
            Consts.Kbn.RuleKbn.MANUAL);
        
        if(res.Success)
        {
            this.DisplayAlert("科目を設定しました");
        }
        else
        {
            this.DisplayAlert(res.Message);
        }

        if(IsCheckRuleSaved)
        {
            SubContentdataModel rule = new SubContentdataModel();
            rule.Name = Item.Content;
            rule.Content = Item.Content;
            rule.Subject = SelctedSubhect.Id;

           var ressub= API.AddSubContent(rule);

            if (res.Success)
            {
                this.DisplayAlert("紐づけを設定しました");
            }
            else
            {
                this.DisplayAlert(res.Message);
            }
        }
    }

    #endregion

    #region メソッド

    /// <summary>
    /// 科目の取得
    /// </summary>
    public void SetSubjects()
    {
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<ISubject, SubjectViewDataModel>(); });
        Mapper map = new Mapper(config);

        if (Item != null)
        {
            var res = API.GetSubjectsByKbn(item.PullPushKbn);
            if (res is SubjectResponse)
            {
                SubjectResponse response = res as SubjectResponse;
                response.Items.ForEach
                (record =>

                Subjects.Add(map.Map<SubjectViewDataModel>(record))

                    );
            }
        }

        SelctedSubhect = Subjects.FirstOrDefault(record => record.Id == item.Subject);
    }
    #endregion
}

