﻿using Interfaces.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullPush.Models
{
    /// <summary>
    /// 科目ビューデータモデル
    /// </summary>
    public class SubjectViewDataModel : ISubject
    {
        /// <summary>
        /// 管理番号
        /// </summary>
        public long Id { get; set ; }
        
        /// <summary>
        /// 科目名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 取引区分
        /// </summary>
        public long PullPushKbn { get; set; }
        
        /// <summary>
        /// 税対象フラグ
        /// </summary>
        public long TaxTargetFlg { get; set; }
    }
}
