<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentControl.ascx.cs" Inherits="WebApplication1.UserControllers.CommentControl" %>

<div class="well">
        <h4><i class="fa fa-paper-plane-o"></i> Leave a Comment:</h4>
            <div class="form-group">
                <textarea class="tiny form-control" id="comment" name="comment" rows="3"></textarea>
            </div>
            <button type="submit" name="say" value="" class="btn btn-primary"><i class="fa fa-reply"></i> Submit</button>
     </div>
      <script>
          $('.tiny').summernote();
      </script>