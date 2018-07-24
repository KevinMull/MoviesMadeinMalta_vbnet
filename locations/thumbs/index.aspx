<%--<%@ Register Src="~/controls/Pager.ascx" TagPrefix ="Pager" TagName ="uc1" %>--%>
<%@ Page Title="Locations" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="index.aspx.vb" Inherits="_Thumbs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
    <h2>
        <asp:Label id="lblHeader"       
        runat="server" /> 
        </h2>
    <% If strTitle = "UNKNOWN" Then%>

      <p>If you can identify any of the 'unknown locations' below then please <a href='m&#97;ilt&#111;&#58;%&#54;Be%&#55;6%6Dull65&#64;%67&#109;&#97;il&#46;com'>contact me</a> or  submit a <a href="/comments/index.aspx">comment</a>
quoting the <strong>Scene Id</strong></p>
    <% Else %>
    <div class="imageContainer" id="map" style="width:400px;height:300px"></div>

<script>
    function myMap() {
        //var myCenter = new google.maps.LatLng(35.88885, 14.51199
        //var sValue = document.getElementById('strLatLong').textContent;
        var myLatLong = new google.maps.LatLng(<%=strLatLong.Value%>);   
        var mapCanvas = document.getElementById("map");
       // var mapOptions = {gestureHandling: 'greedy'}; // Enable zooming with mouse within window
        var mapOptions = { center: myLatLong, zoom: <%=intZoomLevel.Value%> };
        var map = new google.maps.Map(mapCanvas, mapOptions);
        var marker = new google.maps.Marker({
            position: myLatLong,
            icon: '/images/icons/clapper.png'});
        marker.setMap(map);
    }
</script>

    <script  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD2NceVpHdaJdEUGVdWC8qM_0nYVl8RsSQ&callback=myMap">
    </script>  
                 
            <asp:HyperLink ID="hrImgLocationHiRes" runat="server" Target="_blank"  >
    <asp:Image ID="imgLocationSite" runat="server" CssClass="imageContainer" /></asp:HyperLink>
    
    <% End If %>     
    <br />       
             

    <asp:DataList id="DataList1" 
    RepeatColumns="3"
    RepeatDirection="Horizontal"
    runat="server"
    GridLines="both"
    CellPadding="1"
    CellSpacing="0"
    BorderWidth="1"
    >

    <ItemTemplate>

    <center><strong><%# Container.DataItem("Title")  %></strong><br>
    <asp:HyperLink
    id="imgSceneThumb"
    ImageUrl='<%# "/images/scenes/thumbs/" & DataBinder.Eval(Container.DataItem, "SceneID") & ".jpg"%>'
    NavigateUrl='<%# "/scenes/index.aspx?SceneID=" & DataBinder.Eval(Container.DataItem, "SceneID") & "&indexID=" & intIndexId & "&LocationSiteID=" & intLocationSiteID%>'
    Text='<%# DataBinder.Eval(Container.DataItem,"LocationPlaceAndSiteName") %>'
    runat="server" /> </center>

         <% If strTitle = "UNKNOWN" Then%>
        <center>
        <asp:Label  runat="server" text='<%# "Scene ID: " &  DataBinder.Eval(Container.DataItem, "SceneId") %>'
              />
            </center>
        <% End If %>

         

    </ItemTemplate>
    </asp:DataList>	

    <table align="left">

    <tr>
        <td>
        <asp:label ID="lblStatus" 
        Runat="server" />
        </td>
  </tr>
        </table> 
    <% If CInt(intRecordCount.Text) > CInt(intPageSize.Text) Then%>
       <asp:Table runat ="server" >
           <asp:TableRow >
		<asp:TableCell>&nbsp;</asp:TableCell>
		 
		<asp:TableCell >
          <div align="center"><a href="Thumbs.aspx#this" 
        ID="hrefFirst"
        onserverclick="ShowFirst" 
        runat="server">&lt&ltFirst</a> </div></asp:TableCell>
		<asp:TableCell>&nbsp; </asp:TableCell>
        <asp:TableCell>
          <div align="center" class="style4">
              <a    ID="hrefPrevious"
        onserverclick="ShowPrevious" 
        runat="server">&ltPrev </a> </div></asp:TableCell>
		<asp:TableCell>&nbsp; </asp:TableCell>
        <asp:TableCell>
          <div align="center" class="style4"><a ID="hrefNext"
        onserverclick="ShowNext"
        runat="server">Next&gt</a> </div></asp:TableCell>
		<asp:TableCell>&nbsp; </asp:TableCell>
        <asp:TableCell>
          <div align="center" class="style4"><a ID="hrefLast"
        onserverclick="ShowLast" 
        runat="server">Last&gt&gt</a> </div></asp:TableCell>
    
          </asp:TableRow>
           </asp:Table>
              <% End If%>
    <p style="text-align:left">
	  <a href="/locations/index.aspx" >Locations Index</a> </p>

<%--    Hidden values--%>
<asp:HiddenField ID="strLatLong" runat="server"   /> 
 <asp:HiddenField ID="intZoomLevel" runat="server"   /> 

<asp:label ID="intCurrIndex" 
Visible="False"
Runat="server" />
<asp:label ID="intPageSize" 
Visible="false"
Runat="server" />

<asp:label ID="intRecordCount" 
Visible="false"
    Runat="server" />

  
</asp:Content>