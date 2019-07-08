using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;
using WebApplication1.api;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        public VSModel model;
        public User curUser;
        public String ErrorMsg;
        public Random rdnCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            model = new VSModel();
            rdnCode = new Random();
            if (!(HttpContext.Current.User.Identity.IsAuthenticated))
            {
                //Debug.WriteLine("Insert");
                //Window.location = "MovieDetail.aspx";
                Response.Redirect("~/UserLogin/Login.aspx",true);
                //FormsAuthentication.SetAuthCookie("CookieMan", true);
            }
            else
            {
                VSModel model = new VSModel();
                int id =Int32.Parse(HttpContext.Current.User.Identity.Name);
                curUser = model.Users.Where(user => user.ID == id).Single();
                var sta = false;
                if (IsPostBack)
                {
                    if(Request.Form["name"] != null && Request.Form["email"] != null && Request.Form["oldPass"] != null && Request.Form["newPass"] != null)
                    {
                        if(curUser.Password.Equals(Request.Form["oldPass"]))
                        {
                            if(!curUser.Email.Equals(Request.Form["email"]))
                            {
                                Session["noti" + curUser.ID] = rdnCode.Next(1, 100);
                                MailMessage mail = new MailMessage();
                                mail.To.Add(curUser.Email);
                                // mail.To.Add("Another Email ID where you wanna send same email");
                                mail.From = new MailAddress("vtubevideostreaming@gmail.com");
                                mail.Subject = "Update Your Account";
                                string Body = "Hi, To Update Your Email, Click The Following Link <br/><a href='http://" + Request.Url.Host + ":" + Request.Url.Port + "/UserLogin/Login.aspx?id=" + curUser.ID + "&&email=" + Request.Form["email"]+">Confirm</a> ";
                                mail.Body = Body;

                                mail.IsBodyHtml = true;
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                                smtp.Credentials = new System.Net.NetworkCredential
                                     ("vtubevideostreaming@gmail.com", "password-123");
                                //Or your Smtp Email ID and Password
                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                                sta = true;
                                

                            }
                            curUser.DisplayName = Request.Form["name"];
                            curUser.Email = Request.Form["email"];
                            if(!String.IsNullOrWhiteSpace(Request.Form["newPass"]))
                            {
                               
                                curUser.Password = Request.Form["newPass"];
                            }
                            model.SaveChanges();
                            if(sta)
                            {
                                FormsAuthentication.SignOut();
                                Session.Abandon();
                                Response.Redirect("~/UserLogin/Login.aspx");
                            }
                        }
                        
                    }
                }
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
           FormsAuthentication.SignOut();
           Session.Abandon();
            Response.Redirect("~/UserLogin/Login.aspx");
        }
    }
}