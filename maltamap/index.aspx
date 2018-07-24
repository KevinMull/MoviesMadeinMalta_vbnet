<%@ Page Title="Malta Movie Map" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="index.aspx.vb" Inherits="_MaltaMap" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <hgroup class="title">  
        <h2>Malta Movie Map</h2>
    </hgroup>     
    <p>The map shows Malta locations and the movies made there</p>  

<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD2NceVpHdaJdEUGVdWC8qM_0nYVl8RsSQ&callback=myMap"></script>
<script type="text/javascript">

    var markers = [
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
                {
                 "title": "<%# Eval("LocationSiteName")%>",
                "lat": '<%# Eval("Latitude") %>',
                "lng": '<%# Eval("Longitude") %>',
                "mapInfoHtml": "<%# Eval("MapInfoHtml")%>"
                
                
            }
</ItemTemplate>
<SeparatorTemplate>
    ,
</SeparatorTemplate>
</asp:Repeater>
];
</script>
<script type="text/javascript">
    window.onload = function () {
        var mapOptions = {           
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),     
            gestureHandling: 'greedy', // Enable zooming with mouse within window
            zoom: 11,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title,
                icon: '/images/icons/clapper.png'
            });
            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    infoWindow.setContent(data.mapInfoHtml);
                    infoWindow.open(map, marker);
                });
            })(marker, data);

           
        }
       // google.maps.event.trigger(map, 'resize');
    }

   
</script>
<div id="dvMap" style="width: 780px; height: 650px">
</div>


  <%--  <script  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD2NceVpHdaJdEUGVdWC8qM_0nYVl8RsSQ&callback=myMap">
    </script>  --%>
                 
      
  
</asp:Content>