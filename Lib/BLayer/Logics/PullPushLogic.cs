using AutoMapper;
using DLayer.Models;
using Interfaces.DataModel;
using Interfaces.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Logics
{
    /// <summary>
    /// 引き出し・預け入れ情報
    /// </summary>
    public class PullPushLogic:BasetLogic
    {

        /// <summary>
        /// 引き出し・預け入れ情報に書き込むAPI
        /// </summary>
        /// <param name="push"></param>
        public void InsertPullPush(IPullPush push)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<IPullPush, TPulPush>(); });
            Mapper map = new Mapper(config);
            try
            {
                var record = map.Map<TPulPush>(push);
                this.pContext.Add(record);
                this.pContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 引き出し・預け入れ情報を取得するAPI
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPullPush GetPullPush(long id)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TPulPush,IPullPush>(); });
            Mapper map = new Mapper(config);

            try
            {
                var target = this.pContext.TPulPushes.Where(record => record.Id == id)
                               .FirstOrDefault();
                return map.Map<IPullPush>(target); ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //引き出し・預け入れ情報のラベルを変更するAPI
        public void UpdatePullPushLabel(long id,string label)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<IPullPush, TPulPush>(); });
            Mapper map = new Mapper(config);
            try
            {
                var target = this.pContext.TPulPushes.Where(record => record.Id == id)
                             .FirstOrDefault();
               
                if (target == null) { return; }
                
                target.Label = label;

                this.pContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        //交通費を書き込むAPI

    }
}
