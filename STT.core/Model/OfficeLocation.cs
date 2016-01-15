using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace STT.core.Model
{
    public class OfficeLocation : Location
    {
        [DataMember]  
        public string Code { get; set; }
    }
}
