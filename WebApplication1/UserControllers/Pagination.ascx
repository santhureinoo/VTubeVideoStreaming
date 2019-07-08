<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagination.ascx.cs" Inherits="WebApplication1.UserControllers.Pagination" %>
    <ul class="pagination justify-content-center" style="margin:20px 0">
        <li class="page-item"><input type="submit" class="page-link active" name="ind" value="First"></li>
        <% for(int i = 1; i <= NumsOfPagination; i++)
            { %>
                  <% if ( Request.Form["ind"] != null)
                    {%> <li class="page-item <%: i == (Request.Form["ind"].Equals("First") ? 1 : NumsOfPagination)? "":"" %>"><input type="submit" name="ind" class="page-link" value="<%:i %>"></li>
                <% } %>
                <% else if (Request.Form["ind"] != null && i == Int32.Parse(Request.Form["ind"]))
                    {%> <li class="page-item"><input type="submit" name="ind" class="page-link" value="<%:i %>"></li>
                <% }
                else
                { %> <li class="page-item <%: i==1?"":"" %>"><input type="submit" name="ind" class="page-link" value="<%:i %>"></li>
                    <% }
                } %>
        
        <li class="page-item"><input type="submit" class="page-link active" name="ind" value="Last"></li>
    </ul>