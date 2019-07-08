<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<%@ Register Src="~/UserControllers/CarouseItem.ascx" TagPrefix="CI" TagName="CarouselItem" %> 
<%@ Register Src="~/UserControllers/MultiItemCarousel.ascx" TagPrefix="MI" TagName="MultiItem" %> 

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="probootstrap-cover">
      <div class="container">
        <div class="row probootstrap-vh-100 align-items-center text-center">
          <div class="col-sm">
            <div class="probootstrap-text">
              <h1 class="probootstrap-heading text-white mb-4">vTube For EveryOne</h1>
              <div class="probootstrap-subheading mb-5">
                <p class="h4 font-weight-normal"></p>
                  
              </div>
              <div class=" mb-3 probootstrap-subheading">
                      <input type="text" style="height:50px;" name="search" id="search" class="from-control w-50" placeholder="Search Movie Here" aria-label="Recipient's username" aria-describedby="basic-addon2">
                      <button class="btn btn-light btn-lg mb-2" type="submit"><i class="fas fa-search"></i></button>   
                </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <div class="m-3">
        <h1> Trending Movies</h1> 
           <MI:MultiItem runat="server" Title="trending" id="trendingMoviesCounter" />
    </div>

  <div class="m-3">
        <h1> Recommended For You</h1>
           <MI:MultiItem runat="server" Title="recommend" id="recommendMoviesCounter" />
       
    </div>
</asp:Content>
