using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using STT.core.Interfaces.Services;
using STT.service.Services;

namespace STT.web.Controllers
{
    public class TestsController : Controller
    {
        //private readonly ILocationService _locationService;
        //private readonly IOfficeLocationService _officeLocationService;
        //private readonly ITransportService _transportService;

        public TestsController(/*IOfficeLocationService officeLocationService, ITransportService transportService*/) 
        {
            //_transportService = transportService;
            //_officeLocationService = officeLocationService;

            //Enforce.NotNull(() => officeLocationService);
        }

        // Returns HTML pages
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome";
            return View();
        }

        public ActionResult Geotests()
        {
            ViewBag.Message = "Geotests";
            return View();
        }
        public ActionResult JsonTest()
        {
            ViewBag.Message = "Json";
            return View();
        }

        private string washData(string input) {
            string pattern = "[^A-ZÆØÅa-zæøå0-9_\\- .]";
            string replacement = "_";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replacement);
            return result;
        }

    }
}
