namespace Interfaces.DataModel
{
    /// <summary>
    /// 紐づけルール表示用
    /// </summary>
    public interface ISubContentView:ISubContent
    {
        /// <summary>
        /// 科目名
        /// </summary>
        public string SubjectName { get; set; }
    }
}
