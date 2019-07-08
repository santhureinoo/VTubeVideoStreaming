<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarouseItem.ascx.cs" Inherits="WebApplication1.UserControllers.CarouseItem" %>

<div class="carousel-item <%:IsActive ? "active" : "" %>">
        <div class="jumbotron jumbotron-fluid"style="height: 100vh;overflow: auto;background: url('https://picsum.photos/1500/500') no-repeat center center; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
      <div class="container">
        <h1>Bootstrap Tutorial</h1>      
        <p>Bootstrap is the most popular HTML, CSS, and JS framework for developing responsive, mobile-first projects on the web.</p>
      </div>
    </div>
</div>