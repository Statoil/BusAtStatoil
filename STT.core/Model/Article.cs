using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace STT.core.Model
{
    public class Article : BaseEntity
    {
        public const string ARTICLE_KIND_NEWS = "News";
        public const string ARTICLE_KIND_ABOUTUPDATES = "AboutUpdates";
        public const string ARTICLE_KIND_ABOUTRESP = "AboutResponsible";

        [DataMember]
        [Required]
        public string Kind { get; set; }

        [DataMember]
        public string Information { get; set; }

    }
}
