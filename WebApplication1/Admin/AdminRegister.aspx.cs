using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.Admin
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        VSModel model = new VSModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.Params["id"] != null) 
                {
                    int curID = Int32.Parse(Request.Params["id"]);
                    var admin = model.Admins.Where(ad => ad.ID == curID).Single();
                    if (!String.IsNullOrWhiteSpace(Request.Params["email"]) )
                    {
                        admin.Email = Request.Params["email"];
                    }
                    if (!String.IsNullOrWhiteSpace(Request.Params["pas"]))
                    {
                        admin.Password = Request.Params["pas"];
                    }
                    model.SaveChanges();
                }
               
            }
        }
    }
}