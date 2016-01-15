using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace STT.core.Model
{
    public class Location : BaseEntity
    {
        public const string LOCATION_STV = "Stavanger";
        public const string LOCATION_TRH = "Trondheim";
        public const string LOCATION_STJ = "Stjørdal";
        public const string LOCATION_BGN = "Bergen";
        public const string LOCATION_OSL = "Oslo";
        public const string LOCATION_HAR = "Harstad";
        public const string LOCATION_HAM = "Hammerfest";
        public const string LOCATION_SAN = "Sandnessjøen";
        public const string LOCATION_KSN = "Kristiansund N";
        public const string LOCATION_POR = "Porsgrunn";
        public const string LOCATION_FLO = "Florø";

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string City { get; set; }

        [DataMember]        
        public string Address { get; set; }

        [DataMember]
        public double Lat { get; set; }

        [DataMember]
        public double Lon { get; set; }
    }
}
