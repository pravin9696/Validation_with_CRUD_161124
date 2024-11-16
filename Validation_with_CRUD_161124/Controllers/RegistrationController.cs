using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Validation_with_CRUD_161124.Models;
using Validation_with_CRUD_161124.Models.validationFiles;

namespace Validation_with_CRUD_161124.Controllers
{
    public class RegistrationController : Controller
    {
        private StudDBEntities dbo = new StudDBEntities();
        // GET: Registration
        public ActionResult Index()
        {
            List<tblRegistration> registrations = dbo.tblRegistrations.ToList();
            return View(registrations);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(RegistrationValidation rv)
        {
            if (ModelState.IsValid)
            {
                tblRegistration reg = new tblRegistration();
                reg.FirstName = rv.FirstName;
                reg.LastName = rv.LastName;
                reg.Email = rv.Email;
                reg.Password = rv.Password;
                dbo.tblRegistrations.Add(reg);
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblRegistration reg = dbo.tblRegistrations.Find(id);
            if (reg!=null)
            {
                dbo.tblRegistrations.Remove(reg);
                int n= dbo.SaveChanges();
                
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            tblRegistration reg = dbo.tblRegistrations.Find(id);
            //tblRegistration reg1 = dbo.tblRegistrations.FirstOrDefault(x => x.Id == id);
            //tblRegistration reg2=dbo.tblRegistrations.Where(x=>x.Id == id).FirstOrDefault();

            if (reg != null)
            {
                RegistrationValidation rv = new RegistrationValidation();
                rv.Id = id;
                rv.FirstName = reg.FirstName;
                rv.LastName = reg.LastName;
                rv.Email = reg.Email;
                rv.Password = reg.Password;
                return View(rv);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(RegistrationValidation rv)
        {
            if (ModelState.IsValid)
            {
                tblRegistration reg = dbo.tblRegistrations.FirstOrDefault(x => x.Id == rv.Id);
                reg.FirstName = rv.FirstName;
                reg.LastName = rv.LastName;
                reg.Email = rv.Email;
                reg.Password = rv.Password;

                 int n= dbo.SaveChanges();
                if (n > 0) { 
                return RedirectToAction("Index");
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            tblRegistration reg = dbo.tblRegistrations.Find(id);
            //tblRegistration reg1 = dbo.tblRegistrations.FirstOrDefault(x => x.Id == id);
            //tblRegistration reg2=dbo.tblRegistrations.Where(x=>x.Id == id).FirstOrDefault();

            return View(reg);
        }
    }
}