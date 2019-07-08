<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MovieFilterControl.ascx.cs" Inherits="WebApplication1.UserControllers.FilterControl" %>
<div class="input-group">
  <input type="text" class="form-control" placeholder="Enter Movie Name" id="genSearch" name="genSearch">
  <div class="input-group-append">
     <div class="input-group-append">
        <button class="btn btn-primary" data-toggle="modal" data-target="#advancedSearch" type="button">Advanced</button> 
        <button class="btn btn-danger" type="submit">Search</button>  
<!-- Modal -->
<div class="modal fade" id="advancedSearch" tabindex="-1" role="dialog" 
     aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header">
                <button type="button" class="close" 
                   data-dismiss="modal">
                       <span aria-hidden="true">&times;</span>
                       <span class="sr-only">Close</span>
                </button>
                <h4 class="modal-title" id="myModalLabel">
                   Advanced Search
                </h4>
            </div>
            
            <!-- Modal Body -->
            <div class="modal-body">
                
                <form role="form">
                  <div class="form-group">
                    <label for="tagsTAG">Title</label>
                      <input type="text" class="form-control w-100"
                      id="title" name="title" placeholder="Enter Movie's Title"/>
                  </div>
                  <!--<div class="form-group">
                    <label for="tagsTAG">Cast</label>
                      <input type="text" class="form-control w-100"
                      id="castsTAG" name="castsTAG" placeholder="Enter Casts"/>
                  </div>-->
                   <div class="form-group">
                    <label for="tagsTAG">Tags</label>
                      <input type="text" class="form-control w-100"
                      id="tagsTAG" name="tagsTAG" placeholder="Enter Tags"/>
                  </div>
                  <div class="form-group">
                    <label for="year">Year</label>
                      <select name="year" class="form-control w-100" id="year">
                          <option value="0">Select Year</option>
                          <% for (int i = DateTime.Now.Year; i > 1878; i--)
                              { %>
                                    <option value="<%:i %>"><%: i %></option>
                          <%} %>
                      </select>
                  </div>
                </form>
            </div>
            
            <!-- Modal Footer -->
            <div class="modal-footer">
                <button type="button" class="btn btn-default"
                        data-dismiss="modal">
                            Close
                </button>
                <button type="submit" class="btn btn-primary">
                    Search
                </button>
            </div>
        </div>
    </div>
</div>




      </div>
  </div>
</div>
<script>
    var tags = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: {
            url: 'typeAhead/Tags',
            filter: function (list) {
                return $.map(list, function (item) {
                    return {
                       Name:item.Name
                    };
                });
            }
        }
    });
    tags.clearPrefetchCache();
    tags.initialize();
    $("#tagsTAG").tagsinput({
        typeaheadjs: [{
            minLength: 1,
            highlight: true
        }, {
            minlength: 1,
            name: 'Name',
            displayKey: 'Name',
            valueKey: 'Name',
            source: tags.ttAdapter()
        }],
        freeInput: false,
    });
    $("#tagsTAG").addClass("form-control w-100");
    var casts = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: {
            url: 'typeAhead/Casts',
            filter: function (list) {
                return $.map(list, function (item) {
                    return {
                        Name: item.Name
                    };
                });
            }
        }
    });
    casts.clearPrefetchCache();
    casts.initialize();
    $("#castsTag").tagsinput({
        typeaheadjs: [{
            minLength: 1,
            highlight: true
        }, {
            minlength: 1,
            name: 'Name',
            displayKey: 'Name',
            valueKey: 'Name',
            source: casts.ttAdapter()
        }],
        freeInput: false
    });
    $("#castsTAG").addClass("form-control w-100");
    $(".bootstrap-tagsinput").addClass("w-100");
</script>