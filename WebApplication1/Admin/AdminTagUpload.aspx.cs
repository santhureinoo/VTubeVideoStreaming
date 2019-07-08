using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.Admin
{
    public partial class AdminTagUpload : System.Web.UI.Page
    {
        public int curID;
        public Tag curTag;
        public VSModel model = new VSModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out curID))
            {
                curTag = model.Tags.Where(mov => mov.ID == curID).Single<Tag>();
                // Debug.WriteLine(Request.Params["ID"]);
            }
            if (Page.IsPostBack)
            {
                if (Request.Form["state"] != null)
                {
                    if (Request.Form["state"].Equals("Insert"))
                    {
                        model.Tags.Add(new Tag()
                        {
                            Name = Request.Form["name"]

                        });
                        model.SaveChanges();
                    }
                    else
                    {
                        curTag.Name = Request.Form["name"];
                        model.SaveChanges();
                    }
                }
            }
        }
    }
}