using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class Main : System.Web.UI.Page
    {
        VSModel model = new VSModel();
        public Movie curMovie = new Movie();
        public List<Movie> relatedMovies = new List<Movie>();
        public List<MoviesReview> relatedReviews = new List<MoviesReview>();
        public User curUser;
        public List<Cast> lstCast = new List<Cast>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CurrentMovie"] != null)
            {
                curMovie = Session["CurrentMovie"] as Movie;
                castRepeater.DataSource = curMovie.Casts.ToList();
                castRepeater.DataBind();
                List<Tag> tm = curMovie.Tags.ToList();
                tm.ForEach(a =>
                {
                    List<Movie> tmp = model.Movies.Where(m => m.Tags.Any(t=>t.Name.Equals(a.Name))).ToList();
                   relatedMovies = relatedMovies.Union(tmp).ToList();
                });
                multiCarousel.lstMovies = relatedMovies;
                int id = Int32.Parse(HttpContext.Current.User.Identity.Name);
                curUser = new VSModel().Users.Where(user => user.ID == id).Single();
                reviewsControl.lstReviews = model.MoviesReviews.Where(selected => selected.MovieID == curMovie.ID).OrderByDescending(rev => rev.Date).ToList();
                reviewsControl.curUser = curUser;
                reviewsControl.curMovie = curMovie;
            }
            else
            {

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Clear();
            Response.ContentType = "video/mp4";
            Response.AddHeader("Content-Disposition",
                               "attachment; filename=" + curMovie.Title + ".mp4;");
            Response.TransmitFile(HttpContext.Current.Server.MapPath("~/Movies/" + curMovie.Title.Replace(' ', '_') + "/" + curMovie.Title.Replace(' ', '_') + ".mp4"));
            try
            {
                Response.Flush();
            }
            catch (Exception e1)
            {

            }
            Response.End();
        }

        protected void vinp_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            FileStream fs = File.Open(Server.MapPath("~/Movies/" + curMovie.Title.Replace(' ','_') + "/Stream/Stream.m3u8"), FileMode.Open, FileAccess.ReadWrite);
            using (BufferedStream bs = new BufferedStream(fs))
            {
                using (StreamReader sr = new StreamReader(bs))
                {

                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        if (line.Contains(".ts"))
                        {
                            if(!line.Contains("http://"))
                            {
                                line = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/" + "Movies/" + curMovie.Title.Replace(' ', '_') + "/Stream/" + line;
                            }
                             Debug.WriteLine(line);
                        }
                        sb.AppendLine(line);
                    }

                }
            }
            using (FileStream fileStream = new FileStream(Server.MapPath("~/Movies/" + curMovie.Title.Replace(' ', '_') + "/Stream/Stream.m3u8"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(sb.ToString());
                streamWriter.Close();
                fileStream.Close();
            }
        }
    }
}