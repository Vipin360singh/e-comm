using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using e_comm.Content.Models;

namespace e_comm.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        demo_contectEntities db = new demo_contectEntities();
        public ActionResult Index()
        {
            return View();
        }
        //get action view for Registration
        public ActionResult Registration()
        {
            return View();
        }
        // use for save record code in reg
        [HttpPost]
        public ActionResult Registration(TBL_Reg REG,string hdn1,string ct1)
        {
            try
            {
                if (hdn1 == ct1)
                {
                    //wirte of profile
                    HttpPostedFileBase file = Request.Files["Profile"];
                    REG.Profile = file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/Profile/" + file.FileName));
                    //get data & time
                    REG.RegDate = DateTime.Now;
                    //ENd data and tiem

                    db.TBL_Reg.Add(REG);
                    db.SaveChanges();
                    Response.Write("<script>alert('Registered Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Some Problem in Registration')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Not Register')</script>");
            }
            return View();
        }
        //get action view for login
        public ActionResult LogIn()
        {
            return View();
        }
        // use for save record code in login
        [HttpPost]
        public ActionResult LogIn(TBL_login lg)
        {
            try
            {
            TBL_login t1 = db.TBL_login.Where(X => X.name == lg.name && X.password == lg.password).SingleOrDefault();
            if (t1 != null)
            {
                Session["aid"] = t1.name;
                Response.Write("<script>alert('Welcome to AdminZone');window.location.href='/AdminZone/Index'</script>");
            }
            else
            {
                Response.Write("<script>alert('Invailed Userid or Password')</script>");
            }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invailed Userid or Password')</script>");
            }
            return View();
        }
        
        //get action view for contect
        public ActionResult Contect()
        {
            return View();
        }
        // use for save record code in contect
        [HttpPost]
        public ActionResult Contect(TBL_Contact Con)
        {
            try
            {
                
                db.TBL_Contact.Add(Con); 
                db.SaveChanges();
                Response.Write("<script>alert('Record Save Successfully')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record Not Save ')</script>");
            }
            return View();
        }
        public ActionResult Imagegallery()
        {
            return View();
        }
        public ActionResult Notification()
        {
            return View();
        }
        public ActionResult MyOrder()
        {
            return View();
        }
        public ActionResult OrderCancellation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderCancellation(TBL_Cancle Can)
        {
            try
            {
                db.TBL_Cancle.Add(Can);
                db.SaveChanges();
                Response.Write("<script>alert('Your product cancellation Successfully')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Your canclation rejected try again')</script>");
            }
            return View();
        }
        //get action view for Return Order
        public ActionResult ReturnOrder()
        {
            return View();
        }
        //use for save record code in return Order
        [HttpPost]
        public ActionResult ReturnOrder(TBL_ReturnOrder RET)
        {
            try
            {
                //get data & time
                //RET.RegDate = DateTime.Now;
                db.TBL_ReturnOrder.Add(RET);
                db.SaveChanges();
                Response.Write("<script>alert('request save Successfully we will return your order soon')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Your return request Not Save ')</script>");
            }
            return View();
        }
        //get action view for Complaint
        public ActionResult OrderComplaint()
        {
            return View();
        }
        // use for save record code in complaint
        [HttpPost]
        public ActionResult OrderComplaint(TBL_ComplainOrder Com)
        {
            try
            {
                db.TBL_ComplainOrder.Add(Com);
                db.SaveChanges();
                Response.Write("<script>alert('Your Complaint Save Successfully')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Your Complaint Not Save ')</script>");
            }
            return View();
        }
    }
}
