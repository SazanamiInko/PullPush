using AutoMapper;
using BLayer.DataModels;
using Common;
using DLayer.Models;
using Interfaces.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Logics
{
    /// <summary>
    /// 取引科目紐づけルールロジック
    /// </summary>
    public class SubContentLogic : BasetLogic
    {
        /// <summary>
        /// 取引科目紐づけルールの登録
        /// </summary>
        /// <param name="subContentdata">取引科目紐づけルール</param>
        /// <returns>登録件数</returns>
        public int InsertSubContent(ISubContent subContentdata)
        {
            try
            {

                var config = new MapperConfiguration(cfg => { cfg.CreateMap<ISubContent, TSubContent>(); });
                Mapper map = new Mapper(config);

                //ルール名が登録済みだったらNG
                var targetName =pContext.TSubContents.Where(record => record.Name == subContentdata.Name)
                .FirstOrDefault();

                if(targetName!=null)
                {
                    throw new BusinessException("既にルール名が登録済みです");
                }

                //取引が登録済みだったらNG
                var targetContent = pContext.TSubContents.Where(record => record.Content == subContentdata.Content)
                    .FirstOrDefault();
                if(targetContent!=null) 
                {
                    throw new BusinessException("既に取引が登録済みです");
                }

                var record = map.Map<TSubContent>(subContentdata);

                pContext.TSubContents.Add(record);
                pContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
