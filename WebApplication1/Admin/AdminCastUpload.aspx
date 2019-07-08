<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminCastUpload.aspx.cs" Inherits="WebApplication1.Admin.AdminCastUpload" %>

<asp:Content ID="body" ContentPlaceHolderID="Body" runat="server">
               <div class="form-group row">
                    <label for="name" class="col-sm-2 col-form-label">Name:</label>
                    <div class="col-sm-10">
                      <input type="text" name="name" value="<%: curCast != null ? curCast.Name: "" %>" class="form-control" id="name">
                    </div>
              </div>
              <div class="form-group row">
                    <label for="biography" class="col-sm-2 col-form-label">Biography:</label>
                    <div class="col-sm-10">
                       <textarea class="form-control" name="biography" rows="5" id="biography"><%: curCast != null ? curCast.Bio: "" %></textarea>
                    </div>
              </div>
            <div class="form-group row">
                    <label for="file" class="col-sm-2 col-form-label">Photo:</label>
                    <div class="col-sm-10">
                      <input type="file" name="photo" class="form-control" id="photo">
                    </div>
              </div>
            <div class="form-group row">
                    <label for="coutry" class="col-sm-2 col-form-label">Country:</label>
                    <div class="col-sm-10">
                       
                        <select  name="country" class="form-control" id="country">

                        </select>
                    </div>
              </div>
              <div class="form-group row">
              <input type="text" name="state" id="state" style="display:none;" value="Insert"/>
              <input type="button" class="btn btn-primary" value="<%: curCast != null ? "Update":"Insert" %>" onclick="setState(this)" />
          </div>
      <script>
          function setState(state) {
              $("#state").val($(state).val());
              $("#form1").submit();
          }
          let dropdown = $('#country');

          dropdown.empty();

          dropdown.append('<option selected="true" disabled>Choose Country</option>');
          dropdown.prop('selectedIndex', 0);

          const url = 'https://restcountries.eu/rest/v2/all';
          $.getJSON(url, function (data) {
              $.each(data, function (key, entry) {
                  dropdown.append($('<option></option>').attr('value', entry.abbreviation).text(entry.name));
              })
               <% if (curCast != null)
               { %>      
                      $("#country").val('<%: curCast.Country %>');
                <%} %>
          });
          
    </script>
</asp:Content>