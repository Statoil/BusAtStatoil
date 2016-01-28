using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using STT.core.Interfaces.Services;
using STT.core.Model;
using STT.service.Services;

namespace STT.web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILocationService _locationService;
        private readonly IOfficeLocationService _officeLocationService;
        private readonly ITransportService _transportService;
        private readonly IArticleService _articleService;

        //public HomeController() { }

        public HomeController(IOfficeLocationService officeLocationService, ITransportService transportService, IArticleService articleService) 
        {
            _transportService = transportService;
            _officeLocationService = officeLocationService;
            _articleService = articleService;

            //Enforce.NotNull(() => officeLocationService);
        }

        // Returns HTML pages
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome";
            return View();
        }

        /*public ActionResult Bus()
        {
            ViewBag.Message = "Bus";
            return View();
        }
        public ActionResult Bus2(string location)
        {
            ViewBag.Message = location;
            return View();
        }
        public ActionResult Bus3(string location, string service)
        {
            ViewBag.Message = location+", "+service+" shuttle";
            return View(location+"-"+service);
        }*/

        public ActionResult BusLocation(string location)
        {
            ViewBag.Title = location;
            ViewBag.Message = location+" area";
            ViewBag.Location= location;
            if(_transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_OFFICE_SHUTTLE).Count > 0)
                ViewBag.OfficeInfo  = _transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_OFFICE_SHUTTLE).FirstOrDefault().Information;
            if (_transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_OFFICE_SHUTTLE).Count > 0) 
                ViewBag.OfficeMore = _transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_OFFICE_SHUTTLE).FirstOrDefault().Moreinformation;
            if (_transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_HOTELL_SHUTTLE).Count > 0) 
                ViewBag.HotelInfo = _transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_HOTELL_SHUTTLE).FirstOrDefault().Information;
            if (_transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_HOTELL_SHUTTLE).Count > 0) 
                ViewBag.HotelMore = _transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_HOTELL_SHUTTLE).FirstOrDefault().Moreinformation;
            if (_transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_AIRPORT_SHUTTLE).Count > 0) 
                ViewBag.AirportInfo = _transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_AIRPORT_SHUTTLE).FirstOrDefault().Information;
            if (_transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_AIRPORT_SHUTTLE).Count > 0) 
                ViewBag.AirportMore = _transportService.GetTransportInformation(location, Transport.TRANSPORT_KIND_AIRPORT_SHUTTLE).FirstOrDefault().Moreinformation;
            return View();
        }
      

        public ActionResult News()
        {
            ViewBag.Title = "News";

            ViewBag.Message = "News";
            if (_articleService.GetArticle(Article.ARTICLE_KIND_NEWS).Count > 0)
                ViewBag.News = _articleService.GetArticle(Article.ARTICLE_KIND_NEWS).FirstOrDefault().Information;

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Title = "About";

            ViewBag.Message = "About";
            if (_articleService.GetArticle(Article.ARTICLE_KIND_ABOUTUPDATES).Count > 0)
                ViewBag.AboutUpdates = _articleService.GetArticle(Article.ARTICLE_KIND_ABOUTUPDATES).FirstOrDefault().Information;
            if (_articleService.GetArticle(Article.ARTICLE_KIND_ABOUTRESP).Count > 0)
                ViewBag.AboutResponsible = _articleService.GetArticle(Article.ARTICLE_KIND_ABOUTRESP).FirstOrDefault().Information;

            return View();
        }

        /*public ActionResult Shuttle()
        {
            ViewBag.Message = "Shuttle bus";
            return View();
        }

        public ActionResult Airportbus()
        {
            ViewBag.Message = "Airport bus";
            return View();
        }*/


        // Returns JSON serialized strings

        public string GetTransportInformation(string city, string kind)
        {
            city = washData(city);
            kind = washData(kind);
            var res = _transportService.GetTransportInformation(city, kind);
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(res);
        }
        public string GetArticle(string kind)
        {
            kind = washData(kind);
            var res = _articleService.GetArticle(kind);
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(res);
        }

        /*public string GetLocations()
        {
            var res = _locationService.GetLocations().ToList();
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(res);
        }*/

        /*public string GetOfficeLocations()
        {
            var res = _officeLocationService.GetOfficeLocations().ToList();
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(res);
        }
        public string GetOfficeCities()
        {
            var res = _officeLocationService.GetOfficeCities();
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(res);
        }

        public string GetOfficesByCity(string city)//maybe use ByCode instead ??
        {
            city = washData(city);
            var res = _officeLocationService.GetOfficesByCity(city);
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(res);
        }
        public string GetOfficesByCode(string code)
        {
            code = washData(code);
            var res = _officeLocationService.GetOfficesByCode(code);
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(res);
        }

*/

        private string washData(string input) {
            string pattern = "[^A-ZÆØÅa-zæøå0-9_\\- .]";
            string replacement = "_";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replacement);
            return result;
        }

        public string InitData()// Disable method when ready
        {
            InitOfficeLocationData iold = new InitOfficeLocationData();
            //InitTransportData itd = new InitTransportData();
            
            //_transportService.InitData(itd.transportList);
            _officeLocationService.InitData(iold.officeList);

            return "OK";
        }

    }
}
