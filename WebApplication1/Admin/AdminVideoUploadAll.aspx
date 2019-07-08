<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminVideoUploadAll.aspx.cs" Inherits="WebApplication1.Admin.AdminVideoUploadAll" %>

<asp:Content ID="body" ContentPlaceHolderID="Body" runat="server">
    <div style="margin:30px;">
    <table id="videoDT" class="display" cellspacing="0" width="100%">
        <thead>
            <tr style="text-align:left;">
                <th>Title</th>
                <th>Country</th>
                <th>Date</th>
                <th>Language</th>
                <th>Update</th>
                <th>Delete</th>
            </tr>
        </thead>

        <tfoot>
            <tr style="text-align:left;">
                <th>Title</th>
                <th>Country</th>
                <th>Date</th>
                <th>Language</th>
                <th>Update</th>
                <th>Delete</th>
            </tr>
        </tfoot>
    </table>
</div>
    <script>
        function newVideo() {
            window.location.href="AdminVideoUpload.aspx";
        }
        function vdoDelete(id) {
            $.ajax({      
                url: "Delete/Video/" + id,
                success: function (result) {
                    setTimeout(location.reload(), 3000);
                    console.log('suc');
                    if (result) {
                       // setTimeout(location.reload(), 3000);
                        }   
                }
            })
        }
        $(document).ready(function () {
            $('#videoDT').dataTable({
                dom: 'l<"toolbar">frtip',
                initComplete: function () {
                    $("div.toolbar").html('<button class="btn btn-info" type="button" id="NewBtn" onclick="newVideo()">New Video +</button>');
                },     
                processing: true,
                serverSide: true,
                ordering: true,
                paging: true,
                searching: true,
                ajax: "GetVideoTable",
                columns: [
                    { "data": "Title" },
                    { "data": "Country" },
                    { "data": "Date" },
                    { "data": "Language" },
                    {
                        "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="AdminVideoUpload.aspx?ID=' + full.ID + '">Edit</a>'; }
                    },
                    {
                        "render": function (data, type, full, meta) { return "<button class='btn btn-danger' onclick='vdoDelete(" + full.ID+")' >Delete</Button>"; }
                    },
                ]
            });

        });
        
    </script>
</asp:Content>