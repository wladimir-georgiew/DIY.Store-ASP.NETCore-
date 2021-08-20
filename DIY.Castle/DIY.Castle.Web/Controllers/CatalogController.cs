using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Controllers
{
    public class CatalogController : BaseController
    {
        public IActionResult Index()
        {
            // TODO : Make service to show all products
            // TODO : Add filtration options
            // TODO : Add pagination
            return View();
        }
    }
}
