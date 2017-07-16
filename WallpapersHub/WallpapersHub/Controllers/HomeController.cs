using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WallpapersHub.Models;

namespace WallpapersHub.Controllers
{
    public class HomeController : Controller
    {

        private DbConnection db = new DbConnection();
        public ActionResult Index()
        {
            return View();
        }

        //////////////////////////////////////////

        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, imageData iData)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    iData.Title = _FileName;
                    iData.ImageUrl = "/UploadedFiles/" + _FileName;
                    db.ImageDetails.Add(iData);
                    db.SaveChanges();


                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult MultipleUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MultipleUpload(IEnumerable<HttpPostedFileBase> attachments,imageData iData)
        {
            try
            {
                foreach (var file in attachments)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        file.SaveAs(_path);
                        iData.Title = _FileName;
                        iData.ImageUrl = "/UploadedFiles/" + _FileName;
                        db.ImageDetails.Add(iData);
                        db.SaveChanges();
                    }

                }
               
                ViewBag.Message = "Files Uploaded Successfully!!";
                return View();
            }
            catch {
                ViewBag.Message = "File upload failed!!";
                return View();
            }

                    
            
            return View();
        }









        /// <summary>
        /// ////////////////////////////
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}