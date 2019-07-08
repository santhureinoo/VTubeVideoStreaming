using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.UserControllers
{
    public partial class MoviesCounter : System.Web.UI.UserControl
    {
        private List<Movie> lstAllMovie;
        private Boolean isMore =false;
        public List<Movie> LstAllMovie { get => lstAllMovie; set => lstAllMovie = value; }
        public bool IsMore { get => isMore; set => isMore = value; }
        public delegate void getMovieList(List<Movie> filteredMov);
        public event getMovieList GetMovieList;

        protected void Page_Load(object sender, EventArgs e)
        {
            filterCon.getMovieList += FilterCon_getMovieList;
        }

        private void FilterCon_getMovieList(List<Movie> filteredMov)
        {
            GetMovieList(filteredMov);
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id = Int32.Parse(btn.CommandArgument);
            Movie curMov = new VSModel().Movies.Where(movie => movie.ID == id).Single();
            Response.ClearContent();
            Response.Clear();
            Response.ContentType = "video/mp4";
            Response.AddHeader("Content-Disposition",
                               "attachment; filename="+curMov.Title+".mp4;");
            Response.TransmitFile(HttpContext.Current.Server.MapPath("~/Movies/"+curMov.Title.Replace(' ','_')+"/"+curMov.Title.Replace(' ','_')+".mp4"));
            try
            {
                Response.Flush();
            }
            catch(Exception e1)
            {

            }
            Response.End();
        }

        public string GenerateImage(String path)
        {
            return "~/Movies/" + path.Replace(' ','_') + "/" + "poster.JPG";
        }

        public void setMovie()
        {
            repeater.DataSource = lstAllMovie;
            repeater.DataBind();
            this.DataBind();
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id = Int32.Parse(btn.CommandArgument);
            Session["CurrentMovie"] = new VSModel().Movies.Where(movie => movie.ID == id).Single();
            Response.Redirect("MovieDetail.aspx");
        }
    }
}