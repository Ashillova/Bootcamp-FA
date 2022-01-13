using FitnessApp.Models;
using FitnessApp.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FitnessApp.Models.Class1;

namespace FitnessApp.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "Data source=DESKTOP-UTUINDG; database=tempdb; integrated security = true;";
        }
        [HttpPost]
        public ActionResult Verify(Login acc)
        {
            SecurityService securityService = new SecurityService();

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Table1 where username = " + acc.Username + " and Password= " + acc.Password + "";
            dr = com.ExecuteReader();
            if(securityService.IsValid(acc))
            {
                con.Close();
                return View("Index");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            
            
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
        private MyDbContext DbContext = new MyDbContext();
        public ActionResult List()
        {
            var list = DbContext.NewUser.ToList();


            return View("List", list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SignUp model)
        {
            var isValid = ModelState.IsValid;
            if (isValid)
            {
                DbContext.NewUser.Add(model);
                DbContext.SaveChanges();
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var costumer = DbContext.NewUser.Where(x => x.ID == id).FirstOrDefault();
            return View(costumer);
        }

        [HttpPost]
        public ActionResult Edit(SignUp model)
        {
            if (ModelState.IsValid)
            {
                var c = DbContext.NewUser.Where(x => x.ID == model.ID).FirstOrDefault();
                c.Firstname = model.Firstname;
                c.Lastname = model.Lastname;
                c.Username = model.Username;
                c.Email = model.Email;
                c.BirthDate = model.BirthDate;
                DbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var c = DbContext.NewUser.Where(x => x.ID == id).FirstOrDefault();
            DbContext.NewUser.Remove(c);
            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}