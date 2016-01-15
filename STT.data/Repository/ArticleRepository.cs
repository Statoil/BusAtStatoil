using System.Linq;
using STT.core.Interfaces;
using STT.core.Model;

namespace STT.data.Repository
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public Article GetArticle(string kind)
        {
            return base.GetAll().Where(a => a.Kind ==kind).Select(x => x).ToList().FirstOrDefault();
        }
    }
        
}
