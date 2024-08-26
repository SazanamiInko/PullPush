using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Logics
{
    public class GroupingLogic : BaseLogic
    {
        /// <summary>
        /// 仕分ける
        /// </summary>
        public void grouping()
        { 
            //トランザクションを発行する
            var tran= this.pContext.Database.BeginTransaction();

            try
            {
                //科目一覧を取得する
                this.pContext.TSubContents.ToList()
                    .ForEach(subcontente =>
                    {
                        if (subcontente != null && !String.IsNullOrEmpty(subcontente.Content))
                        {
                            //明細一覧を取得する
                            var targets = this.pContext.TPulPushes.Where(pullpush => pullpush.Content != null)
                            .Where(pullpush => pullpush.Content.IndexOf(subcontente.Content) > -1)
                            .Where(pullpush => pullpush.Subject == null)
                            .Where(pullpush => pullpush.Rule == -1)
                            .ToList();

                            targets.ForEach(target =>
                            {
                                target.Subject = subcontente.Subject;
                                target.Rule = 0;
                            });

                            this.pContext.SaveChanges();
                        }
                    });

                //コミットする
                tran.Commit();
            }
            catch 
            {  
                tran.Rollback(); 
            }
        }
    }
}
