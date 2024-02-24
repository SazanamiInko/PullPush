using AutoMapper;
using BLayer.DataModels;
using Common;
using DLayer.Models;
using Interfaces.DataModel;
using NLog.Targets;

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
                this.pContext.TPulPushes.Add(record);
                this.pContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 引き出し・預け入れ情報一覧に書き込むAPI
        /// </summary>
        /// <param name="pullPushs"></param>
        /// <returns></returns>
        public int InsertPullPushs(List<IPullPush> pullPushs)
        {
            int cun=0;
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<IPullPush, TPulPush>(); });
            Mapper map = new Mapper(config);
            try
            {
                foreach (var pullPush in pullPushs)
                {
                    var record = map.Map<TPulPush>(pullPush);
                    this.pContext.TPulPushes.Add(record);
                    cun++;
                }

                this.pContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return cun;
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
                return map.Map<IPullPush>(target); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IPullPushView> GetPullPushs()
        {
            List<IPullPushView> ret = new List<IPullPushView>();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TPulPush, PullPushViewDataMosel>(); });
            Mapper map = new Mapper(config);
            try
            {

                ret.AddRange(this.pContext.TPulPushes.GroupJoin
                                    (
                                    this.pContext.MSubjects,
                                    pullpush => pullpush.Subject,
                                    subject => subject.Id,
                                    (pullpush, subject) =>
                                    new { pullpush, subject })
                                    .SelectMany(record => record.subject.DefaultIfEmpty(), (record, subject) =>
                                    new PullPushViewDataMosel()
                                    {
                                        Id = record.pullpush.Id,
                                        Year = Util.ConvertNullable(record.pullpush.Year),
                                        Month = Util.ConvertNullable(record.pullpush.Month),
                                        Day = Util.ConvertNullable(record.pullpush.Day),
                                        Content =  record.pullpush.Content,
                                        Subject = Util.ConvertNullable(record.pullpush.Subject),
                                        SubjectName = subject == null ? "未分類" : subject.Name,
                                        Pull = Util.ConvertNullable(record.pullpush.Pull),
                                        Push = Util.ConvertNullable(record.pullpush.Push),
                                        PullPushKbn = Util.ConvertNullable(record.pullpush.Pull) == 0 ?
                                                     Consts.Kbn.PullPushKbn.PUSH :
                                                     Consts.Kbn.PullPushKbn.PULL
                                    })
                                    ); ;
                
                   
                


                return ret;
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
