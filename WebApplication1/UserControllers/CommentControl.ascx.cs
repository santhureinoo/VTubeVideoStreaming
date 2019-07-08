using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.UserControllers
{
    public partial class CommentControl : System.Web.UI.UserControl
    {
        public User curUser;
        public Movie curMovie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(Request.Form["comment"]))
            {
                VSModel mod = new VSModel();
                mod.MoviesReviews.Add(new MoviesReview()
                {
                    Comment = Request.Form["comment"],
                    UserID = curUser.ID,
                    Date = DateTime.Now,
                    MovieID = curMovie.ID
                });
                mod.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}