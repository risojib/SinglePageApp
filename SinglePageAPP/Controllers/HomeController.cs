using Evidence.Data;
using Evidence.Models;
using Evidence.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence.Controllers
{
    public class HomeController : Controller
    {
        MySPADbContext db = new MySPADbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SPA()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Countries()
        {
            var obj = db.Countries.OrderBy(x => x.CountryName).ToList();
            return Json(obj);
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            var listContact = (from c in db.Contacts
                               join d in db.Countries on c.CountryId equals d.CountryId
                               select new
                               {
                                   c.ContactId,
                                   c.ContactName,
                                   c.CountryId,
                                   c.DateOfBirth,
                                   c.Gender,
                                   c.PicPath,
                                   d.CountryName
                               }).ToList();
            return Json(listContact);
        }

        [HttpGet]
        public IActionResult Contact(int id)
        {
            var obj = db.Contacts.Where(x => x.ContactId == id).FirstOrDefault();
            return Json(obj);
        }
        [HttpPost]
        public IActionResult ContactAdd([FromForm] VmContact contact)
        {
            object res = null;
            var oContact = db.Contacts.Where(x => x.ContactId == contact.ContactId).FirstOrDefault();
            if (oContact == null)
            {
                string fileName = "";
                if (contact.PicPath != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pics");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    FileInfo fileInfo = new FileInfo(contact.PicPath.FileName);
                    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    fileName = newFileName + fileInfo.Extension;
                    string fileNameWithPath = Path.Combine(path, fileName);
                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        contact.PicPath.CopyTo(stream);
                    }
                }
                oContact = new Contact();
                oContact.ContactName = contact.ContactName;
                oContact.CountryId = contact.CountryId;
                oContact.DateOfBirth = contact.DateOfBirth;
                oContact.Gender = contact.Gender;
                oContact.PicPath = fileName;
                db.Add(oContact);
                db.SaveChanges();
                res = new
                {
                    resstate = true
                };
            }
            return Json(res);
        }

        [HttpPut]
        public IActionResult ContactEdit(VmContact contact)
        {
            object res = null;
            var oContact = db.Contacts.Where(x => x.ContactId == contact.ContactId).FirstOrDefault();
            if (oContact != null)
            {
                string fileName = "";
                if (contact.PicPath != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pics");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    FileInfo fileInfo = new FileInfo(contact.PicPath.FileName);
                    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    fileName = newFileName + fileInfo.Extension;
                    string fileNameWithPath = Path.Combine(path, fileName);
                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        contact.PicPath.CopyTo(stream);
                    }
                    if (!string.IsNullOrEmpty(oContact.PicPath))
                    {
                        string fileNameWithPathDEL = Path.Combine(path, oContact.PicPath);
                        if (System.IO.File.Exists(fileNameWithPathDEL))
                        {
                            System.IO.File.Delete(fileNameWithPathDEL);
                        }
                    }
                }
                oContact.ContactName = contact.ContactName;
                oContact.CountryId = contact.CountryId;
                oContact.DateOfBirth = contact.DateOfBirth;
                oContact.Gender = contact.Gender;
                oContact.PicPath = fileName;
                db.SaveChanges();
                res = new
                {
                    resstate = true
                };
            }
            return Json(res);
        }

        [HttpDelete]
        public IActionResult ContactRemove(int id)
        {
            object res = null;
            var oContact = db.Contacts.Where(x => x.ContactId == id).FirstOrDefault();
            if (oContact != null)
            {
                db.Contacts.Remove(oContact);
                db.SaveChanges();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pics");
                if (!string.IsNullOrEmpty(oContact.PicPath))
                {
                    string fileNameWithPathDEL = Path.Combine(path, oContact.PicPath);
                    if (System.IO.File.Exists(fileNameWithPathDEL))
                    {
                        System.IO.File.Delete(fileNameWithPathDEL);
                    }
                }
                res = new
                {
                    resstate = true
                };
            }
            return Json(res);
        }
    }
}

