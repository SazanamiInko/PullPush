using AutoMapper;
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

    #region メソッド

    public void SetSubjects()
    {
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<ISubject, SubjectViewDataModel>(); });
        Mapper map = new Mapper(config);

        if (item!=null)
        {
            var res=API.GetSubjectsByKbn(item.PullPushKbn);
            if( res is SubjectResponse)
            {
                SubjectResponse response = res as SubjectResponse;
                response.Items.ForEach
                (record =>

                Subjects.Add(map.Map<SubjectViewDataModel>(record))

                    );
            }
        }

        SelctedSubhect = Subjects.Where(record => record.Id == item.Subject)
            .FirstOrDefault();
    }


    #endregion

}
