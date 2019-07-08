<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MoviesCounter.aspx.cs" Inherits="WebApplication1.MoviesCounter" %>
<%@ Register Src="~/UserControllers/MoviesCounter.ascx" TagPrefix="MC" TagName="MovieCounter" %>
<%@ Register Src="~/UserControllers/Pagination.ascx" TagPrefix="pg" TagName="Pagination" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <div class="container">
         <MC:MovieCounter runat="server" id="movieCounter" ></MC:MovieCounter>
        <pg:Pagination id="pagination" runat="server"></pg:Pagination>
         </div>
         
</asp:Content>
        