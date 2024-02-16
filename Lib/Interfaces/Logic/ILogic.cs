using Microsoft.EntityFrameworkCore;

namespace Interfaces.Logic
{
    /// <summary>
    /// ロジック層
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// コンテキスト
        /// </summary>
        public DbContext Context { set; }
    }
}
