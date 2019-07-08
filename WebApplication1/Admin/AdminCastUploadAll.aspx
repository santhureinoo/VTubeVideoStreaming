<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminCastUploadAll.aspx.cs" Inherits="WebApplication1.Admin.AdminCastUploadAll" %>

<asp:Content ID="body" ContentPlaceHolderID="Body" runat="server">
     <div style="margin:30px;">
    <table id="castDT" class="display" cellspacing="0" width="100%">
        <thead>
            <tr style="text-align:left;">
                <th>Name</th>
                <th>Bio</th>
                <th>Country</th>
                <th>Staired Movies</th>
                <th>Update</th>
                <th>Delete</th>
            </tr>
        </thead>

        <tfoot>
            <tr style="text-align:left;">
                <th>Name</th>
                <th>Bio</th>
                <th>Country</th>
                <th>Staired Movies</th>
                <th>Update</th>
                <th>Delete</th>
            </tr>
        </tfoot>
    </table>
         <script>
             function newCast() {
                 window.location.href = "AdminCastUpload.aspx";
             }
             function cstDelete(id) {
                 $.ajax({
                     url: "Delete/Cast/" + id,
                     success: function (result) {
                         if (result) {
                             location.reload();
                         }
                     }
                 })
             }
             $(document).ready(function () {
                 $('#castDT').dataTable({
                     dom: 'l<"toolbar">frtip',
                     initComplete: function () {
                         $("div.toolbar").html('<button class="btn btn-info" type="button" id="NewBtn" onclick="newCast()">New Cast +</button>');
                     },     
                     processing: true,
                     serverSide: true,
                     ordering: true,
                     paging: true,
                     searching: true,
                     ajax: "GetCastTable",
                     columns: [
                         { "data": "Name" },
                         { "data": "Bio" },
                         { "data": "Country" },
                         { "data": "inMovies"},
                         {
                             "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="AdminCastUpload.aspx?ID=' + full.ID + '">Edit</a>'; }
                         },
                         {
                             "render": function (data, type, full, meta) {
                                 var dis = full.inMovies > 0 ? "disabled" : "";
                                 return "<button class='btn btn-danger' onclick='cstDelete(" + full.ID + ")' " + dis +" >Delete</Button>";
                             }
                         },
                     ]
                 });
             });

         </script>
</asp:Content>