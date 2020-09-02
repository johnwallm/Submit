using Submit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Submit.Controllers
{
    public class HomeController : Controller
    {

        private TeraEntities db = new TeraEntities();
        //for image saving
        public ActionResult AddImage()
        {
            CaseReport c1 = new CaseReport();
            return View(c1);
        }
        //for image saving
        [HttpPost]
        public ActionResult AddImage(CaseReport model, HttpPostedFileBase image1)
        {
            var db = new TeraEntities();
            if (image1 != null)
            {
                model.CaseReportPhoto = new byte[image1.ContentLength];
                image1.InputStream.Read(model.CaseReportPhoto, 0, image1.ContentLength);
            }

            db.CaseReports.Add(model);
            db.SaveChanges();
            return View(model);
        }

        //for image retrieving
        public ActionResult GetImage()
        {
            return View(db.CaseReports.ToList());
        }
    }
}