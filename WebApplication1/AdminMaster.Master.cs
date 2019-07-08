using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        public WebApplication1.Model.Admin currentAdmin;
        public String errorMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["curAdmin"] != null)
            {
              currentAdmin = Session["curAdmin"] as WebApplication1.Model.Admin;
            }
            else
            {
                Response.Redirect("~/Admin/AdminLogin.aspx");
            }
            if ( Request.Form["email"] != null && Request.Form["oldPass"] != null && Request.Form["newPass"] != null)
            {
                if (currentAdmin.Password.Equals(Request.Form["oldPass"]))
                {
                    if (!currentAdmin.Email.Equals(Request.Form["email"]))
                    {
                        MailMessage mail = new MailMessage();
                        mail.To.Add(currentAdmin.Email);
                        // mail.To.Add("Another Email ID where you wanna send same email");
                        mail.From = new MailAddress("vtubevideostreaming@gmail.com");
                        mail.Subject = "Registration";
                        string Body = "Hi, To Update New Email, Click The Following Link <br/><a href='http://" + Request.Url.Host + ":" + Request.Url.Port + "/Admin/AdminRegister.aspx?id=" + currentAdmin.ID + "&&pas=" + Request.Form["newPass"] + "&&email=" + Request.Form["email"] + "'>Confirm</a> ";
                        mail.Body = Body;

                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                        smtp.Credentials = new System.Net.NetworkCredential
                             ("vtubevideostreaming@gmail.com", "password-123");
                        //Or your Smtp Email ID and Password
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                    }
                }
            }
             

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Session["curAdmin"] != null)
            {
                Session["curAdmin"] = null;
                Response.Redirect("~/Admin/AdminLogin.aspx");
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            
            MailMessage mail = new MailMessage();
            mail.To.Add(currentAdmin.Email);
            // mail.To.Add("Another Email ID where you wanna send same email");
            mail.From = new MailAddress("vtubevideostreaming@gmail.com");
            mail.Subject = "Registration";
            string Body = "Hi, To Update New Email, Click The Following Link <br/><a href='http://" + Request.Url.Host + ":" + Request.Url.Port + "/Admin/AdminRegister.aspx?id="+currentAdmin.ID+"&&pas="+Request.Form["newPass"]+"&&email="+Request.Form["email"]+"'>Confirm</a> ";
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("vtubevideostreaming@gmail.com", "password-123");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
            Session["curAdmin"] = null;
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
    }
}