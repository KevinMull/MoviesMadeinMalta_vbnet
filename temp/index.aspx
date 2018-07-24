
<%@ Page Title="Temp" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="index.aspx.vb" Inherits="temp" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
 
   <%-- <ul class="thumbslist">
        <li><img src="../Images/scenes/thumbs/10.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/11.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/12.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/13.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/14.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/15.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/16.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/17.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/18.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/19.jpg" /> <br />some text </li>
        <li><img src="../Images/scenes/thumbs/20.jpg" /> <br />some text </li>

    </ul>--%>

<div class="imageContainer" id="map" style="width:400px;height:300px"></div>
    
<script>
    function myMap() {
        var myCenter = new google.maps.LatLng(51.508742, -0.120850);
        var mapCanvas = document.getElementById("map");
        var mapOptions = { center: myCenter, zoom: 5 };
        var map = new google.maps.Map(mapCanvas, mapOptions);
        var marker = new google.maps.Marker({ position: myCenter });
        marker.setMap(map);
    }
</script>

<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD2NceVpHdaJdEUGVdWC8qM_0nYVl8RsSQ&callback=myMap"></script>
<!--
To use this code on your website, get a free API key from Google.
Read more at: https://www.w3schools.com/graphics/google_maps_basic.asp
-->
    
        <div class="imageContainer">
    <img alt="" src="/images/locations/14.jpg" />
    </div>    
 
   
</asp:Content>