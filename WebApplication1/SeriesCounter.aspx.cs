﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class SeriesDetail : System.Web.UI.Page
    {
        VSModel model = new VSModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            series.DataSource = model.Series.ToList<Series>();
        }
    }
}