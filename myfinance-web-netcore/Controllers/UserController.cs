using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userModel = new UserModel();
            ViewBag.List = userModel.List();
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser(int? id)
        {
            if (id != null)
            {
                var user = new UserModel().LoadUserById(id);
                ViewBag.User = user;
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel form)
        {
            if (form.UserId == null)
                form.Insert();
            else
                form.Update(form.UserId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            new UserModel().Delete(id);
            return RedirectToAction("Index");
        }
    }
}