using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace STT.core.Model
{
    public class Transport : BaseEntity
    {
        public const string TRANSPORT_KIND_TRAIN = "Train";
        public const string TRANSPORT_KIND_HOTELL_SHUTTLE = "Hotel";
        public const string TRANSPORT_KIND_AIRPORT_SHUTTLE = "Airport";
        public const string TRANSPORT_KIND_TAXI = "Taxi";
        public const string TRANSPORT_KIND_OFFICE_SHUTTLE = "Office";

        /*[Key]
        [Column(Order=0)]*/
        [DataMember]
        [Required]
        public string City { get; set; }

        [DataMember]
        [Required]
        public string Kind { get; set; }

        [DataMember]
        public string Information { get; set; }

        [DataMember]
        public string Moreinformation { get; set; }

    }
}
