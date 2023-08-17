using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using e_comm.Content.Models;

namespace e_comm.Controllers
{
    public class AdminZoneController : Controller
    {
        //
        // GET: /AdminZone/
        demo_contectEntities db = new demo_contectEntities();
        public ActionResult Index()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('LogIn first then go to nextZone.');window.location.href='/Home/LogIn'</script>");
            }

            return View();

        }
        public ActionResult RegistrationMGMT()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('LogIn first then go to nextZone.');window.location.href='/Home/LogIn'</script>");
            }
            List<TBL_Reg> Lst = null;
            Lst = db.TBL_Reg.ToList();
            return View(Lst);
        }
        public void Delete()
        {
            try
            {
                string m = Request.QueryString["m"];
                TBL_Reg tbl1 = db.TBL_Reg.SingleOrDefault(x => x.Email == m);
                db.TBL_Reg.Remove(tbl1);
                db.SaveChanges();
                Response.Write("<script>alert('record DELETED successfully');window.location.href='/AdminZone/RegistrationMGMT'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('record not deleted successfully');window.location.href='/AdminZone/RegistrationMGMT'</script>");
            }
        }
        public void logout()
        {
            Session.Abandon();
            Response.Write("<script>alert('logOut');window.location.href='/Home/LogIn'</script>");
        }

        //GEt action call
        [HttpGet]
        public ActionResult RecordUpdate()
        {
            string Email = Request.QueryString["u"];
            TBL_Reg Reg = db.TBL_Reg.SingleOrDefault(x => x.Email == Email);
            return View(Reg);
        }
        [HttpPost]
        public void RecordUpdate(TBL_Reg reg, string Email)
        {
            TBL_Reg rg = db.TBL_Reg.SingleOrDefault(x => x.Email == Email);
            try
            {
                HttpPostedFileBase file = Request.Files["Profile"];
                reg.Profile = file.FileName;
                if (file.FileName != "")
                {

                    rg.Password = reg.Password;
                    rg.Address = reg.Address;
                    rg.city = reg.city;
                    rg.State = reg.State;
                    rg.Pin = reg.Pin;
                    rg.Profile = reg.Profile;
                    db.SaveChanges();
                    file.SaveAs(Server.MapPath("~/Content/Profile/" + file.FileName));
                    Response.Write("<script>alert('recorder updated successfully');window.location.href='/AdminZone/RegistrationMGMT'</script>");
                }
                else
                {
                    TBL_Reg rt = db.TBL_Reg.SingleOrDefault(x => x.Email == Email);
                    rt.Password = reg.Password;
                    rt.Address = reg.Address;
                    rt.city = reg.city;
                    rt.State = reg.State;
                    rt.Pin = reg.Pin;
                    rt.Profile = reg.Profile;
                    db.SaveChanges();
                    file.SaveAs(Server.MapPath("~/Content/Profile/" + file.FileName));
                    Response.Write("<script>alert('recorder not updated succesfully');window.location.href='/AdminZone/RegistrationMGMT'</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('recorder not updated');window.location.href='/AdminZone/RegistrationMGMT'</script>");
            }
        }



        public ActionResult ContectMGMT()
        {
            List<TBL_Contact> con = null;
            con = db.TBL_Contact.ToList();
            return View(con);
        }
        public ActionResult ReturnMGMT()
        {
            List<TBL_ReturnOrder> RET = null;
            RET = db.TBL_ReturnOrder.ToList();
            return View(RET);
        }
        public ActionResult ComplainMGMT()
        {
            List<TBL_ComplainOrder> Com = null;
            Com = db.TBL_ComplainOrder.ToList();
            return View(Com);
        }
        public ActionResult CancleMGMT()
        {
            List<TBL_Cancle> Can = null;
            Can = db.TBL_Cancle.ToList();
            return View(Can);
        }
        public ActionResult ChangePassword()
        {                           
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldpassword, string newpassword, string confirmpassword)
        {
            if (newpassword == confirmpassword)
            {
                
                string userid = Session["aid"].ToString();
                TBL_login lg = db.TBL_login.Where(x => x.password == oldpassword && x.name == userid).SingleOrDefault();
                lg.password = newpassword;
                db.SaveChanges();
                Response.Write("<script>alert('Your Password changed ');window.location.href='../Home/LogIn'</script>");
            }
            else
            {
                Response.Write("<script>alert('Plz confirm password')</script>");
            }
            return View();
        }
       

    }
}
