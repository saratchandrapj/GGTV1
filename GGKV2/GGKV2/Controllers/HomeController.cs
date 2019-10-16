using GGKV2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using GoogleDriveRestAPI_v3.Models;

namespace GGKV2.Controllers
{
    public class HomeController : Controller
    {
        public class images
        {
            public string fileNamewithExt { get; set; }
            public string fileNamewithoutExt { get; set; }
        }
        public ActionResult Index()
        {
            List<images> ImList = new List<images>();
            List<string> FName = new List<string>();
            var path = Server.MapPath("/Images/Index");
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string item2 in dirs)
            {
                FileInfo f = new FileInfo(item2);
                FName.Add(f.Name);
                
            }
            foreach (string item in files)
            {
                images im = new images();
                FileInfo f = new FileInfo(item);
                im.fileNamewithExt = f.Name;
                im.fileNamewithoutExt = Path.GetFileNameWithoutExtension(item);
                ImList.Add(im);
                FName.Add(f.Name);
            }
            ViewBag.FolderList = ImList.ToList();
            //return View();
            return View(ImList.ToList());
        }

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

        public ActionResult Services()
        {
            ViewBag.Message = "Services";
            return View();
        }

        public ActionResult Fab()
        {
            ViewBag.Message = "Fabrication & Erection";
            return View();
        }
        public ActionResult Maintenance()
        {
            ViewBag.Message = "Maintenance Works";
            return View();
        }
        public ActionResult HeavyMachinery()
        {
            ViewBag.Message = "Heavy Machinery";
            return View();
        }
        public ActionResult AntiCorrosive()
        {
            ViewBag.Message = "Industrial Anti-Corrosive protection coating";
            return View();
        }
        public ActionResult SolarWorks()
        {
            ViewBag.Message = "Solar Works";
            return View();
        }
        public ActionResult CivilWorks()
        {
            ViewBag.Message = "Misc. Civil Works";
            return View();
        }
        public ActionResult CeilingandRoofingworks()
        {
            ViewBag.Message = "Ceiling and Roofing works";
            return View();
        }
        public ActionResult EpoxyFlooring()
        {
            ViewBag.Message = "Epoxy Flooring";
            return View();
        }
        public ActionResult Princples()
        {
            ViewBag.Message = "Princples";
            return View(); 
        }
        public ActionResult OurExpertise()
        {
            ViewBag.Message = "OurExpertise";
            return View();
        }
        public ActionResult Career()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file,string Name,string Area,string Exp)
        {
            try
            {
                GoogleDriveFilesRepository.FileUpload(file,Name,Area,Exp);
                ViewBag.Message = "File Uploaded Successfully!!";
                return View("career");
            }
            catch (Exception e)
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
            //public ActionResult UploadFile(HttpPostedFileBase file)
            //{
            //    try
            //    {
            //        if (file.ContentLength > 0)
            //        {
            //            string _FileName = Path.GetFileName(file.FileName);
            //            //var body = new Microsoft.Owin.Security.Google.Apis.Drive.v3.Data.File();
            //            string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
            //            file.SaveAs(_path);
            //        }
            //        ViewBag.Message = "File Uploaded Successfully!!";
            //        return View();
            //    }
            //    catch
            //    {
            //        ViewBag.Message = "File upload failed!!";
            //        return View();
            //    }
            //}
        }
}