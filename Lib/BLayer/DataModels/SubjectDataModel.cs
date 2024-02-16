using Interfaces.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DataModels
{
    /// <summary>
    /// 科目マスタ
    /// </summary>
    public class SubjectDataModel : ISubject
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long PullPushKbn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long TaxTargetFlg { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
