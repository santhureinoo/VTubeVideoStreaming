using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UserControllers
{
    public partial class Pagination : System.Web.UI.UserControl
    {
        private int numsOfPagination=5;
        public int CurrentIndex;
        public delegate void paginationIndex(int ind);
        public event paginationIndex getPaginationIndex;
        public int NumsOfPagination { get => numsOfPagination; set => numsOfPagination = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ind"] != null && getPaginationIndex != null)
            {
                if(Request.Form["ind"].Equals("First"))
                    getPaginationIndex(1);
                else if(Request.Form["ind"].Equals("Last"))
                    getPaginationIndex(numsOfPagination);
                else
                getPaginationIndex(Int32.Parse(Request.Form["ind"]));
                // sendIndex(this, new EventArgs());
            }
        }
        public void Page_Init(object o, EventArgs e)
        {
           
        }
        public void setInd()
        {
            
        }
    }
}