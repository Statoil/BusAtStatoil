using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace STT.core.Model
{
    [Serializable]
    [DataContract]
    public abstract class BaseEntity
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public DateTime? Created { get; set; }

        [DataMember]
        public DateTime? Updated { get; set; }
    }
}
