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
    public partial class FilterControl : System.Web.UI.UserControl
    {
        public delegate void GetMovieList(List<Movie> filteredMov);
        public event GetMovieList getMovieList;
        public List<Movie> lstMovie;
        protected void Page_Load(object sender, EventArgs e)
        {
            VSModel model = new VSModel();
            lstMovie = model.Movies.ToList();
            if(Request.Form["genSearch"] != null)
            {
                lstMovie = lstMovie.Where(mov => mov.Title.Contains(Request.Form["genSearch"])).ToList();
            }
            if (Request.Form["title"] != null)
            {
               lstMovie = lstMovie.Where(mov => mov.Title.Contains(Request.Form["title"])).ToList();
            }
            if(!(String.IsNullOrWhiteSpace(Request.Form["tagsTag"])))
            {
                lstMovie = lstMovie.Where(mov => mov.Tags.Where(tag=>tag.Name.Equals(Request.Form["tagsTag"])).Count() > 0).ToList();
            }
            if(!String.IsNullOrWhiteSpace(Request.Form["castsTag"]))
            {
                lstMovie = lstMovie.Where(mov => mov.Casts.Where(cas => cas.Name.Equals(Request.Form["castsTag"])).Count() > 0).ToList();
            }
            if((Request.Form["year"] != null && Request.Form["year"] != "0"))
            {
                int year = Int32.Parse(Request.Form["year"]);
                lstMovie = lstMovie.Where(mov => mov.Date.Year == year).ToList();
            }
            getMovieList(lstMovie);
        }
    }
}