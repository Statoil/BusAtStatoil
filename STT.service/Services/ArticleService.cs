using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STT.core.Interfaces;
using STT.core.Interfaces.Services;
using STT.core.Model;

namespace STT.service.Services
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        protected new IArticleRepository Repository;

        public ArticleService(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
            : base(unitOfWork)
        {
            base.Repository = articleRepository;
        }

        public IList<Article> GetArticle(string kind)
        {
            return base.GetAllReadOnly()
                .Where(k => k.Kind == kind).ToList();
            //return _officeList.ToList();
        }

        public Article UpdateArticle(string kind, string info)
        {
            Article t = base.GetAll()
                .Where(k => k.Kind == kind).FirstOrDefault();
            
            if (t == null)
            {
                t = new Article();
                t.Kind = kind;
            }
            
            t.Information = info;
            base.SaveOrUpdate(t);
            return t;
        }
    }
}
