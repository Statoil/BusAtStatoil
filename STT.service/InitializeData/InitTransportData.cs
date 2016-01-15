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
    public class InitTransportData
    {
        public IEnumerable<Transport> transportList = new List<Transport>
                       {
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_STV,
                                   Kind = Transport.TRANSPORT_KIND_AIRPORT_SHUTTLE,
                                   Information = "From the airport to Forus East <br /><ul><li>0740</li><li>0755</li><li>0815</li><li>0825</li><li>0845</li><li>0910</li><li>0930</li></ul><br />Departure behind the ordinary airport bus outside the arrival hall. The bus takes around 20 minutes and runs via Vestre Svanholmen and Vassbotnen to Forus East and Travbaneveien. <br />From Forus East to the airport<br /><ul><li>1400</li><li>1430</li><li>1500</li><li>1530</li><li>1600</li><li>1630</li></ul><br />Departure outside the main reception. The bus takes around 20 minutes and runs via Forus West new bus stop and Vestre Svanholmen to the airport."
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_STV,
                                   Kind = Transport.TRANSPORT_KIND_HOTELL_SHUTTLE,
                                   Information = "Bus to Smarthotel:<br />Smarthotel offers transport from the hotel to offices in the Forus area. Check with the reception desk for departures. <br />Hotel bus from downtown Stavanger:<br />Free bus service all weekdays, except holidays. <br />Clarion Hotel: <ul><li>0715</li><li>0745</li><li>0815</li></ul><br />Radisson Blu Atlantic Hotel: <ul><li>0720</li><li>0750</li><li>0820</li></ul><br />Park Inn: <ul><li>0725</li><li>0755</li><li>0825</li></ul><br />Forus East: <ul><li>0745</li><li>0815</li><li>0835</li></ul><br />Vassbotnen (via Travbaneveien) : <ul><li>0750</li><li>0820</li><li>0840</li></ul><br />Additional bus on Tuesdays, Wednesdays and Thursdays:<br />Radisson Blu Atlantic Hotel: <ul><li>0720</li></ul><br />Park Inn: <ul><li>0725</li></ul><br />Forus East: <ul><li>0750</li></ul><br />The additional bus proceeds to Travbaneveien and Vestre Svanholmen. The traffic situation may cause minor delays in the timetable.<br />Hotel bus to downtown Stavanger:<br />Free bus service from Forus to Stavanger city centre. The bus will run on weekdays from Monday to Thursday at <ul><li>1700</li><li>1800</li></ul><br />Starting point:<br />Forus East (entrance 1) via Travbaneveien to Vassbotnen and Vestre Svanholmen. Personnel in Forushagen and Grenseveien can use the southbound bus stop in Travbaneveien. The bus will run the motorway to the hotels Clarion, Atlantic and Park Inn. The whole trip will take around 25 minutes.<br />The bus service is for employees, contractors and guests staying at a hotel in Stavanger. "
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_STV,
                                   Kind = Transport.TRANSPORT_KIND_OFFICE_SHUTTLE,
                                   Information = "Statoil offers shuttle bus services between the offices at Forus East, Vassbotnen and Vestre Svanholmen. One bus drives between Forus East and Vassbotnen and the other drives between Vestre Svanholmen and Vassbotnen. <br/>Travellers between Forus East and Vestre Svanholmen need to change buses at Vassbotnen. There will be at maximum waiting time of 10 minutes at any location.<br/>The offer is free for all Statoil employees and guests.<br/><br/>First departures:<br/>Bus 1 - 0830 from Forus East to Vassbotnen and return to Forus East<br/>Bus 2 - 0830 from Vestre Svanholmen to Vassbotnen and return to Vestre Svanholmen<br/><br/>Last departures:<br/>Bus 1 - 1450 from Vassbotnen to Forus East<br/>Bus 2 - 1450 from Vassbotnen to Vestre Svanholmen<br/><br/>The buses will have a lunch break between 1100 and 1130. <br /><br />There will be no bus services at Forus during the following periods: <br/>Christmas 2011<br />From Friday December 23rd in the evening. Resuming Monday 2 Jan.<br />Easter 2012<br />There will be a bus service until (including) Friday March 30th. The service will resume again on Tuesday April 10th. in the morning.<br />Summer 2012<br />There will be a bus service until (including) Friday July 6th. The service will resume again on Monday August 6th in the morning."
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_STV,
                                   Kind = Transport.TRANSPORT_KIND_TAXI,
                                   Information = "Rogaland Taxi: <a href=\"call:+4751909090\">+47 51 90 90 90</a>. NorgesTaxi: <a href=\"call:+4791080000\">08000</a>. MiljøTaxi: <a href=\"call:+4751586666\">+47 51 58 66 66</a>. Sola Taxi: <a href=\"call:+4751650444\">+47 51 65 04 44</a>. "
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_BGN,
                                   Kind = Transport.TRANSPORT_KIND_AIRPORT_SHUTTLE,
                                   Information = "Monday - Friday from/to Flesland via Telenor building (Birkelandskrysset) to Sandslihaugen and Sandsliveien. <br />From Sandsli to Flesland:<br /><ul><li>1400</li><li>1430</li><li>1500</li><li>1530</li><li>1600</li></ul><br />From Flesland to Sandsli:<br /><ul><li>0745</li><li>0800</li><li>0815</li><li>0830</li><li>0845</li><li>0900</li><li>0915</li><li>0930</li></ul>"
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_BGN,
                                   Kind = Transport.TRANSPORT_KIND_OFFICE_SHUTTLE,
                                   Information = "Monday - Friday between 0800 and 1600, lunch break between 1100 and 1200.<br />Departs from Telenor building on the hour and 30 minutes past every hour<br />Departs from Sandsliveien 90 15 minutes on every hour and 15 minutes past every hour"
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_BGN,
                                   Kind = Transport.TRANSPORT_KIND_HOTELL_SHUTTLE,
                                   Information = "Monday - Friday between Radisson Blu Royal Hotel (Bryggen) and Sandsli. <br />0700: From the hotel<br />0715: Galleriet on Torvallmenningen to Telenor building (Birkelandskrysset), Sandslihaugen to Sandsliveien.<br />1615: Return from Telenor building via Sandsliveien and Sandslihaugen to Radisson Blu Royal Hotel "
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_OSL,
                                   Kind = Transport.TRANSPORT_KIND_OFFICE_SHUTTLE,
                                   Information = "Shuttle bus Oksenøyveien/Michelets vei – Fornebu<br/>This is a shuttle bus that picks up travellers from the west direction, stops at Oksenøyveien by E18.<br />Oksenøyveien/Michelets vei – Fornebu <ul><li>06:45</li><li>07:00</li><li>07:15</li><li>07:30</li><li>07:45</li><li>08:00</li><li>08:15</li><li>08:30</li><li>08:45</li><li>09:00</li><li>09:15</li><li>09:30</li><li>09:45</li><li>10:00</li></ul>"
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_HAR,
                                   Kind = Transport.TRANSPORT_KIND_HOTELL_SHUTTLE,
                                   Information = "Starting September 25th 2012 a mini bus/maxi taxi will drive between the hotels and the office three days per week, according to the following schedule:<br />Tue, Wed, Thu: <br />07:45 - From Grand Nordic Harstad (via Clarion Collection Hotel Arcticus and Thon Hotel Harstad to Statoil) <br />Tue, Wed: <br />16:15 - From Statoil​ "
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_HAR,
                                   Kind = Transport.TRANSPORT_KIND_AIRPORT_SHUTTLE,
                                   Information = "The airport buses correspond with airplane arrivals and departures. If an arrival or departure is changed or cancelled, the airport bus departure will also be changed or cancelled accordingly. Departures from the airport may leave early if the corresponding plane arrives early.<br />All the buses follow the main road between the airport and city center. Some of the buses take a slight detour from the main road to stop by Statoil's main entrance on their way to and from the airport, while others don't. The buses that don't stop at the main entrance will stop nearby along the main road, and you will have to walk for 5-10 minutes to get to the office.<br /><br />    All buses will stop at the city center hotels after departure/arrival at the city center bus terminal. <br />For the updated schedule, please click on: <a href=\"http://www.flybussen.no/kunde/flybussen/Filvedlegg/5/28-10.pdf\">www.flybussen.no/kunde/flybussen/Filvedlegg/5/28-10.pdf</a> or navigate to www.flybussen.no/harstad and then click on 'Rutetabell'."
                               },
                        new Transport
                               {
                                   City = OfficeLocation.LOCATION_HAR,
                                   Kind = Transport.TRANSPORT_KIND_TAXI,
                                   Information = "Airport taxi has to be booked at least 3 hours in advance. You may share the taxi with other travelers, but the taxi will not have more than three passengers in total.<br />You book airport taxi by calling: <a href=\"call:+4777041000\">+47 77 04 10 00</a>. Groups travelling together can book maxi taxi by calling the same number.<br /> Updated prices can be found here: <a href=\"http://www.harstadtaxi.no/index.php/priser\">www.harstadtaxi.no/index.php/priser</a><br /> You book regular taxi or maxi taxi by calling: <a href=\"call:+4777041000\">+47 77 04 10 00</a>."
                               }
                       };
    }
}
