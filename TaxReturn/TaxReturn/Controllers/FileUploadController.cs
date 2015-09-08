using System.Data.Entity.Infrastructure;
using System.Web;
using System.Web.Mvc;
using TaxReturn.Core;
using TaxReturn.Models;

namespace TaxReturn.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IUploadFileContentService _fileUploadContentService;
        public FileUploadController(IUploadFileContentService fileUploadFileContentService)
        {
            _fileUploadContentService = fileUploadFileContentService;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if(upload == null || upload.FileName.EndsWith(".csv"))
                ModelState.AddModelError("Missing file", "Please upload file");
            try
            {
                if (ModelState.IsValid)
                {
                  
                    var result =  _fileUploadContentService.UploadFile(upload.InputStream);
                    var viewModel = new FileUploadResultsViewModel(result);
                    return View("UploadResults", viewModel);
                }
            }
            catch (RetryLimitExceededException exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                //log error
            }
            return View("Index");
        }
         
    }
}