using STT.core.Model;

namespace STT.core.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Article GetArticle(string kind);
    }
}
