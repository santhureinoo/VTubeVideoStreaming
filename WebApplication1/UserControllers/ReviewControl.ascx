<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewControl.ascx.cs" Inherits="WebApplication1.UserControllers.ReviewControl" %>
<%@ Register Src="~/UserControllers/CommentControl.ascx" TagName="ComControl" TagPrefix="CC" %>
<div class="container">
    <CC:ComControl ID="com" runat="server" />
    <script>
        
            function deleteComment(str) {
            $("#deleteCom").val(str);
            $("#form1").submit();

            }
    </script>
    <input type="hidden" id="deleteCom" name="deleteCom" />

     <asp:Repeater ID="reReview" runat="server">
          <ItemTemplate>
          <div class="card mt-3">
	    <div class="card-body">
	        <div class="row">
        	    <div class="col-md-2">
        	        <img src="https://image.ibb.co/jw55Ex/def_face.jpg" class="img img-rounded img-fluid"/>
        	        <p class="text-secondary text-center"><%# getNameByID(Eval("UserID").ToString()) %></p>
        	    </div>
        	    <div class="col-md-10">
                    <p class="float-right"><%# Eval("Date") %></p>
        	       <div class="clearfix"></div>
                    <p>
                        <%# Eval("Comment") %>
                    </p>
        	        <p>
        	           <!--  <button runat="server" class="float-right btn btn-outline-primary ml-2" onserverclick="Unnamed_Click"><i class='fa fa-reply'></i> Reply</button>   
        	          --><%# isUserSame(Eval("UserID").ToString())?"<button type='button' onclick='deleteComment("+ Eval("ID")+")' class='float-right btn text-white btn-danger'> <i class='fa fa-heart'></i> Delete</button>":"" %> 
                        
        	       </p>
        	    </div>
	        </div>
	        	
	    </div>
	</div>
   </ItemTemplate>
	  </asp:Repeater>
</div>
