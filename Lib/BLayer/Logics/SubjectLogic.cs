using AutoMapper;
using BLayer.DataModels;
using Common;
using DLayer.Models;
using Interfaces.DataModel;
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

        /// <summary>
        /// 科目の登録
        /// </summary>
        /// <param name="subject"></param>
        public void InsertSubject(ISubject subject)
        {
          
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ISubject,MSubject > (); });
            Mapper map = new Mapper(config);

            try
            {
                //同じ科目名が登録済みの場合はNG
                var already = pContext.MSubjects.Where(record => record.Name == subject.Name)
                    .FirstOrDefault();

                if (already != null)
                {
                    throw new BusinessException("既に科目が登録されてました");
                }

                var record = map.Map<MSubject>(subject);
                this.pContext.MSubjects.Add(record);
                this.pContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }         
        }
        //科目の更新

        /// <summary>
        /// 科目の取得
        /// </summary>
        /// <returns></returns>
        public List<ISubject> GetSubjectList()
        {
            List<ISubject> ret = new List<ISubject>();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<MSubject, SubjectDataModel>(); });
            Mapper map = new Mapper(config);
            try
            {
                pContext.MSubjects.ToList().ForEach
                    (record =>
                    {
                        var item = map.Map<SubjectDataModel>(record);

                        ret.Add(item);
                    });
                return ret;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //科目の削除
    }
}
