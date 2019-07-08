<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoviesCounter.ascx.cs" Inherits="WebApplication1.UserControllers.MoviesCounter" %>
<%@ Register Src="~/UserControllers/MovieFilterControl.ascx" TagPrefix="FC" TagName="MovieFilterControl" %>

<section id="team" class="pb-5">
    <div class="container">
        <div class="row">
            <div class="col-md-5"><h5 class="section-title h1">All Movies</h5></div>
            <FC:MovieFilterControl runat="server" id="filterCon"></FC:MovieFilterControl>
        </div>

        <div class="row mt-5">
            <style>
                .width {
                    max-height:200px;
                    min-height:200px;
                }
            </style>
            <asp:Repeater ID="repeater" runat="server">
                <ItemTemplate>
                     <div class="col-lg-2 col-6">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <asp:Image CssClass="img-fluid width" ImageUrl='<%# GenerateImage(Eval("Path").ToString()) %>' runat="server" />
                                </div>
                                <div class="backside">
                                    <div class="card">
                                        <div class="card-body text-center mt-4">
                                            <asp:Button  OnClick="btnDownload_Click" CommandArgument='<%# Eval("ID").ToString() %>' Text="Download" CssClass="btn btn-primary w-100" runat="server"></asp:Button>
                                            <asp:Button CommandArgument='<%# Eval("ID").ToString() %>' OnClick="btnDetails_Click" Text="Details" CssClass="btn btn-primary w-100" runat="server"></asp:Button>
                                            <!--<input type="button" value="Download" class="btn btn-primary w-100" />
                                            <input type="button" value="Details" class="btn btn-primary w-100"/>-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                         <b><%# Eval("Title") %></b>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            
        </div>
        <% if (IsMore)
            {%><div class="float-right"><a href="#">More...</a></div><br>
        <%} %>
    </div>
</section>
<!-- Team -->