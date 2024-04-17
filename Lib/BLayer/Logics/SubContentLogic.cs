using AutoMapper;
using BLayer.DataModels;
using Common;
using DLayer.Models;
using Interfaces.DataModel;

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

        /// <summary>
        /// 取引科目紐づけルール
        /// </summary>
        /// <returns></returns>
        public List<ISubContentView> GetSubContent()
        {
            List<ISubContentView> ret = new List<ISubContentView>();

            try
            {
                ret.AddRange(
                                 pContext.TSubContents.Where(record => record.Delete != Consts.Kbn.DeleteKbn.DELETED).ToList()
                                 .GroupJoin
                                    (
                                        this.pContext.MSubjects,
                                        subcontent => subcontent.Subject,
                                        subject => subject.Id,
                                        (subcontent, subject) => new { subcontent, subject })
                                    .SelectMany
                                     (
                                        record => record.subject.DefaultIfEmpty(),
                                        (record, subject) => new SubContentViewDataModel()
                                        {
                                            Id = record.subcontent.Id,
                                            Name=string.IsNullOrEmpty(record.subcontent.Name)?"": record.subcontent.Name,
                                            Content= string.IsNullOrEmpty(record.subcontent.Content)?"": record.subcontent.Content,
                                            Subject=record.subcontent.Subject.HasValue?record.subcontent.Subject.Value:0,
                                            SubjectName =string.IsNullOrEmpty(subject.Name)?"": subject.Name,
                                            Delete =record.subcontent.Delete.HasValue? record.subcontent.Delete.Value:0
                                        })); 
                
            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }

        /// <summary>
        /// 取引科目紐づけ更新
        /// </summary>
        /// <param name="subContentdata"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public int UpdateSubContent(ISubContent subContentdata)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ISubContent, TSubContent>(); });
            Mapper map = new Mapper(config);

            //ルール名が登録済みだったらNG
            var isName = IsTSubContentsByName(subContentdata.Name, subContentdata.Id);

            if (isName)
            {
                throw new BusinessException("既にルール名が登録済みです");
            }

            //取引が登録済みだったらNG
            var iscontent= IsTSubContentsByContent(subContentdata.Content, subContentdata.Id);
            if (iscontent)
            {
                throw new BusinessException("既に取引が登録済みです");
            }

            var target = GetSubContentsByID(subContentdata.Id);
            if (target==null)
            {
                throw new BusinessException("予期せぬエラーが発生しました");
            }
            map.Map(subContentdata,target);
           
            return pContext.SaveChanges();;
        }

        /// <summary>
        /// ルール名検索
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool IsTSubContentsByName(string name, long id = -1)
        {
            var targetName = pContext.TSubContents.Where(record => record.Name == name);

            if (targetName.Count()==0)
            {
                return false;
            }

           targetName = targetName.Where(record => record.Id != id);

            if (targetName.Count() == 0)
            {
                return false;
            }

            return true;

        }

        /// <summary>
        /// コンテンツ名検索
        /// </summary>
        /// <param name="content"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool IsTSubContentsByContent(string content, long id = -1)
        {
            var targetName = pContext.TSubContents.Where(record => record.Content == content);

            if (targetName.Count() == 0)
            {
                return false;
            }

            targetName = targetName.Where(record => record.Id != id);

            if (targetName.Count() == 0)
            {
                return false;
            }

            return true;

        }

        /// <summary>
        /// ID検索
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private TSubContent GetSubContentsByID(long id)
        {
            var target = pContext.TSubContents.Where(record => record.Id == id)
                .FirstOrDefault();

            return target;

        }
    }
}
