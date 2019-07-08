<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminTagUpload.aspx.cs" Inherits="WebApplication1.Admin.AdminTagUpload" %>

<asp:Content ID="body" ContentPlaceHolderID="Body" runat="server">
       <div class="form-group row">
            <label for="title" class="col-sm-2 col-form-label">Title:</label>
            <%--<div class="col-sm-10">--%>
              <input type="text" name="name" value="<% if (curTag != null) Response.Write(curTag.Name); %>" class="form-control" id="name" required>
            
       </div>
            <div class="form-group row">
              <input type="text" name="state" id="state" style="display:none;" value="Insert"/>
              <input type="button" class="btn btn-primary" value="<%: curTag != null? "Update":"Insert" %>" onclick="setState(this)" />
              <% if (curTag != null)
                  { %>
             <!-- <input type='button' class='btn btn-primary ml-3' value='Delete' onclick="setState(this)-->
              <% } %>
          </div>
         <script>
             var curTags = [
                 <%
             foreach(var tag in model.Tags.ToList())
             {

             %>
                  '<% if (curTag != null) {
                 Response.Write(!tag.Name.Equals(curTag.Name) ? tag.Name : "null");
             }  %>',
                 <%}%>
             ]
             function setState(state) {
                 $('.errMsg').remove();
                 $("#state").val($(state).val());
                 if ($('#name').val() == '') {
                     $('#name').after('<sub class="errMsg" style="color:red;">Tag Can not be Null</sub>');
                     return;
                 }
                 if (curTags.includes($('#name').val())) {
                     $('#name').after('<sub class="errMsg" style="color:red;">Same Tags Already Exists</sub>');
                     return;
                 }
                 $("#form1").submit();
             }
         </script>
</asp:Content>