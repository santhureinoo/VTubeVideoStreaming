using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.UserRegisteration
{
    public partial class Regiser : System.Web.UI.Page
    {
        public VSModel model = new VSModel();
        public String ErrMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Confirm"] != null)
            {
                Debug.WriteLine("Confirm");
                if (Request.Params["id"] != null)
                {
                    Debug.WriteLine("ID");
                    int curUser = Int32.Parse(Request.Params["id"]);
                    User us = model.Users.Find(curUser);
                    us.isActive = 1;
                    model.SaveChanges();
                    Response.Redirect("~/UserLogin/Login.aspx");
                }
            }
            if (IsPostBack)
            {
                String email = Request.Params["email"];
                if (model.Users.Where(u=>u.Email.Equals(email)).Count() >0)
                {
                    ErrMsg = "Email Already Exists";
                    return;
                }
                User newUser = new User()
                {
                    DisplayName = Request.Params["display"],
                    Email = Request.Params["email"],
                    Password = Request.Params["password"],
                    isActive = 0
//                    Duration = DateTime.Now.AddDays(100).Millisecond
                };
                model.Users.Add(newUser);
                model.SaveChanges();
                
                User insertedUser = model.Users.Where(a => a.Email.Equals(email)).Single();

                MailMessage mail = new MailMessage();
                mail.To.Add(Request.Params["email"]);
               // mail.To.Add("Another Email ID where you wanna send same email");
                mail.From = new MailAddress("vtubevideostreaming@gmail.com");
                mail.Subject = "Registration";
                string Body = "Hi, Welcome From <b>VTube</b></br>" +
                    " Click This Link To <a href='http://"+Request.Url.Host+":"+Request.Url.Port+"/UserRegisteration/Regiser.aspx?Confirm=y&&id="+insertedUser.ID+"'>Confirm Your Email</a>"
                              ;
                mail.Body = Body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     ("vtubevideostreaming@gmail.com", "password-123");
                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(mail);
                }
                catch
                {
                    int curUser = Int32.Parse(Request.Params["id"]);
                    User us = model.Users.Find(curUser);
                    us.isActive = 1;
                    model.SaveChanges();
                }
                Response.Redirect("~/UserLogin/Login.aspx");
            }
           
        }
    }
}