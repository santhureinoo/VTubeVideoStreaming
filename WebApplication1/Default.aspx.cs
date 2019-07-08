using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebApplication1.Model;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        VSModel model = new VSModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                if(!String.IsNullOrWhiteSpace(Request.Form["search"])) {
                    String searchMove = Request.Form["search"];
                    Movie searchedMovie = model.Movies.Where(mov => mov.Title.Equals(searchMove)).SingleOrDefault();
                    if(searchedMovie == null)
                    {
                        List<Movie> recomm = model.Movies.Where(a => a.Title.Contains(searchMove)).ToList();
                        Session["recommend"] = recomm;
                        Response.Redirect("NotFound.aspx");
                    }
                    Session["CurrentMovie"] = searchedMovie;
                    Response.Redirect("MovieDetail.aspx");
                }
            }
            User currentUser = new User();
            if ((HttpContext.Current.User.Identity.IsAuthenticated))
            {
                int id = Int32.Parse(HttpContext.Current.User.Identity.Name);
                currentUser = new VSModel().Users.Where(user => user.ID == id).Single();
            }
            DateTime today = DateTime.Now;
            DateTime oneMonthAgo = today.AddDays(-30);
            List<Tag> lstTags = new List<Tag>();
            List<Movie> TrendingMovies = new List<Movie>();
            foreach( var t in model.Histories.OrderBy(byDate => byDate.Date).Take(50).GroupBy(ge => ge.MovieID).Select(g => new { id = g.Key, count = g.Count() }).OrderBy(a => a.count).Select(n => model.Movies.Where(mo => mo.ID == n.id).FirstOrDefault()).ToList())
            {
                Debug.WriteLine("HERE _ " + t.Title);
            }
            trendingMoviesCounter.lstMovies = model.Histories.OrderByDescending(byDate => byDate.Date).Take(50).GroupBy(ge => ge.MovieID).Select(g => new { id = g.Key, count = g.Count() }).OrderBy(a => a.count).Select(n => model.Movies.Where(mo => mo.ID == n.id).FirstOrDefault()).ToList();
           
            if (currentUser != null)
            {
                lstTags = model.Histories.Where(his => his.UserID == currentUser.ID && DateTime.Compare(his.Date, oneMonthAgo) >= 0 && DateTime.Compare(his.Date, today) <= 0).SelectMany(toMovie => toMovie.Movie.Tags).Distinct().ToList();
            }
            foreach(var tag in lstTags)
            {
                Debug.WriteLine(tag.Name);
                List<Movie> tmp = model.Movies.Where(mov => mov.Tags.Any(t=>t.Name.Equals(tag.Name))).ToList();
               TrendingMovies = TrendingMovies.Union(tmp).ToList();
            }
            recommendMoviesCounter.lstMovies = TrendingMovies;
            foreach (var mo in TrendingMovies)
            {
                Debug.WriteLine(mo.Title);
            }
        }
    }
}