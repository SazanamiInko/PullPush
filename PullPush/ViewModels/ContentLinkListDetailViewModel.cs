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

                if (subres.Items.Count > 0)
                {
                    this.SelctedSubhect = this.Subjects[0];
                }
            }
        });

    }
    #endregion
}
