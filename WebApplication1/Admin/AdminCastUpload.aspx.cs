using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.Admin
{
    public partial class AdminCastUpload : System.Web.UI.Page
    {
        VSModel model = new VSModel();
        public Cast curCast;
        int curID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out curID))
            {
                curCast = model.Casts.Where(cas => cas.ID == curID).Single<Cast>();
                // Debug.WriteLine(Request.Params["ID"]);
            }
            if (Page.IsPostBack)
            {
                if (Request.Form["state"] != null)
                {
                    if (Request.Form["state"].Equals("Insert"))
                    {
                        HttpPostedFile photo = Request.Files["photo"];
                        model.Casts.Add(new Cast()
                        {
                            Name = Request.Form["name"],
                            Bio = Request.Form["biography"],
                            Country = Request.Form["country"]
                        });
                        model.SaveChanges();
                        if (photo != null && photo.ContentLength > 0)
                        {
                            if (!Directory.Exists((Server.MapPath("~/Casts/"))))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Casts/"));
                            }
                            photo.SaveAs(Server.MapPath("~/Casts/") + Request.Form["name"].Replace(' ', '_') + ".JPG");
                        }

                    }
                    else if (Request.Form["state"].Equals("Update"))
                    {
                        Cast curCast = model.Casts.Where(mov => mov.ID == curID).Single();
                        if (Request.Files["photo"] != null)
                        {
                            if (File.Exists(Server.MapPath("~/Casts/") + curCast.Name.Replace(' ', '_') + ".JPG"))
                            {
                                File.Delete(Server.MapPath("~/Casts/") + curCast.Name.Replace(' ', '_') + ".JPG");
                               // Directory.Move(Server.MapPath("~/Casts/") + curCast.Name.Replace(' ', '_')+".JPG", Server.MapPath("~/Casts/") + Request.Form["name"].Replace(' ', '_') + ".JPG");
                            }
                            Request.Files["photo"].SaveAs(Server.MapPath("~/Casts/") + (Request.Form["name"] != null ? Request.Form["name"] : curCast.Name).Replace(' ', '_') + ".JPG");    
                        }
                        curCast.Name = Request.Form["name"];
                        curCast.Bio = Request.Form["biography"];
                        curCast.Country = Request.Form["country"];
                        model.SaveChanges();

                    }
                }
               
            }
        }
    }
}