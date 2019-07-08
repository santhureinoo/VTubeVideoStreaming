using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        VSModel model = new VSModel();
        public String ErrorMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                if(Request.Params["email"] != null)
                {
                    String email = Request.Params["email"];
                    String password = Request.Params["password"];
                    Session["CurAdmin"] = model.Admins.Where(admin => admin.Email.Equals(email) && admin.Password.Equals(password)).SingleOrDefault();
                    if(Session["CurAdmin"] == null)
                    {
                        ErrorMsg = "User Not Found.";
                    }
                    else
                    {
                        Response.Redirect("~/Admin/AdminVideoUploadAll.aspx");
                    }
                    
                }
            }
        }
    }
}