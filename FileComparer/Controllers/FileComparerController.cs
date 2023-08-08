using System;
using System.Web.Mvc;
using FileComparer.Models;

namespace FileComparer.Controllers
{
    public class FileComparerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CompareAndCopy(string oldFilePath, string newFilePath)
        {
            if (string.IsNullOrEmpty(oldFilePath) || string.IsNullOrEmpty(newFilePath))
            {
                ViewBag.ResultMessage = "Please enter file paths.";
                return View("Index");
            }

            try
            {
                var model = new FileComparerModel();
                model.CompareAndCopyFiles(oldFilePath, newFilePath);

                ViewBag.ResultMessage = "Content copied successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.ResultMessage = "Error: " + ex.Message;
            }

            return View("Index");
        }
    }
}
