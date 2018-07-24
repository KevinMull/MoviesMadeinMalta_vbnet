<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Pager.ascx.vb" Inherits="controls_Pager" %>

<table align="left">

    <tr>
        <td>
        <asp:label ID="lblStatus" 
        Runat="server" />
        </td>
  </tr>
        </table> 
    <% If CInt(intRecordCount.Text) > CInt(intPageSize.Text) Then%>
       <asp:Table ID="Table1" runat ="server" >
           <asp:TableRow >
		<asp:TableCell>&nbsp;</asp:TableCell>
		 
		<asp:TableCell >
          <div align="center"><a href="Thumbs.aspx#this" 
        ID="hrefFirst"
        onserverclick="ShowFirst" 
        runat="server">&lt&ltFirst</a> </div></asp:TableCell>
		<asp:TableCell>&nbsp; </asp:TableCell>
        <asp:TableCell>
          <div align="center" class="style4"><a href="Thumbs.aspx#this" 
        ID="hrefPrevious"
        onserverclick="ShowPrevious" 
        runat="server">&ltPrev </a> </div></asp:TableCell>
		<asp:TableCell>&nbsp; </asp:TableCell>
        <asp:TableCell>
          <div align="center" class="style4"><a href="Thumbs.aspx#this" 
        ID="hrefNext"
        onserverclick="ShowNext"
        runat="server">Next&gt</a> </div></asp:TableCell>
		<asp:TableCell>&nbsp; </asp:TableCell>
        <asp:TableCell>
          <div align="center" class="style4"><a href="xxx.aspx#this" 
        ID="hrefLast"
        onserverclick="ShowLast" 
        runat="server">Last&gt&gt</a> </div></asp:TableCell>
    
          </asp:TableRow>
           </asp:Table>
              <% End If%>
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
