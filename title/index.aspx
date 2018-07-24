<%@ Page Title="Locations" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="index.aspx.vb" Inherits="_Title" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<center>
    <h2>
<asp:Label id="lblHeader"
runat="server" />
        </h2>
</center>  

<asp:Gridview id="Gridview1"
runat="server"
AutoGenerateColumns="false"
CellPadding="0"
CellSpacing="0"
BorderWidth="0"
>
  <columns>
     <asp:Templatefield>
    <ItemTemplate>    
          <asp:image id="imgTitle1"
		  AlternateText='<%# DataBinder.Eval(Container.DataItem,"Title") %>'
             ToolTip='<%# DataBinder.Eval(Container.DataItem,"Title") %>'
			 ImageUrl='<%# "/images/titles/" & intTitleID & ".jpg"%>'
			 runat="server"  ImageAlign="Left"/>  

              <%# DataBinder.Eval(Container.DataItem, "Summary") %> 
                     

		  </ItemTemplate>
		</asp:Templatefield>
  </columns>
</asp:Gridview>
  
    <asp:Literal ID="ltWidescreen" Visible ="false"    runat="server"></asp:Literal>


<strong>SCENES - Click on a thumbnail to see larger image and description</strong>

      <%--aka dlScenes--%>
<asp:DataList id="DataList1"
RepeatColumns="4"
RepeatDirection="Horizontal"
runat="server"
CellPadding="0"
CellSpacing="0"
BorderWidth="0"
>

<ItemTemplate>
    <center>
<asp:HyperLink
id="imgScene"
ImageUrl='<%# "/images/scenes/thumbs/" & DataBinder.Eval(Container.DataItem, "SceneID") & ".jpg"%>'
NavigateUrl='<%# "/scenes/index.aspx?TitleID=" & intTitleID & "&indexID=" & intIndexID & "&SceneID=" & DataBinder.Eval(Container.DataItem, "SceneID")%>'
Text='<%# DataBinder.Eval(Container.DataItem,"LocationSiteAndPlaceName") %>'
runat="server" />
        </center>
    </ItemTemplate>
   

</asp:DataList>	

<table align="left" >

    <tr>
        <td>
        <asp:label ID="lblStatus" 
        Runat="server" 
        
         />        </td>
		<td>&nbsp;		</td>
        <td>
          <div align="center" class="style4"><a href="Title.aspx#this" 
        ID="hrefFirst"
        onserverclick="ShowFirst" 
        runat="server">&lt&ltFirst</a> </div></td>
		<td>&nbsp; </td>
        <td>
          <div align="center" class="style3"><a href="Title.aspx#this" 
        ID="hrefPrevious"
        onserverclick="ShowPrevious" 
        runat="server">&ltPrev </a> </div></td>
		<td>&nbsp; </td>
        <td>
          <div align="center" class="style3"><a href="Title.aspx#this" 
        ID="hrefNext"
        onserverclick="ShowNext"
        runat="server">Next&gt</a> </div></td>
		<td>&nbsp; </td>
        <td>
          <div align="center" class="style3"><a href="Title.aspx#this" 
        ID="hrefLast"
        onserverclick="ShowLast" 
        runat="server">Last&gt&gt</a> </div></td>
    </tr>
	<tr>
	<td align="center" colspan="9">
	  <a href="/movies/index.aspx">Main Index</a>	</td>
	</tr>
</table>  

<asp:label ID="intCurrIndex" 
Visible="False"
Runat="server" />
<asp:label ID="intPageSize" 
Visible="False"
Runat="server" />

<asp:label ID="intRecordCount" 
Visible="False"
Runat="server" />
	

    </asp:content>
















