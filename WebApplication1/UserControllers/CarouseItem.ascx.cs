using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UserControllers
{
    public partial class CarouseItem : System.Web.UI.UserControl
    {
        private Boolean isActive;
        public bool IsActive { get => isActive; set => isActive = value; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}