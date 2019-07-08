using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1.UserControllers
{
    public partial class ReviewControl : System.Web.UI.UserControl
    {
        public List<MoviesReview> lstReviews = new List<MoviesReview>();
        public User curUser;
        public Movie curMovie;
        public VSModel model = new VSModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                if(!String.IsNullOrWhiteSpace(Request.Form["deleteCom"])){
                    int cur = Int32.Parse(Request.Form["deleteCom"]);
                    model.MoviesReviews.Remove(model.MoviesReviews.Find(cur));
                    model.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }
               
            }
            reReview.DataSource = lstReviews;
            reReview.DataBind();
            com.curUser = curUser;
            com.curMovie = curMovie;
        }
        public String getNameByID(String id)
        {
            int curID = Int32.Parse(id);
            return new VSModel().Users.Where(e => e.ID == curID ).Single().DisplayName;
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }
        public bool isUserSame(String strID)
        {
            if (curUser.ID == Int32.Parse(strID))
            {
                return true;
            }
            else if(Session["curAdmin"] != null)
            {
                return true;
            }
            return false;
        }
    }
}