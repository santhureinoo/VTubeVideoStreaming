using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.UserControllers
{
    public partial class MultiItemCarousel : System.Web.UI.UserControl
    {
        public List<Movie> lstMovies;
        public String Title;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            movieRepeater.DataSource = lstMovies;
            movieRepeater.DataBind();
        }
        public string GenerateImage(String path)
        {
            return "~/Movies/" + path.Replace(' ', '_') + "/" + "poster.JPG";
        }

        protected void Unnamed_Click(object sender, CommandEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int id = Int32.Parse(btn.AlternateText);
            Session["CurrentMovie"] = new VSModel().Movies.Where(movie => movie.ID == id).Single();
            Response.Redirect("MovieDetail.aspx");
        }
    }
}