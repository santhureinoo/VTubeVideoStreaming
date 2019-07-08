using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.api;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        VSModel model = new VSModel();
        public String errorMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["email"] != null && Request.Params["id"] != null && Request.Params["cd"] != null)
            {
                String[] lstHas = Hash.GetHashString(Request.Params["cd"]).Split('-');
                if(Session["noti" + lstHas[0]] != null) {
                    if(Session["noti" + lstHas[0]] == lstHas[1]) {
                        model.Users.Find(Int32.Parse(Request.Params["id"])).Email = Request.Params["email"];
                        model.SaveChanges();
                        Session.Abandon();
                    }
                }
               
            }
            if ((HttpContext.Current.User.Identity.IsAuthenticated))
            {
                Response.Redirect("~/Default.aspx");
            }
            if (IsPostBack)
            {
                if (!(HttpContext.Current.User.Identity.IsAuthenticated))
                {
                    String email = Request.Params["email"];
                    String password = Request.Params["password"];
                    if (model.Users.Where(user =>user.isActive == 1 && user.Email.Equals(email.Trim()) &&
                        user.Password.Equals(password.Trim())).Count() > 0)
                    {
                        FormsAuthentication.SetAuthCookie(model.Users.Where(user => user.Email.Equals(email) &&
                        user.Password.Equals(password)).Single().ID.ToString(), true);
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(User.Identity, new String[] { "User"});
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        errorMsg = "User Not Found";
                    }
                         
                }
                else
                {
                    Debug.WriteLine(HttpContext.Current.User.Identity.Name);
                    Response.Redirect("~/Default.aspx");
                }
            
            }
            
        }
    }
}