<%@ Register Src="~/controls/Pager.ascx" TagPrefix ="Pager" TagName ="uc1" %>
<%@ Page Title="Locations" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ListviewThumbs.aspx.vb" Inherits="_Thumbs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">  
        
    </hgroup>
    <p><h2>
        <asp:Label id="lblHeader"       
        runat="server" /> 
        </h2>
    </p>

<asp:Listview id="ListView1" runat="server" >
    <LayoutTemplate>
        <ul class="thumbslist">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />

        </ul>   </LayoutTemplate>

<ItemTemplate>


<li>
    <center><strong><%# Container.DataItem("Title")  %></strong><br>
    <asp:HyperLink
id="imgSceneThumb"
ImageUrl='<%# "/images/scenes/thumbs/" & DataBinder.Eval(Container.DataItem, "SceneID") & ".jpg"%>'
NavigateUrl='<%# "/scenes/index.aspx?SceneID=" & DataBinder.Eval(Container.DataItem, "SceneID") & "&indexID=" & intIndexId & "&LocationSiteID=" & intLocationSiteID%>'
Text='<%# DataBinder.Eval(Container.DataItem,"LocationPlaceAndSiteName") %>'
runat="server"  /></li> </center>

</ItemTemplate>
</asp:Listview>	

    <asp:DataPager ID="DataPager1" 
        PageSize="20" 
        PagedControlID ="ListView1"  
        runat="server">
        <Fields>
            <asp:NumericPagerField />
        </Fields>

    </asp:DataPager>
     <asp:label ID="lblStatus" 
        Runat="server" />

 <%--   <table align="left">

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
              <% End If%>--%>
    <p style="text-align:left">
	  <a href="/locations/index.aspx" >Locations Index</a> </p>


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