﻿using Common;
using FLayer.APIs;

namespace PullPush.ViewModels;

/// <summary>
/// 科目追加画面ViewModel
/// </summary>
public partial class SubjectAdViewModel : BaseViewModel
{
	#region 即時プロパティ

	/// <summary>
	/// 科目名
	/// </summary>
	[ObservableProperty]
	string name;

	/// <summary>
	/// 引出区分
	/// </summary>
	[ObservableProperty]
	bool pull=true;

	/// <summary>
	/// 預入区分
	/// </summary>
	[ObservableProperty]
	bool push;

	/// <summary>
	/// 税対象区分
	/// </summary>
	[ObservableProperty]
	bool inTaxKbn;

	#endregion

	#region コマンド

	/// <summary>
	/// 科目登録
	/// </summary>
	[RelayCommand]
	private void Add()
	{
		if(string.IsNullOrEmpty(name))
		{
            this.DisplayAlert("科目名を入力してください");
			return;
        }

		SubjectViewDataModel dm = new SubjectViewDataModel()
		{
			Name = this.Name,
			PullPushKbn = Pull ? Consts.Kbn.Distans.PULL : Consts.Kbn.Distans.PUSH,
			TaxTargetFlg = InTaxKbn ? Consts.Kbn.Tax.IN : Consts.Kbn.Tax.OUT
		};

		var result = API.AddSubject(dm);

		if (result.Success)
		{
			this.DisplayAlert("科目を登録しました");
		}
		else
		{
			this.DisplayAlert("エラー:科目の登録に失敗しました。");
		}
	}

	#endregion
}
