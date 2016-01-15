using System.Collections.Generic;
using STT.core.Model;

namespace STT.core.Interfaces.Services
{
    public interface IArticleService : IService<Article>
    {
        IList<Article> GetArticle(string kind);
        Article UpdateArticle(string kind, string info);
    }
}
