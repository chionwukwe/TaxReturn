using System.Web.Mvc;
using PagedList;
using TaxReturn.Core;
using TaxReturn.Extensions;

namespace TaxReturn.Controllers
{
    public class AccountTransactionController : Controller
    {
        private readonly IQueryAccountTransaction _queryAccountTransaction;

        public AccountTransactionController(IQueryAccountTransaction queryAccountTransaction)
        {
            _queryAccountTransaction = queryAccountTransaction;
        }
     
        public ActionResult Index(int? page)
        {
            var results = _queryAccountTransaction.GetAll().ToAccountTransactionViewModels();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            
            return View(results.ToPagedList(pageNumber, pageSize));
        }
    }
}