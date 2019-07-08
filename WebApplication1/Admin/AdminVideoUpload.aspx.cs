using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class AdminVideoUpload : System.Web.UI.Page
    {
        public VSModel model = new VSModel();
        String curTitle, curPort,curHost;
        public Movie curMovie;
        int curID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
          //  Process.Start(Server.MapPath("~/ffmpeg/bin/") + "ffmpeg.exe");
            if(Request.Params["ID"] != null && int.TryParse(Request.Params["ID"],out curID))
            {
                curMovie = model.Movies.Where(mov => mov.ID == curID).Single<Movie>();
               // Debug.WriteLine(Request.Params["ID"]);
            }
            if (Page.IsPostBack)
            {
                if(Request.Form["state"] !=null )
                {
                    if (Request.Form["state"].Equals("Insert"))
                    {
                        HttpPostedFile file = Request.Files["movie"];
                        HttpPostedFile trailer = Request.Files["trailer"];
                        HttpPostedFile poster = Request.Files["poster"];
                        Debug.WriteLine(Request.Form["comBudget"]);
                        Movie movie = new Movie()
                        {
                            Title = Request.Form["title"],
                            Description = Request.Form["description"],
                            Rating = Int32.Parse(Request.Form["rating"]),
                            Date = Convert.ToDateTime(Request.Form["date"]),
                            Director = Request.Form["director"],
                            Budget = Request.Form["comBudget"],
                            Country = Request.Form["country"],
                            Language = Request.Form["language"],
                            Production = Request.Form["production"],
                            Casts = Request.Form["cast"].Split(',').Select(stc => model.Casts.Where(a => a.Name.Equals(stc)).FirstOrDefault()).ToList(),
                            Tags = Request.Form["tag"].Split(',').Select(stc => model.Tags.Where(a => a.Name.Equals(stc)).FirstOrDefault()).ToList()
                        };
                        //check file was submitted
                        if (file != null && file.ContentLength > 0)
                        {
                            if (!Directory.Exists((Server.MapPath("~/Movies/"))))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Movies/"));
                            }
                            string fname = Path.GetFileName(file.FileName);
                            Directory.CreateDirectory(Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_'));
                            Directory.CreateDirectory(Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_') + "/Stream");
                            file.SaveAs(Server.MapPath(Path.Combine("~/Movies/" + Request.Form["title"].Replace(' ', '_') + "/", Request.Form["title"].Replace(' ','_') + ".mp4")));
                            trailer.SaveAs(Server.MapPath(Path.Combine("~/Movies/" + Request.Form["title"].Replace(' ', '_') + "/", "trailer.mp4")));
                            poster.SaveAs(Server.MapPath(Path.Combine("~/Movies/" + Request.Form["title"].Replace(' ', '_') + "/", "poster." + "JPG")));
                            movie.Path = Request.Form["title"].Replace(' ', '_'); //Server.MapPath("~/Movies/" + Request.Form["title"].Replace(' ', '_') + "/" + Request.Form["title"] + ".mp4");
                            model.Movies.Add(movie);
                            try
                            {
                                model.SaveChanges();
                            }
                            catch (DbEntityValidationException ex)
                            {
                                // Retrieve the error messages as a list of strings.
                                var errorMessages = ex.EntityValidationErrors
                                        .SelectMany(x => x.ValidationErrors)
                                        .Select(x => x.ErrorMessage);

                                // Join the list to a single string.
                                var fullErrorMessage = string.Join("; ", errorMessages);

                                // Combine the original exception message with the new one.
                                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                                // Throw a new DbEntityValidationException with the improved exception message.
                                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                            }
                            saveFile();
                        }
                    }
                    else if (Request.Form["state"].Equals("Update"))
                    {
                        HttpPostedFile file = Request.Files["movie"];
                        HttpPostedFile trailer = Request.Files["trailer"];
                        HttpPostedFile poster = Request.Files["poster"];
                        Movie curMovie = model.Movies.Where(mov => mov.ID == curID).Single();
                        if(Request.Form["title"] != null && !Request.Form["title"].Equals(curMovie.Title))
                        {
                            Directory.Move(Server.MapPath("~/Movies/") + curMovie.Path, Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_'));
                        }
                        if (file != null && file.ContentLength != 0)
                        {
                            if(File.Exists(Server.MapPath("~/Movies/")+ Request.Form["title"].Replace(' ' , '_')+"/" + curMovie.Title+".mp4"))
                            {
                                File.Delete(Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_') + "/" + curMovie.Title + ".mp4");
                                file.SaveAs(Server.MapPath(Path.Combine("~/Movies/" + (Request.Form["title"] != null? Request.Form["title"]:curMovie.Title).Replace(' ', '_') + "/", (Request.Form["title"] != null ? Request.Form["title"] : curMovie.Title) + ".mp4")));
                                System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_') + "/Stream");
                                foreach (FileInfo deletedfile in di.GetFiles())
                                {
                                    deletedfile.Delete();
                                }
                                saveFile();
                            }
                        }
                        if(trailer != null && trailer.ContentLength != 0)
                        {
                            if (File.Exists(Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_') + "/" + "trailer.mp4"))
                            {
                                File.Delete(Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_') + "/" + "trailer.mp4");
                                trailer.SaveAs(Server.MapPath(Path.Combine("~/Movies/" + (Request.Form["title"] != null ? Request.Form["title"] : curMovie.Title).Replace(' ', '_') + "/" , "trailer.mp4")));

                            }
                        }
                        if(poster != null && poster.ContentLength != 0)
                        {
                            if (File.Exists(Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_') + "/" + "poster.JPG"))
                            {
                                File.Delete(Server.MapPath("~/Movies/") + Request.Form["title"].Replace(' ', '_') + "/" + "poster.JPG");
                                poster.SaveAs(Server.MapPath(Path.Combine("~/Movies/" + (Request.Form["title"] != null ? Request.Form["title"] : curMovie.Title).Replace(' ', '_') + "/", "poster.JPG")));

                            }
                        }
                        curMovie.Title = Request.Form["title"];
                        curMovie.Description = Request.Form["description"];
                        curMovie.Rating = Int32.Parse(Request.Form["rating"]);
                        curMovie.Date = DateTime.Now;
                        curMovie.Director = Request.Form["director"];
                        curMovie.Budget = Request.Form["comBudget"];
                        curMovie.Country = Request.Form["country"];
                        curMovie.Language = Request.Form["language"];
                        curMovie.Production = Request.Form["production"];
                        if (!String.IsNullOrWhiteSpace(Request.Form["cast"]))
                        {
                            List<Cast> priCast = curMovie.Casts.ToList();
                            List<Cast> neCast = Request.Form["cast"].Split(',').Select(stc => model.Casts.Where(a => a.Name.Equals(stc)).FirstOrDefault()).ToList();
                            curMovie.Casts = priCast.Union(neCast).ToList();
                        }
                        if (!String.IsNullOrWhiteSpace(Request.Form["tag"]))
                        {
                            List<Tag> priTag = curMovie.Tags.ToList();
                            List<Tag> neTag = Request.Form["tag"].Split(',').Select(stc => model.Tags.Where(a => a.Name.Equals(stc)).FirstOrDefault()).ToList();
                            curMovie.Tags = priTag.Union(neTag).ToList();
                        }
                        model.SaveChanges();
                    }
                }
              
              
            }
           
        }

        protected void submit_Click(object sender, EventArgs e)
        {
           
        }

        public void saveFile()
        {
            curTitle = Request.Form["title"].Replace(' ', '_');
            curHost = Request.Url.Host;
            curPort = Request.Url.Port.ToString();
            ProcessStartInfo info = new ProcessStartInfo();
            info.RedirectStandardError = false;
            info.RedirectStandardOutput = false;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.FileName = Server.MapPath("~/ffmpeg/bin/") + "ffmpeg.exe";
            info.Arguments = "-i " + Server.MapPath("~/Movies/" + Request.Form["title"].Replace(' ', '_') + "/" + Request.Form["title"].Replace(' ','_') + ".mp4") + " -hls_list_size 0 " + Server.MapPath("~/Movies/" + Request.Form["title"].Replace(' ', '_')) + "/Stream/Stream.m3u8";
            Process exeProc = new Process();
            exeProc.StartInfo = info;
            exeProc.EnableRaisingEvents = true;
            exeProc.Exited += ExeProc_Exited;
            exeProc.Start();
        }

        private void ExeProc_Exited(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            FileStream fs = File.Open(Server.MapPath("~/Movies/" + curTitle.Replace(' ','_') + "/Stream/Stream.m3u8"), FileMode.Open, FileAccess.ReadWrite);
            using (BufferedStream bs = new BufferedStream(fs))
            {
                using (StreamReader sr = new StreamReader(bs))
                {

                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        if (line.Contains(".ts"))
                        {

                            line = "http://" + curHost + ":" + curPort + "/" + "Movies/" + curTitle.Replace(' ','_') + "/Stream/" + line;
                            Debug.WriteLine(line);
                        }
                        sb.AppendLine(line);
                    }

                }
            }
            using (FileStream fileStream = new FileStream(Server.MapPath("~/Movies/" + curTitle.Replace(' ','_') + "/Stream/Stream.m3u8"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(sb.ToString());
                streamWriter.Close();
                fileStream.Close();
            }
            model.SaveChanges();
        }
    }
}