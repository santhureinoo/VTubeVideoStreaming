<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MovieDetail.aspx.cs" Inherits="WebApplication1.Main" %>
<%@ Register Src="~/UserControllers/MultiItemCarousel.ascx" TagPrefix="MIC" TagName="MultiItemCarousel" %> 
<%@ Register Src="~/UserControllers/ReviewControl.ascx" TagName="ReviewControl" TagPrefix="RC" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.plyr.io/1.8.2/plyr.css">
        <video preload="none" id="player" autoplay controls crossorigin></video>
                <script src="Scripts/plyr.js"></script>
                <script src="Scripts/hls.js"></script>
    <script>
        var video = document.querySelector('#player');
        if (Hls.isSupported()) {
            var hls = new Hls();
            hls.loadSource('Streaming/<%: curMovie.ID%>/<%: curMovie.Path%>');//'Streaming/1');
            hls.attachMedia(video);
            hls.on(Hls.Events.MANIFEST_PARSED, function () {
                video.play();
            });
        }
        plyr.setup(video);
    </script>
    <div class="row mt-3">
        <div class="col-md-9">
				        <nav>
					        <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
						        <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#Description" role="tab" aria-controls="nav-home" aria-selected="true">Description</a>
						         <a class="nav-item nav-link" id="nav-Trailer" data-toggle="tab" href="#Trailer" role="tab" aria-controls="nav-about" aria-selected="false">Trailer</a>
                                <a class="nav-item nav-link" id="nav-Cast" data-toggle="tab" href="#Cast" role="tab" aria-controls="nav-about" aria-selected="false">Cast</a>
					        </div>
				        </nav>
				        <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
					        <div class="tab-pane fade show active" id="Description" role="tabpanel" aria-labelledby="nav-home-tab">
                                 <%= curMovie.Description%>
					        </div>
                            <div class="tab-pane fade show" id="Trailer" role="tabpanel" aria-labelledby="nav-about-tab">
                                <video id="trailer" playsinline controls style="width:100%;">
                                    <source src="<%: "http://" + Request.Url.Host + ":" + Request.Url.Port + "/" + "Movies/" + curMovie.Title.Replace(' ', '_') + "/trailer.mp4" %>" type="video/mp4" />
                                </video>
					        </div>
					        <div class="tab-pane fade" id="Cast" role="tabpanel" aria-labelledby="nav-about-tab">
                                <div class="container w-100">
                                     <ul class="row">
                                         <asp:Repeater ID="castRepeater" runat="server">
                                             <ItemTemplate>
                                                  <li class="col-12 col-md-6 col-lg-3">
                                                        <div class="cnt-block equal-hight" style="height: 349px;">
                                                            <figure><img src="<%# "http://" + Request.Url.Host + ":" + Request.Url.Port + "/" + "Casts/" + Eval("Name").ToString().Replace(' ', '_') + ".JPG" %>" class="img-fluid" alt=""></figure>
                                                            <h3><%# Eval("Name") %></h3>
                                                            <p></p>
                                                        </div>
                                                    </li>
                                             </ItemTemplate>
                                         </asp:Repeater>
                                    </ul>
                                </div>
						        
					        </div>
				        </div>
			     <MIC:MultiItemCarousel Title="Detail" ID="multiCarousel" runat="server"></MIC:MultiItemCarousel>
			        </div>
           
        <div class="col-md-3">
            <div class="p-2 m-3">
                <asp:Button Cssclass="btn btn-primary" runat="server" ID="download" OnClick="Unnamed_Click" Text="Download"></asp:Button>
                <div class="dropdown float-right">
                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Report Problems
                  </button>
                  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <asp:Button runat="server" Cssclass="dropdown-item" Text="Video is not Playing" ID="vinp" OnClick="vinp_Click"></asp:Button>
                   <!-- <a class="dropdown-item" href="#">Download Error</a>
                    <a class="dropdown-item" href="#">Information is Incomplete</a>
                     <a class="dropdown-item" href="#">Something else</a>-->
                  </div>
                </div>
            </div>
            <div class="border border-warning p-3">
                <h3>Details</h3>
                <ul>
                    <li>Released date: <%: curMovie.Date.ToShortDateString() %></li>
                    <li>Director: <%: curMovie.Director %> </li>
                    <li>Budget: <%: curMovie.Budget %></li>
                    <li>Country: <%:curMovie.Country %></li>
                    <li>Language: <%: curMovie.Language %></li>
                    <li>Production Co: <%: curMovie.Production %></li>
                </ul>
            </div>
    </div>
    </div>
    <hr />
    <RC:ReviewControl ID="reviewsControl" runat="server"></RC:ReviewControl>
</asp:Content>

