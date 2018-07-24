
<%@ Page Title="Scenes" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Copy of index.aspx.vb" Inherits="_Scenes" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">  
        
    </hgroup>
 <table>
<tr>
<td align="center">
    <h2>
<asp:Label id="lblHeader"		  
runat="server" />
        </h2>
</td>
</tr>
<tr>
<td align="center">
<asp:image id="imgScene"
runat="server"/>
</td>
</tr>
<tr>
<td align="left">
<strong>Location (Malta):</strong>
<asp:Literal ID="ltLocationName"
runat="server" />
</td>
</tr>
<tr>
<td align="left">

<asp:Label ID="lblLocationAlias"
Text="Location (Movie):"
Font-Bold="true"
runat="server" />
<asp:Literal ID="ltLocationAlias" runat="server" />&nbsp;

</td>
</tr>
<tr>
<td align="left">
<asp:Label ID="lblNotes"
Text="Notes"
Font-Bold="true"
runat="server" />
<asp:Literal ID="ltNotes" runat="server" />&nbsp;
</td>
</tr>
     <tr>
<td align="center">
<asp:HyperLink ID="lnkBack"
runat="server"/> 
</td>
</tr>
<tr>
<td align="center">
<asp:Label ID="lblMapLink" Runat="server" Visible ="false"  />
<br><br>
</td>
</tr>

</table>
    
  
</asp:Content>