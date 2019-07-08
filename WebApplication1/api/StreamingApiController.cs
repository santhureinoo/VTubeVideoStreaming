using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebApplication1.Model;

namespace WebApplication1.api
{
    public class StreamingApiController : ApiController
    {
        VSModel model = new VSModel();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("adminVideoEdit/id")]
        [ActionName("videoEdit")]
        public void videoEdit(string id)
        {
            Redirect("~/Admin/AdminVideoUpload?id="+id);
        }

        [HttpGet]
        [Route("Admin/GetUserTable")]
        [ActionName("GetUserTable")]
        public DataTableData GetUserTable(DataTableRequest request)
        {
            List<vmUser> allUsers = model.Users.Select(e=>new vmUser() {
                ID = e.ID,
                DisplayName = e.DisplayName,
                Email = e.Email,
                Password = e.Password
            }).ToList<vmUser>();
            List<vmUser> filteredUsers;

            if (request.Search.Value != "")
            {
                Debug.WriteLine(request.Search.Value);
                var searchText = request.Search.Value.Trim();
                filteredUsers = allUsers.Where(cast => cast.DisplayName.Contains(searchText) ||
                 cast.Email.Contains(searchText)).ToList<vmUser>();
            }
            else
            {
                filteredUsers = allUsers;
            }
            if (request.Order.Any())
            {
                int sortColumnIndex = request.Order[0].Column;
                string sortDirection = request.Order[0].Dir;

                Func<vmUser, string> orderingFunctionString = null;
                // Func<vmMovies, int> orderingFunctionInt = null;
                // Func<vmMovies, decimal?> orderingFunctionDecimal = null;

                switch (sortColumnIndex)
                {
                    case 0:
                        {
                            orderingFunctionString = (c => c.DisplayName);
                            filteredUsers =
                                sortDirection == "asc"
                                    ? filteredUsers.OrderBy(orderingFunctionString).ToList()
                                    : filteredUsers.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                    case 1:
                        {
                            orderingFunctionString = (c => c.Email);
                            filteredUsers =
                                sortDirection == "asc"
                                    ? filteredUsers.OrderBy(orderingFunctionString).ToList()
                                    : filteredUsers.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                }
            }
            var pagedProducts = filteredUsers.Skip(request.Start).Take(request.Length);
            DataTableData dtd = new DataTableData()
            {
                draw = request.Draw,
                recordsTotal = allUsers.Count(),
                recordsFiltered = filteredUsers.Count(),
                data = pagedProducts.ToArray<vmUser>(),
                error = ""
            };
            return dtd;
        }

        [HttpGet]
        [Route("Admin/GetCastTable")]
        [ActionName("GetCastTable")]
        public DataTableData GetCastTable(DataTableRequest request)
        {
            List<vmCast> allCasts = model.Casts.Select(e => new vmCast()
            {
                ID = e.ID,
                Name = e.Name,
                Bio = e.Bio,
                Country = e.Country,
                inMovies = e.Movies.Count
            }).ToList<vmCast>();
            List<vmCast> filteredCasts;

            if (request.Search.Value != "")
            {
                Debug.WriteLine(request.Search.Value);
                var searchText = request.Search.Value.Trim();
                filteredCasts = allCasts.Where(cast => cast.Bio.Contains(searchText) ||
                 cast.Country.Contains(searchText) || cast.Name.Contains(searchText)).ToList<vmCast>();
            }
            else
            {
                filteredCasts = allCasts;
            }
            if (request.Order.Any())
            {
                int sortColumnIndex = request.Order[0].Column;
                string sortDirection = request.Order[0].Dir;

                Func<vmCast, string> orderingFunctionString = null;
                // Func<vmMovies, int> orderingFunctionInt = null;
                // Func<vmMovies, decimal?> orderingFunctionDecimal = null;

                switch (sortColumnIndex)
                {
                    case 0:
                        {
                            orderingFunctionString = (c => c.Name);
                            filteredCasts =
                                sortDirection == "asc"
                                    ? filteredCasts.OrderBy(orderingFunctionString).ToList()
                                    : filteredCasts.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                    case 1:
                        {
                            orderingFunctionString = (c => c.Bio);
                            filteredCasts =
                                sortDirection == "asc"
                                    ? filteredCasts.OrderBy(orderingFunctionString).ToList()
                                    : filteredCasts.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                    case 2:
                        {
                            orderingFunctionString = (c => c.Country);
                            filteredCasts =
                                sortDirection == "asc"
                                    ? filteredCasts.OrderBy(orderingFunctionString).ToList()
                                    : filteredCasts.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                }
            }
            var pagedProducts = filteredCasts.Skip(request.Start).Take(request.Length);
            DataTableData dtd = new DataTableData()
            {
                draw = request.Draw,
                recordsTotal = allCasts.Count(),
                recordsFiltered = filteredCasts.Count(),
                data = pagedProducts.ToArray<vmCast>(),
                error = ""
            };
            return dtd;
        }
        [HttpGet]
        [Route("Admin/GetVideoTable")]
        [ActionName("GetVideoTable")]
        public DataTableData GetVideoTable(DataTableRequest request)
        {
            List<vmMovies> allMovies = model.Movies.Select(movie => new vmMovies()
            {
                ID = movie.ID,
                Title = movie.Title,
                Country = movie.Country,
                Date = movie.Date,
                Language = movie.Language,
                Production = movie.Production
            }).ToList<vmMovies>() ;

            List<vmMovies> filteredMovies;

            if (request.Search.Value != "")
            {
                Debug.WriteLine(request.Search.Value);
                var searchText = request.Search.Value.Trim();
               filteredMovies = allMovies.Where(movie => movie.Title.Contains(searchText) || 
                movie.Country.Contains(searchText) || movie.Date.ToLongDateString().Contains(searchText) ||
                movie.Production.Contains(searchText) || movie.Language.Contains(searchText)).ToList<vmMovies>();
            }
            else
            {
                filteredMovies = allMovies;
            }
            if (request.Order.Any())
            {
                int sortColumnIndex = request.Order[0].Column;
                string sortDirection = request.Order[0].Dir;

                Func<vmMovies, string> orderingFunctionString = null;
               // Func<vmMovies, int> orderingFunctionInt = null;
               // Func<vmMovies, decimal?> orderingFunctionDecimal = null;

                switch (sortColumnIndex)
                {
                    case 0:  
                        {
                            orderingFunctionString = (c => c.Title);
                            filteredMovies =
                                sortDirection == "asc"
                                    ? filteredMovies.OrderBy(orderingFunctionString).ToList()
                                    : filteredMovies.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                    case 1: 
                        {
                            orderingFunctionString = (c => c.Country);
                            filteredMovies =
                                sortDirection == "asc"
                                    ? filteredMovies.OrderBy(orderingFunctionString).ToList()
                                    : filteredMovies.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                    case 2:
                        {
                            orderingFunctionString = (c => c.Date.ToLongDateString());
                            filteredMovies =
                                sortDirection == "asc"
                                    ? filteredMovies.OrderBy(orderingFunctionString).ToList()
                                    : filteredMovies.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                    case 3: 
                        {
                            orderingFunctionString = (c => c.Language);
                            filteredMovies =
                                sortDirection == "asc"
                                    ? filteredMovies.OrderBy(orderingFunctionString).ToList()
                                    : filteredMovies.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                }
            }
            var pagedProducts = filteredMovies.Skip(request.Start).Take(request.Length);
            DataTableData dtd = new DataTableData()
            {
                draw = request.Draw,
                recordsTotal = allMovies.Count(),
                recordsFiltered = filteredMovies.Count(),
                data = pagedProducts.ToArray<vmMovies>(),
                error = ""
            };
            return dtd;
            //return Json(model.Movies.Select(e => e.Title).ToList<String>());
        }
        [HttpGet]
        [Route("Admin/GetTagTable")]
        [ActionName("GetTagTable")]
        public DataTableData GetTagTable(DataTableRequest request)
        {
            List<vmTag> allTags = model.Tags.Select(tag => new vmTag()
            {
                ID = tag.ID,
                Name = tag.Name,
                MovieCount = tag.Movies.Count()
            }).ToList<vmTag>();

            List<vmTag> filteredTags;

            if (request.Search.Value != "")
            {
                var searchText = request.Search.Value.Trim();
                filteredTags = allTags.Where(tag => tag.Name.Contains(searchText)).ToList<vmTag>();
            }
            else
            {
                filteredTags = allTags;
            }
            if (request.Order.Any())
            {
                int sortColumnIndex = request.Order[0].Column;
                string sortDirection = request.Order[0].Dir;

                Func<vmTag, string> orderingFunctionString = null;
                Func<vmTag, int> orderingFunctionInt = null;
                // Func<vmMovies, decimal?> orderingFunctionDecimal = null;

                switch (sortColumnIndex)
                {
                    case 0:
                        {
                            orderingFunctionString = (c => c.Name);
                            filteredTags =
                                sortDirection == "asc"
                                    ? filteredTags.OrderBy(orderingFunctionString).ToList()
                                    : filteredTags.OrderByDescending(orderingFunctionString).ToList();
                            break;
                        }
                    case 1:
                        {
                            orderingFunctionInt = (c => c.MovieCount);
                            filteredTags =
                                sortDirection == "asc"
                                    ? filteredTags.OrderBy(orderingFunctionInt).ToList()
                                    : filteredTags.OrderByDescending(orderingFunctionInt).ToList();
                            break;
                        }
                }
            }
            var pagedProducts = filteredTags.Skip(request.Start).Take(request.Length);
            DataTableData dtd = new DataTableData()
            {
                draw = request.Draw,
                recordsTotal = allTags.Count(),
                recordsFiltered = filteredTags.Count(),
                data = pagedProducts.ToArray<vmTag>(),
                error = ""
            };
            return dtd;
            //return Json(model.Movies.Select(e => e.Title).ToList<String>());
        }

        [HttpGet]
        [Route("Admin/Delete/{type}/{id}")]
        [ActionName("VideoDelete")]
        public Boolean VideoDelete(String type, String id)
        {
            int curId;
            if (Int32.TryParse(id, out curId))
            {
                if (type.Equals("Video"))
                {
                    Movie movToDel = model.Movies.Where(e => e.ID == curId).Single();
                    movToDel.Tags.Clear();
                    movToDel.Casts.Clear();
                    movToDel.UserLibraries.Clear();
                    if (Directory.Exists(HttpContext.Current.Server.MapPath("~/Movies/") + movToDel.Title.Replace(' ', '_')))
                        Directory.Delete(HttpContext.Current.Server.MapPath("~/Movies/") + movToDel.Title.Replace(' ', '_'), true);
                    model.Histories.Where(a => a.MovieID == curId).ToList().ForEach(del => model.Histories.Remove(del));
                    model.MoviesReviews.Where(a => a.MovieID == curId).ToList().ForEach(del => model.MoviesReviews.Remove(del));
                    model.Movies.Remove(movToDel);
                    model.SaveChanges();
                }
                else if (type.Equals("Cast"))
                {
                    Cast castToDel = model.Casts.Where(e => e.ID == curId).Single();
                    if (Directory.Exists(HttpContext.Current.Server.MapPath("~/Movies/") + castToDel.Name.Replace(' ', '_')))
                    Directory.Delete(HttpContext.Current.Server.MapPath("~/Movies/") + castToDel.Name.Replace(' ', '_'), true);
                    castToDel.Movies.Clear();
                    model.SaveChanges();
                    model.Casts.Remove(castToDel);
                    model.SaveChanges();
                }
                else if(type.Equals("User"))
                {
                    User usrToDel = model.Users.Where(e => e.ID == curId).Single();
                    model.UserLibraries.Where(lib => lib.UserID == curId).ToList().ForEach(e => model.UserLibraries.Remove(e));
                    model.MoviesReviews.Where(lib => lib.UserID == curId).ToList().ForEach(a => model.MoviesReviews.Remove(a));
                    model.Histories.Where(lib => lib.UserID == curId).ToList().ForEach(a => model.Histories.Remove(a));
                    model.SaveChanges();
                    model.Users.Remove(usrToDel);
                    model.SaveChanges();
                }
                else if (type.Equals("Tag"))
                {
                    Tag tagToDel = model.Tags.Where(e => e.ID == curId).Single();
                    model.Tags.Remove(tagToDel);
                    model.SaveChanges();
                }
            }
            //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            return true;
        }

        [HttpGet]
        [Route("typeAhead/{type}")]
        [ActionName("typeAhead")]
        public IHttpActionResult typeAhead(String type)
        {
            if (type.Equals("Tags"))
                return Json(model.Tags.Select(tag=> new vmTag()
                {
                    ID = tag.ID,
                    Name= tag.Name
                }));
            else if (type.Equals("Casts"))
                return Json(model.Casts.Select(cast=> new {
                    ID = cast.ID,
                    Name = cast.Name
                }).ToList());
            else
                return null;
        }

        [HttpGet]
        [Route("Streaming/{Id}/{path}")]
        [ActionName("GetMovieById")]
        public IHttpActionResult GetMovieById(String Id, String path)
        {
            IHttpActionResult response;
            if(HttpContext.Current.User.Identity.IsAuthenticated) {
                int id = Int32.Parse(HttpContext.Current.User.Identity.Name);
                VSModel model = new VSModel();
                int movieID;
                model.Histories.Add(new History()
                {
                    MovieID = Int32.TryParse(Id, out movieID) ? movieID : 0,
                    UserID = id,
                    Date = DateTime.Now
                });
                model.SaveChanges();
                DateTime prevDate = DateTime.Now.AddDays(-1);
                DateTime now = DateTime.Now;
                model.SaveChanges();
            }
            else
            {
                return null;
            }
            var resMsg = new HttpResponseMessage(HttpStatusCode.OK);
            resMsg.Content = new ByteArrayContent(File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Movies/"+path+"/Stream/Stream.m3u8")));

            Debug.WriteLine(HttpContext.Current.Server.MapPath("~/Movies/" + path + "/Stream/Stream.m3u8"));
            //resMsg.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            //resMsg.Content.Headers.ContentDisposition.FileName = "HarryPotter";
            resMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("video/m3u8");
            response = ResponseMessage(resMsg);
            return response;
           
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        
        public async void WriteContentToStream(Stream outputStream, HttpContent content, TransportContext transportContext)
        {
           
            //path of file which we have to read//  
            var filePath = HttpContext.Current.Server.MapPath("~/[CM] Harry Potter and the Chamber of Secrets (2002) Blu-Ray 1080p Largefile_2.mp4");
            //here set the size of buffer, you can set any size  
            int bufferSize = 10000;
            byte[] buffer = new byte[bufferSize];
            //here we re using FileStream to read file from server//  
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                int totalSize = (int)fileStream.Length;
                /*here we are saying read bytes from file as long as total size of file 

                is greater then 0*/
                while (totalSize > 0)
                {
                    int count = totalSize > bufferSize ? bufferSize : totalSize;
                    //here we are reading the buffer from orginal file  
                    int sizeOfReadedBuffer = fileStream.Read(buffer, 0, count);
                    //here we are writing the readed buffer to output//
                    try
                    {
                        await outputStream.WriteAsync(buffer, 0, sizeOfReadedBuffer);
                    }
                    catch (HttpException exception)
                    {

                    }
                    finally
                    {
                        outputStream.Close();

                    }
                    //and finally after writing to output stream decrementing it to total size of file.  
                    totalSize -= sizeOfReadedBuffer;
                }
            }
        }
    }
    public class DataTableData
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object[] data { get; set; }
        public string error { get; set; }
    }
    public class DataTableColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }

        public DataTableSearch Search { get; set; }
    }

    [ModelBinder(typeof(DataTableModelBinder))]
    public class DataTableRequest
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DataTableOrder[] Order { get; set; }
        public DataTableColumn[] Columns { get; set; }
        public DataTableSearch Search { get; set; }
    }
    public class DataTableOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }
    public class DataTableSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

}