<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SeriesCounter.aspx.cs" Inherits="WebApplication1.SeriesDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Repeater runat="server" ID="series" >
                    <ItemTemplate>
                        <div class="card col-md-12 p-3">
    		                <div class="row ">
    			                <div class="col-md-4">
    				                <asp:Image ImageUrl='<%# Eval("Poster").ToString() %>'
    			                </div>
    			                <div class="col-md-8">
    				                <div class="card-block">
    					                <h6 class="card-title"><%# Eval("Title") %></h6>
    					                <p class="card-text text-justify"><%# Eval("Description") %></p>
    					                <a href="https://www.google.com" class="btn btn-primary">read more...</a>
    				                </div>
    			                </div>
    		                </div>
    	                </div>
                    </ItemTemplate>
            </asp:Repeater>
         </div>
    </div>
</asp:Content>
       