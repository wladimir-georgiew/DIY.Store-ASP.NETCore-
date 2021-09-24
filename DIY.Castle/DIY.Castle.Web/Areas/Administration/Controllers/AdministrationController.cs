using GlobalConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DIY.Castle.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = UserRoles.ADMIN_ROLE_NAME)]
    [Area("Administration")]
    public class AdministrationController : Controller
    {
    }
}
