using AutoMapper;
using BLayer.DataModels;
using Common;
using DLayer.Models;
using Interfaces.DataModel;

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
                pContext.MSubjects.Where(record => record.DeleteFlg != 0)
                    .ToList().ForEach
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

        /// <summary>
        /// 区分別科目一覧取得
        /// </summary>
        /// <param name="kbn"></param>
        /// <returns></returns>
        public List<ISubject> GetSubjectList(long kbn)
        {
            List<ISubject> ret = new List<ISubject>();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<MSubject, SubjectDataModel>(); });
            Mapper map = new Mapper(config);
            try
            {
                pContext.MSubjects.Where(record=>record.PullPushKbn == kbn)
                    .Where(record=>record.DeleteFlg!=0)
                    .ToList().ForEach
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

        /// <summary>
        /// 未選択オブジェクトの作成
        /// </summary>
        /// <returns>未選択オブジェクト</returns>
        public ISubject CreateMisentaku() 
        {
            return new SubjectDataModel()
            { 
                Id=0,
                Name="未選択"
            };
        }

        //科目の削除
    }
}
