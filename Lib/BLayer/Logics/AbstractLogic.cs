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
    public abstract class BasetLogic:ILogic
    {
        #region メンバー

        /// <summary>
        /// コンテキスト
        /// </summary>
        protected PullPushContext pContext;

        #endregion

        #region プロパティ

        /// <summary>
        /// コンテキスト
        /// </summary>
        public DbContext Context
        {
            set => pContext = value as PullPushContext;
        }

        #endregion

   
    }
}
