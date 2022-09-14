using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var transaction = new Transaction();
            ViewBag.List = transaction.ListTransactions();
            return View();
        }

        [HttpGet]
        public IActionResult CreateTransaction(int? id)
        {
            if (id != null)
            {
                var transaction = new Transaction().LoadTransactionById(id);
                ViewBag.Transaction = transaction;
            }

            ViewBag.List = new AccountPlanModel().List();
            return View();
        }

        [HttpPost]
        public IActionResult CreateTransaction(TransactionModel form)
        {
            var transaction = new Transaction();

            if (form.Id == null)
                transaction.Insert(form);
            else
                transaction.Update(form);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteTransaction(int id)
        {
            new Transaction().Delete(id);
            return RedirectToAction("Index");
        }
    }
}