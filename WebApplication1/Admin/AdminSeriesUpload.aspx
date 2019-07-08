<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminSeriesUpload.aspx.cs" Inherits="WebApplication1.Admin.AdminSeriesUpload" %>
<asp:Content ID="body" ContentPlaceHolderID="Body" runat="server">
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">
            <div class="form-group row">
                <label for="title" class="col-sm-2 col-form-label">Title:</label>
                <div class="col-sm-10">
                  <input type="text" name="title" class="form-control" id="title">
                </div>
          </div>
         <div class="form-group row">
                <label for="description" class="col-sm-2 col-form-label">Description:</label>
                <div class="col-sm-10">
                  <input type="text" name="description" class="form-control" id="description">
                </div>
          </div>
        <div class="form-group row">
                <label for="rating" class="col-sm-2 col-form-label">Rating:</label>
                <div class="col-sm-10">
                  <input type="rating" name="description" class="form-control" id="rating">
                </div>
          </div>
        </form>
    </asp:Content>