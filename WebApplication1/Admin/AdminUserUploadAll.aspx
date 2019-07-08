<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminCastUploadAll.aspx.cs" Inherits="WebApplication1.Admin.AdminCastUploadAll" %>

<asp:Content ID="body" ContentPlaceHolderID="Body" runat="server">
     <div style="margin:30px;">
    <table id="userDT" class="display" cellspacing="0" width="100%">
        <thead>
            <tr style="text-align:left;">
                <th>Email</th>
                <th>Name</th>
                <th>Password</th>
                <th>Delete</th>
            </tr>
        </thead>

        <tfoot>
            <tr style="text-align:left;">
                <th>Email</th>
                <th>Name</th>
                <th>Password</th>
                <th>Delete</th>
            </tr>
        </tfoot>
        <script>
             function newCast() {
                 window.location.href = "AdminCastUpload.aspx";
            }
            function usrDelete(id) {
                $.ajax({
                    url: "Delete/User/" + id,
                    success: function (result) {
                        if (result) {
                            location.reload();
                        }
                    }
                })
            }
             $(document).ready(function () {
                 $('#userDT').dataTable({
                     processing: true,
                     serverSide: true,
                     ordering: true,
                     paging: true,
                     searching: true,
                     ajax: "GetUserTable",
                     columns: [
                         { "data": "Email" },
                         { "data": "DisplayName" },
                         { "data": "Password" },
                         {
                             "render": function (data, type, full, meta) { return "<button class='btn btn-danger' onclick='usrDelete(" + full.ID + ")' >Delete</Button>"; }
                         },
                     ]
                 });
             });

                  </script>
</asp:Content>