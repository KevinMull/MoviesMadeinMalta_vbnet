
<%@ Page Title="Temp" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Googlemaptest.aspx.vb" Inherits="temp" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
 
   <head>

   <%-- <style>
       #map {
        height: 400px;
        width: 100%;
       }
    </style>--%>
  </head>
  <body>
    <h3>My Google Maps Demo</h3>
    <div id="map" style="width:400px;height:300px;"></div>

<script>
    function myMap() {
        var myCenter = new google.maps.LatLng(35.88885, 14.51199);
        var mapCanvas = document.getElementById("map");
        var mapOptions = { center: myCenter, zoom: 14 };
        var map = new google.maps.Map(mapCanvas, mapOptions);
        var marker = new google.maps.Marker({ position: myCenter });
        marker.setMap(map);
    }
</script>

    <script  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD2NceVpHdaJdEUGVdWC8qM_0nYVl8RsSQ&callback=myMap">
    </script>

   
</asp:Content>