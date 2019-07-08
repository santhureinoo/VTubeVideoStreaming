using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.api
{
    public class DownloadFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //await Conversion.Convert().start();
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition",
                               "attachment; filename=HarryPotter;");
            response.TransmitFile(HttpContext.Current.Server.MapPath("~/[CM] Harry Potter and the Chamber of Secrets (2002) Blu-Ray 1080p Largefile_2.mp4"));
            response.Flush();
            response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}