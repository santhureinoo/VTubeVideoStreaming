using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class MoviesCounter : System.Web.UI.Page
    {
        public List<Movie> lstMovies = new List<Movie>();
        public int Count;
        private VSModel model = new VSModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               lstMovies = model.Movies.Take(12).ToList<Movie>();
            }
            Debug.WriteLine(lstMovies.Count());
            Count = 0;
            int curPagination = model.Movies.Count();
           // int tmpCount = lstMovies.Count;
            do
            {
                Count++;
                curPagination = curPagination - 12;
            } while (curPagination > 0);
            pagination.NumsOfPagination = Count;
            pagination.getPaginationIndex += Pagination_getPaginationIndex;
            movieCounter.GetMovieList += MovieCounter_GetMovieList;
            movieCounter.LstAllMovie = lstMovies;
            movieCounter.setMovie();
            this.DataBind();
        }

        private void MovieCounter_GetMovieList(List<Movie> filteredMov)
        {
            movieCounter.LstAllMovie = filteredMov.Take(12).ToList();
            movieCounter.setMovie();
        }

        private void Pagination_getPaginationIndex(int ind)
        {
            
            lstMovies = model.Movies.OrderBy(e=>e.ID).Skip(12 * (ind-1)).Take(12).ToList<Movie>();
            Debug.WriteLine(lstMovies.Count() + "HERE");
            pagination.CurrentIndex = ind;
            pagination.setInd();
            movieCounter.LstAllMovie = lstMovies;
            movieCounter.setMovie();
            //this.DataBind();
        }
    }
}