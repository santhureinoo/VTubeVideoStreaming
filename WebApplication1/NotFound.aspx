<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NotFound.aspx.cs" Inherits="WebApplication1.NotFound" %>
<%@ Register Src="~/UserControllers/MultiItemCarousel.ascx" TagPrefix="MIC" TagName="MultiItemCarousel" %> 
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div style="min-height: 100vh;" class="page-wrap d-flex flex-row align-items-center">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <span class="display-1 d-block">404</span>
                <div class="mb-4 lead">Sorry, No Movies Found</div>
                <a href="Default.aspx" class="btn btn-link">Back to Home</a>
            </div>
        </div>
         <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <h1> Possible Results:</h1>
                 <MIC:MultiItemCarousel Title="NotFound" ID="multiCarousel" runat="server"></MIC:MultiItemCarousel>
			    
            </div>
        </div>

    </div>
</div>
    </asp:Content>


