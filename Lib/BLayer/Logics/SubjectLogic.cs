using DLayer.Models;
using Interfaces.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Logics
{
    /// <summary>
    /// 科目ロジック
    /// </summary>
    public class SubjectLogic : BasetLogic
    {
        #region メンバー

        /// <summary>
        /// コンテキスト
        /// </summary>
        private PullPushContext pContext;

        #endregion

        #region プロパティ

        /// <summary>
        /// コンテキスト
        /// </summary>
        public DbContext Context { get; set; }


        #endregion

        //科目の登録

        //科目の更新

        //科目の取得

        //科目の削除
    }
}
