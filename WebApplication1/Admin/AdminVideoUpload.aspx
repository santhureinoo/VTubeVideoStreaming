<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminVideoUpload.aspx.cs" Inherits="WebApplication1.AdminVideoUpload" %>

<asp:Content ID="body" ContentPlaceHolderID="Body" runat="server">
        <div class="form-group row">
            <label for="title" class="col-sm-2 col-form-label">Title:</label>
            <div class="col-sm-10">
              <input type="text" name="title" value="<%: curMovie != null? curMovie.Title:"" %>" class="form-control" id="title" required>
            </div>
      </div>
      <div class="form-group row">
        <label for="rating" class="col-sm-2 col-form-label">Rating:</label>
        <div class="col-sm-10">
      <!--      <input type="text" name="rating" value="<%: curMovie !=null ? curMovie.Rating.ToString():null %>" class="form-control" required id="rating">
        -->
             <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
            <input type="radio" id="star5" name="rating" value="5" /><label for="star5" title="5 star">5</label>
            <input type="radio" id="star4" name="rating" value="4" /><label for="star4" title="4 star">4</label>
            <input type="radio" id="star3" name="rating" value="3" /><label for="star3" title="3 star">3</label>
            <input type="radio" id="star2" name="rating" value="2" /><label for="star2" title="2 star">2</label>
            <input type="radio" id="star1" checked name="rating" value="1" /><label for="star1" title="1 star">1</label>
        </div>
            <script>
                <% if(curMovie != null) { %>
                for (var i = 1; i <= <%: curMovie.Rating %>; i++) {
                    $("#star" + i).prop("checked", true);
                }
                <%} %>
            </script>
            <style>
                @import url(//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css);
                .starrating > input {display: none;}  /* Remove radio buttons */

                .starrating > label:before {
                        content: "\f005"; /* Star */
                        margin: 2px;
                        font-size: 8em;
                        font-family: FontAwesome;
                        display: inline-block;
                    }

                .starrating > label
                {
                        color: #222222; /* Start color when not clicked */
                }

                .starrating > input:checked ~ label
                { color: #ffca08 ; } /* Set yellow color when star checked */

                .starrating > input:hover ~ label
                { color: #ffca08 ;  } /* Set yellow color when star hover */


            </style>
        </div>
      </div>
        <div class="form-group row">
        <label for="rating" class="col-sm-2 col-form-label">Casts:</label>
        <div class="col-sm-10">
            <input type="text" name="cast" value="" class="form-control" id="cast">
        </div>
      </div>
      <div class="form-group row">
        <label for="tag" class="col-sm-2 col-form-label">Tags:</label>
        <div class="col-sm-10">
            <input type="text" name="tag" value="" class="form-control" id="tag">
        </div>
      </div>
      <div class="form-group row">
            <label for="description" class="col-sm-2 col-form-label">Description:</label>
            <div class="col-sm-10">
                <textarea class="form-control" name="description" rows="5" id="description"><% if (curMovie != null) Response.Write(curMovie.Description); %></textarea>
            </div>
          <script>
              $('#description').summernote();
      </script>
      </div>
     <div class="form-group row">
            <label for="trailer" class="col-sm-2 col-form-label">Trailer:</label>
            <div class="col-sm-10">
                <input type="file" class="form-control-file" name="trailer" id="trailer">
            </div>
      </div>
       <div class="form-group row">
            <label for="poster" class="col-sm-2 col-form-label">Poster:</label>
            <div class="col-sm-10">
              <input type="file" name="poster" class="form-control-file" id="poster">
            </div>
      </div>
      <div class="form-group row">
        <label for="movie" class="col-sm-2 col-form-label">Movie Location:</label>
        <div class="col-sm-10">
          <input type="file" name="movie" class="form-control-file" id="movie">
        </div>
      </div>
      <div class="form-group row">
            <label for="director" class="col-sm-2 col-form-label">Released Date:</label>
            <div class="col-sm-10">
              <input type="date" name="date" id="date" class="form-control" value="<% if (curMovie != null) Response.Write(curMovie.Date.ToString("yyyy-MM-dd")); %>">
            </div>
      </div>
       <div class="form-group row">
            <label for="director" class="col-sm-2 col-form-label">Director:</label>
            <div class="col-sm-10">
              <input type="text" name="director" class="form-control" value="<% if(curMovie != null) Response.Write(curMovie.Director); %>" id="director">
            </div>
      </div>
      <div class="form-group row">
            <script>
                function changeCurrency(data) {
                    $('#currency').html($(data).html());
                   
                }
            </script>
            <label for="budget" class="col-sm-2 col-form-label">Budget:</label>
            <div class="col-sm-10">
                  <div class="input-group">
                  <input type="hidden" name="comBudget" id="comBudget" />
                  <input type="text" name="budget" class="form-control" id="budget" value="<%if (curMovie != null) Response.Write(curMovie.Budget.Split(' ')[0].ToString()); %>" aria-label="Text input with dropdown button">
                  <div class="input-group-append">
                    <button id="currency" class="btn btn-outline-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><%if (curMovie != null) Response.Write(curMovie.Budget.Split(' ')[1].ToString()); else Response.Write("$"); %></button>
                    <div class="dropdown-menu">
                      <button type="button" class="dropdown-item" onclick="changeCurrency(this)">$</button>
                      <button  type="button" class="dropdown-item" onclick="changeCurrency(this)">Pound</button>
                      <button  type="button" class="dropdown-item" onclick="changeCurrency(this)">Kyats</button>
                     <!-- <div role="separator" class="dropdown-divider"></div>
                      <a class="dropdown-item" href="#">Separated link</a>-->
                    </div>
                  </div>
                </div>
            </div>
         
      </div>
      <div class="form-group row">
            <label for="country" class="col-sm-2 col-form-label">Country:</label>
            <div class="col-sm-10">
              <input type="text" name="country" class="form-control" value="<% if (curMovie != null) Response.Write(curMovie.Country); %>" id="country">
            </div>
      </div>
       <div class="form-group row">
            <label for="production" class="col-sm-2 col-form-label">Production:</label>
            <div class="col-sm-10">
              <input type="text" name="production" class="form-control" value="<% if(curMovie != null) Response.Write(curMovie.Production);%>" id="production">
            </div>
      </div>
     <div class="form-group row">
            <label for="language" class="col-sm-2 col-form-label">Language:</label>
            <div class="col-sm-10">
              <input type="text" name="language" value="<% if (curMovie != null) Response.Write(curMovie.Language);%>" class="form-control" id="language">
            </div>
      </div>
     
          <div class="form-group row">
              <input type="text" name="state" id="state" style="display:none;" value="Insert"/>
              <input type="button" class="btn btn-primary" value="<%: curMovie != null? "Update":"Insert" %>" onclick="setState(this)" />
              <% if (curMovie != null)
                  { %>
            <!--  <input type='button' class='btn btn-primary ml-3' value='Delete' onclick="setState(this)"/>-->
              <% } %>
          </div>

    <script>
        var VdoTitleList = [
               <%foreach (var vdo in model.Movies.ToList()) {%>
            {
                "Title":"<%:!vdo.Title.Equals(curMovie != null ? curMovie.Title : "") ? vdo.Title:"null"%>"
            },
            <%}%>
        ]
     
        /*states.clear();
        states.clearPrefetchCache();
        states.clearRemoteCache();
        states.initialize(true);*/
        function allLetter(e) {
            var letters = /^[A-Za-z+\s,]*[A-Za-z]+$/;
           
            if ($('#'+e).val().match(letters)) {
                return true;
            }
            else {
                $('#'+e).after("<sub style='color:red;' class='errMsg'>"+e+" only Accepts Letters</sub>")
                return false;
            } 
            
        }
        function allDigit(item) {
            var letters = /^\d*$/;
           
                if ($('#' + item).val().match(letters)) {
                    return true;
                }
                else {
                    return false;
                }
        }
        function checkValidate() {
            var status = true;
            if ($("#title").val() == '') {
                $("#title").after("<sub style='color:red;' class='errMsg'>Title Must Not Be Null</sub>")
                status = false;
            }
            <% if (curMovie == null)
        {%>
            VdoTitleList.forEach(e => {
                if (e.Title == $("#title").val()) {
                    $("#title").after("<sub style='color:red;' class='errMsg'>Title Already Exists</sub>");
                    status = false;
                }
                    
            })
              <%}  %>
            if ($('#date').val() == '') {
                $("#date").after("<sub style='color:red;' class='errMsg'>Date Must Not Be Null</sub>")
                status = false;
            }
            if ($('#description').val() == '') {
                $('#description').val("No Description")
                status = false;
            }<% if (curMovie == null) {%>
                if ($('#trailer').get(0).files.length === 0) {
                $("#trailer").after("<sub style='color:red;' class='errMsg'>Trailer Must Not Be Null</sub>")
                        status = false;
                    }
                    if ($('#poster').get(0).files.length === 0) {
                $("#poster").after("<sub style='color:red;' class='errMsg'>Poster Must Not Be Null</sub>")
                        status = false;
                    }
                    if ($('#movie').get(0).files.length === 0) {
                $("#movie").after("<sub style='color:red;' class='errMsg'>Movie Must Not Be Null</sub>")
                        status = false;
            }
            <%}%>
                    if ($('#director').val() == '') {
                $('#director').val("Unknown");
                        status = false;
                    }
            else if (!allLetter("director")) {
                        status = false;
                    }
                    if ($('#country').val() == '') {
                $('#country').val("Unknown");
                        status = false;
                    }
            else if (!allLetter("country")) {
                        status = false;
                    }
                    if ($('#production').val() == '') {
                $('#production').val("Unknown");
                        status = false;
                    }
                    if ($('#language').val() == '') {
                $('#language').val("Unknown");
                        status = false;
                    }
            else if (!allLetter("language")) {
                        status = false;
                    }
            if ($('#budget').val() == '') {
                $('#budget').val("0");
                status = false;
            }
            else if (!allDigit("budget")) {
                $("#currency").parent('.input-group-append').after("<br/><sub style='color:red;' class='errMsg'>Budget must be Digit</sub>");
                status = false;
            }
                        
                    return status;
                }
                function setState(state) {
          
                    $("#comBudget").val($("#budget").val() + " " + $('#currency').html());
                    console.log($('#comBudget').val())
                    $('.errMsg').remove();
                    $("#state").val($(state).val());
                    if (checkValidate()) {
                $('#budget').val($('#currency').val() + $('#budget').val())
                        $("#form1").submit();
                    }

                    // $("#form1").validate();
                    //  $("#form1").submit();
                }
                var casts = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
                    queryTokenizer: Bloodhound.tokenizers.whitespace,
                    prefetch: {

                        url: '../typeAhead/Casts',
                        filter: function (list) {
                    return $.map(list, function (item) {
                        return {

                                    Name: item.Name
                        };
        });
                }
            }
        });
        var tags = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            prefetch: {
                url: '../typeAhead/Tags',
                filter: function (list) {
                    return $.map(list, function (item) {
                        return {
                            Name: item.Name
                        };
                    });
                }
            }
        });
        tags.initialize();
        casts.initialize();
        $("#cast").tagsinput({
            confirmKeys: [44],
            freeInput: false,
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
            templates: {
                empty: [
                    '<div class="empty-message">',
                    'unable to find any Best Picture winners that match the current query',
                    '</div>'
                ].join('\n'),
                suggestion: function (data) {
                    return '<p><strong>' + data.name + '</strong> – ' + '</p>';
                }
            }
        });
        $("#tag").tagsinput({
            confirmKeys: [44],
            freeInput: false,
            typeaheadjs: [{
                minLength: 1,
                highlight: true
            }, {
                minlength: 3,
                name: 'Name',
                displayKey: 'Name',
                valueKey: 'Name',
                source: tags.ttAdapter()
            }],
            templates: {
                empty: [
                    '<div class="empty-message">',
                    'unable to find any Best Picture winners that match the current query',
                    '</div>'
                ].join('\n'),
                suggestion: function (data) {
                    return '<p><strong>' + data.name + '</strong> – ' + '</p>';
                }
            }
        });
        <% if (curMovie != null)
        { %>
        <% foreach (var t in curMovie.Tags)
        {
            %>
        $('#tag').tagsinput('add', '<%:t.Name%>');
        <% } %>
         <% foreach (var c in curMovie.Casts)
        {
            %>
        $('#cast').tagsinput('add', '<%:c.Name%>');
        <% }
        }%>
        $(".bootstrap-tagsinput").addClass("w-100");
       
   </script>
</asp:Content>

    
