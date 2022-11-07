using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class AccountPlanController : Controller
    {
        private readonly ILogger<AccountPlanController> _logger;

        public AccountPlanController(ILogger<AccountPlanController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var accountsPlanModel = new AccountPlanModel();
            ViewBag.List = accountsPlanModel.List();
            return View();
        }

        [HttpGet]
        public IActionResult CreateAccountPlan(int? id)
        {
            if (id != null)
            {
                var accountPlan = new AccountPlanModel().LoadAccountPlanById(id);
                ViewBag.AccountPlan = accountPlan;
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccountPlan(AccountPlanModel form)
        {
            if (form.AccountPlanId == null)
                form.Insert();
            else
                form.Update(form.AccountPlanId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteAccountPlan(int id)
        {
            new AccountPlanModel().Delete(id);
            return RedirectToAction("Index");
        }
    }
}