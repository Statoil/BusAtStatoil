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
    public class InitOfficeLocationData
    {
       
        public IEnumerable<OfficeLocation> officeList = new List<OfficeLocation>
                       {
                        new OfficeLocation
                               {
                                   Name = "Forus Øst",
                                   Address = "Forusbeen 50, 4035 Stavanger",
                                   City = OfficeLocation.LOCATION_STV,
                                   Lat = 58.89313,
                                   Lon = 5.71879,
                                   Code = "ST-FO" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Forus Vest",
                                   Address = "Svanholmen 8, 4313 Forus",
                                   City = OfficeLocation.LOCATION_STV,
                                   Lat = 58.89026,
                                   Lon = 5.70885,
                                   Code = "ST-FV" 
                               }, 
                        new OfficeLocation
                               {
                                   Name = "Forushagen",
                                   Address = "Grenseveien 21, 4313 Forus",
                                   City = OfficeLocation.LOCATION_STV,
                                   Lat = 58.888836,
                                   Lon = 5.71834,
                                   Code = "ST-FH" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Telenor-bygget",
                                   Address = "Forusbeen 35, 4033 Forus",
                                   City = OfficeLocation.LOCATION_STV,
                                   Lat = 58.893343,
                                   Lon = 5.72332,
                                   Code = "ST-TN" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Vassbotnen",
                                   Address = "Vassbotnen 23, 4033 Forus",
                                   City = OfficeLocation.LOCATION_STV,
                                   Lat = 58.89212,
                                   Lon = 5.71084,
                                   Code = "ST-VB" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Travbaneveien",
                                   Address = "Travbaneveien 5, 4035 Stavanger",
                                   City = OfficeLocation.LOCATION_STV,
                                   Lat = 58.891095,
                                   Lon =  5.72153,
                                   Code = "ST-TV" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Vestre Svanholmen 1",
                                   Address = "Vestre Svanholmen 1, 4033 Stavanger",
                                   City = OfficeLocation.LOCATION_STV,
                                   Lat = 58.88627,
                                   Lon = 5.69802,
                                   Code = "ST-VS" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Kjørboveien 16",
                                   Address = "Kjørboveien 16, Sandvika",
                                   City = OfficeLocation.LOCATION_OSL,
                                   Lat = 59.922055,
                                   Lon = 10.685137,
                                   Code = "OS-KJ" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Skøyenhus 4",
                                   Address = "Drammensveien 134, 0277 Oslo",
                                   City = OfficeLocation.LOCATION_OSL,
                                   Lat = 59.92112,
                                   Lon = 10.68564,
                                   Code = "OS-SK4" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Fornebu",
                                   Address = "Martin Linges Vei 33, 1364 Fornebu",
                                   City = OfficeLocation.LOCATION_OSL,
                                   Lat = 59.89564,
                                   Lon = 10.62897, 
                                   Code = "OS-FB" 
                               },
                        new OfficeLocation
                               {
                                   Name = "Rotvoll",
                                   Address = "Arkitekt Ebbells veg 10, 7005 Rotvoll",
                                   City = OfficeLocation.LOCATION_TRH,
                                   Lat = 63.43877,
                                   Lon = 10.47857,
                                   Code = "TR-RO" 
                               },
                         new OfficeLocation
                               {
                                   Name = "Sandsliveien",
                                   Address = "Sandsliveien 90",
                                   City = OfficeLocation.LOCATION_BGN,
                                   Lat = 60.297616,
                                   Lon = 5.285711,
                                   Code = "BE-SV" 
                               },
                               new OfficeLocation
                               {
                                   Name = "Sandslihaugen",
                                   Address = "Sandslihaugen 30, 5254 Sandsli",
                                   City = OfficeLocation.LOCATION_BGN,
                                   Lat = 60.293868,
                                   Lon = 5.28271,
                                   Code = "BE-SA" 
                               },
                               new OfficeLocation
                               {
                                   Name = "Sandsligården 1",
                                   Address = "Sandslimarka 55, 5254 Sandsli",
                                   City = OfficeLocation.LOCATION_BGN,
                                   Lat = 60.29255,
                                   Lon = 5.27955,
                                   Code = "BE-SG" 
                               },
                               new OfficeLocation
                               {
                                   Name = "Sandsligården 2",
                                   Address = "Sandslimarka 55, 5254 Sandsli",
                                   City = OfficeLocation.LOCATION_BGN,
                                   Lat = 60.29255,
                                   Lon = 5.27955,
                                   Code = "BE-SG2" 
                               }, 
                               new OfficeLocation
                               {
                                   Name = "Opplæringssenter",
                                   Address = "Sandslihaugen 30, 5254 Sandsli",
                                   City = OfficeLocation.LOCATION_BGN,
                                   Lat = 60.293868,
                                   Lon = 5.28271,
                                   Code = "BE-OS" 
                               }, 
                               new OfficeLocation
                               {
                                   Name = "Telenor-bygget",
                                   Address = "Ytrebygdveien 215, Fyllingsdalen, 5258 Bergen",
                                   City = OfficeLocation.LOCATION_BGN,
                                   Lat = 60.28813,
                                   Lon = 5.26024,
                                   Code = "BE-TN" 
                               },
                               new OfficeLocation
                               {
                                   Name = "Kystbasen Ågotnes",
                                   Address = "Ytrebygdveien 215, Fyllingsdalen, 5258 Bergen",
                                   City = OfficeLocation.LOCATION_BGN,
                                   Lat = 60.410632,
                                   Lon = 5.004401,
                                   Code = "BE-ÅG" 
                               },
                               new OfficeLocation
                               {
                                   Name = "Stjørdal",
                                   Address = "Strandveien 4, 7501 Stjørdal",
                                   City = OfficeLocation.LOCATION_STJ,
                                   Lat = 63.46980,
                                   Lon = 10.9069,
                                   Code = "STJ-" 
                               },
                               new OfficeLocation
                               {
                                   Name = "Harstad",
                                   Address = "Mølnholtet 42, Medkila, 9481 Harstad",
                                   City = OfficeLocation.LOCATION_HAR,
                                   Lat = 68.75830,
                                   Lon = 16.55136,
                                   Code = "HA-" 
                               },
                               new OfficeLocation
                               {
                                   Name = "Melkøya",
                                   Address = "Postboks 413, 9615 Hammerfest",
                                   City = OfficeLocation.LOCATION_HAM,
                                   Lat = 70.6897,
                                   Lon = 23.601,
                                   Code = "MEL-" 
                               },
                               new OfficeLocation
                               {
                                   Name = "Sandnessjøen",
                                   Address = "Novikv. 115 B, 8800 Sandnessjøen",
                                   City = OfficeLocation.LOCATION_SAN,
                                   Lat = 66.006739,
                                   Lon = 12.576234,
                                   Code = "SA-" //???
                               },
                               new OfficeLocation
                               {
                                   Name = "Porsgrunn",
                                   Address = "Herøya Forskningspark, Hydroveien 67, 3948 Porsgrunn",
                                   City = OfficeLocation.LOCATION_POR,
                                   Lat = 59.120689,
                                   Lon = 9.633594,
                                   Code = "PO-" //???
                               },
                               new OfficeLocation
                               {
                                   Name = "Omagata",
                                   Address = "Omagata 122, 6517 Kristiansund",
                                   City = OfficeLocation.LOCATION_KSN,
                                   Lat = 63.10748,
                                   Lon = 7.77843,
                                   Code = "KRIS-yyy" //???
                               },
                               new OfficeLocation
                               {
                                   Name = "Industriveien",
                                   Address = "Industriveien 7, 6517 Kristiansund",
                                   City = OfficeLocation.LOCATION_KSN,
                                   Lat = 63.110834,
                                   Lon = 7.784994,
                                   Code = "KRIS-xxx" //???
                               },
                               new OfficeLocation
                               {
                                   Name = "Boganeset",
                                   Address = "Botnaneset, Postboks 223, 6901 Florø",
                                   City = OfficeLocation.LOCATION_FLO,
                                   Lat = 61.606151,
                                   Lon = 5.085297,
                                   Code = "FLORØ-" 
                               }

                       };


    }
}
