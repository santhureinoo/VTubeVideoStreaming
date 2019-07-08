<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MultiItemCarousel.ascx.cs" Inherits="WebApplication1.UserControllers.MultiItemCarousel" %>
<div class="container-fluid">
    <div class="carouselPrograms carousel slide" id="<%: Title %>" <% if (lstMovies.Count > 3)
        { %>data-ride="carousel" data-interval="false"<%} %>>
        <div class="carousel-inner row w-100 mx-auto" role="listbox">
            <asp:Repeater runat ="server" ID="movieRepeater" >
                <ItemTemplate>
                     <div class="<% if(lstMovies.Count >3) { %>
                         carousel-item<%} %> col-md-4 <%# Container.ItemIndex==1?"active":"" %>">
    		                <div class="card profile-card-5">
    		                    <div class="card-img-block" style="max-width:200px;">
                                    <asp:ImageButton runat="server" CssClass="card-img-top img-fluid" CausesValidation="false" OnCommand="Unnamed_Click" AlternateText='<%# Eval("ID").ToString() %>' ImageUrl='<%# GenerateImage(Eval("Path").ToString()) %>' />
                                </div>
                                <div class="card-body pt-0">
                                <h1 class="card-title"><%# Eval("Title").ToString() %></h1>
                              </div>
                            </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <% if (lstMovies.Count > 3)
            { %>
        <a class="carousel-control-prev" href="#<%: Title %>" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next text-faded" href="#<%: Title %>" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
        <%} %>
    </div>
</div>
<script>
    <% if(lstMovies.Count >3) { %>
    $('#<%: Title %>').on('slide.bs.carousel', function (e) {
        var $e = $(e.relatedTarget);
        var idx = $e.index();
        var itemsPerSlide = <%: lstMovies.Count > 3 ? 3 : 2%>;
        var totalItems = $('#<%: Title %> .carousel-item').length;
        if (idx >= totalItems - (itemsPerSlide - 1)) {
            var it = itemsPerSlide - (totalItems - idx);
            for (var i = 0; i < it; i++) {
                // append slides to end
                if (e.direction == "left") {
                    $('#<%: Title %> .carousel-item').eq(i).appendTo('#<%: Title %> .carousel-inner');
                }
                else {
                    $('#<%: Title %> .carousel-item').eq(0).appendTo('#<%: Title %> .carousel-inner');
                }
            }
        }
    });
    <%}%>
</script>
