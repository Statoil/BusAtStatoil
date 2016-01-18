using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Security;
using STT.core.Interfaces.Services;
using STT.core.Model;
using STT.service.Services;
using STT.web.Filters;
using STT.web.Models;
using WebMatrix.WebData;

namespace STT.web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class MaintenanzController : Controller
    {
        //private readonly ILocationService _locationService;
        //private readonly IOfficeLocationService _officeLocationService;
        private readonly ITransportService _transportService;
        private readonly IArticleService _articleService;

        public MaintenanzController(IArticleService articleService, ITransportService transportService) 
        {
            _transportService = transportService;
            _articleService = articleService;
            //_officeLocationService = officeLocationService;

            //Enforce.NotNull(() => officeLocationService);
        }

        // Returns HTML pages
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Maintenanz");
        }
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.Message = "Login";
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
/* DISABLED     
  
  [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                 Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Maintenanz");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

             If we got this far, something failed, redisplay form
            return View(model);
        }*/

        public ActionResult Index()
        {
            ViewBag.Message = "Maintenance";
            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Services";
            return View();
        }
        public ActionResult News()
        {
            ViewBag.Message = "News";
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Maintenanz");
            }
        }


        [ValidateInput(false)]
        public ActionResult UpdateServices(string city, string kind, string info, string moreinfo)
        {
            ViewBag.Message = "Updated";
            city = washData(city);
            kind = washData(kind);
            Transport t = _transportService.UpdateTransportService(city, kind, info, moreinfo);
            return View();
        }


        [ValidateInput(false)]
        public ActionResult UpdateNews(string newskind, string newsinfo)
        {
            ViewBag.Message = "Updated";
            newskind = washData(newskind);
            Article a = _articleService.UpdateArticle(newskind, newsinfo);
            return View();
        }

        private string washData(string input) {
            string pattern = "[^A-ZÆØÅa-zæøå0-9_\\- .]";
            string replacement = "_";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replacement);
            return result;
        }


        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
