<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminTagUploadAll.aspx.cs" Inherits="WebApplication1.Admin.AdminTagUploadAll" %>


<asp:Content ID="body" ContentPlaceHolderID="Body" runat="server">
    <div style="margin:30px;">
    <table id="tagDT" class="display" cellspacing="0" width="100%">
        <thead>
            <tr style="text-align:left;">
                <th>Name</th>
                <th>Movies</th>
                <th>Update</th>
                <th>Delete</th>
            </tr>
        </thead>

        <tfoot>
            <tr style="text-align:left;">
                <th>Name</th>
                <th>Movies</th>
                <th>Update</th>
                <th>Delete</th>
            </tr>
        </tfoot>
        <script>
             function newTag() {
                 window.location.href = "AdminTagUpload.aspx";
            }
            function tagDelete(id) {
                $.ajax({
                    url: "Delete/Tag/" + id,
                    success: function (result) {
                        if (result) {
                            location.reload();
                        }
                    }
                })
            }
             $(document).ready(function () {
                 $('#tagDT').dataTable({
                     processing: true,
                     serverSide: true,
                     ordering: true,
                     paging: true,
                     searching: true,
                     ajax: "GetTagTable",
                     dom: 'l<"toolbar">frtip',
                     initComplete: function () {
                         $("div.toolbar").html('<button class="btn btn-info" type="button" id="NewBtn" onclick="newTag()">New Tag +</button>');
                     },

                     columns: [
                         { "data": "Name" },
                         { "data": "MovieCount" },
                         {
                             "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="AdminTagUpload.aspx?ID=' + full.ID + '">Edit</a>'; }
                         },
                         {
                             "render": function (data, type, full, meta) {
                                 var dis = full.MovieCount > 0 ? "disabled" : "";
                                 return "<button class='btn btn-danger' onclick='tagDelete(" + full.ID + ")' " + dis + " >Delete</Button>";
                             }
                         },
                     ]
                 });
             });

                  </script>
</asp:Content>