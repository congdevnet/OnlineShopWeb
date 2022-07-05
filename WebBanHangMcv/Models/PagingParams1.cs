namespace WebBanHangMcv.Models
{
    public class PagingParams1<TEntity> where TEntity : class
    {
        public object Predicates { get; internal set; }
        public object SortExpression { get; internal set; }
    }
}