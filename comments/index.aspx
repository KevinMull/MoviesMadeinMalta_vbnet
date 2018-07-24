<%@ Page Title="Comments" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="index.aspx.vb" Inherits="_Comments" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


      <hgroup class="title">  
        <h2>Comments</h2>
    </hgroup> 
    
           <p>Please add any comments, errors, inaccuracies etc.  If correcting a scene location , please quote the scene ID.</p>
<p>Note, web links are not allowed. </p>
	  
	  <table border="0">
	    
	    <tr>
	      <td><strong>Name:</strong></td>
        <td><asp:TextBox ID="txtUserName" placeholder="Full name"
		width="250"
		runat="server" />        
        <!-- VALIDATE FIELD-->
  <asp:RequiredFieldValidator ID="rfvUserName" runat="server"
ErrorMessage="You must enter a Name!"
ControlToValidate="txtUserName" /></td>
      </tr>
	    <tr>
	      <td valign="top"><strong>Email (won't be shown):</strong>
          </td>
        <td><asp:TextBox ID="txtUserEmail" placeholder="Email address"
		width="250"
		runat="server" />
             <!-- VALIDATE FIELD-->
			 <asp:RequiredFieldValidator ID="rfvUserEmail" runat="server"
ErrorMessage="Email address is invalid!"
ControlToValidate="txtUserEmail" />
  <asp:RegularExpressionValidator ID=valEmailAddress
ControlToValidate=txtUserEmail	ValidationExpression=".*@.*\..*" 
ErrorMessage="Email address is invalid!"
 EnableClientScript=true Runat=server/>
 </td>
      </tr>
	    <tr>
	      <td valign="top"><strong> Comments:</strong></td>
        <td>
		<asp:TextBox ID="txtComments"
		TextMode="MultiLine"
		 Rows="10"
		width="450"		
		runat="server" />
            <!-- VALIDATE FIELD-->
		 <asp:RequiredFieldValidator ID="rfvComments" runat="server"
ErrorMessage="You must enter a Comment!"
ControlToValidate="txtComments" /></td>
        
      </tr>

          <tr>
              <td> <!-- Hidden 'Honeypot' EMAIL field to fool SPAM BOTS! -->
                 <strong><asp:Label CssClass="noSpam" Text="email" runat="server" /></strong>
                  </td>
                  <td>
             <asp:TextBox CssClass="noSpam" id ="email" runat="server" /></td>
          </tr>
      
	    <tr>
	      <td colspan="3"><div align="center">
      
	        <asp:Button id="btnInsert" runat="server" OnClick="AddComment" Text="SUBMIT" /></div></td>
      </table>
     
	<strong>
		<asp:Label id="lblThanks" 
		Font-Bold="true" 
		runat="server"/>
	</strong>
	<hr>
	<br>
    <h2>Previous Comments:</h2>
		<asp:DataGrid ID="dgComments" he
runat="server"
AutoGenerateColumns="false"
HeaderStyle-Font-Bold="true"
GridLines="none"
CellPadding="1"
CellSpacing="0"
Width="550"

>
          <columns>
          <asp:TemplateColumn>
            <itemtemplate>
              <table>
                <tr>
                  <td><strong>Name:</strong></td>
                  <td><strong> <%# DataBinder.Eval(Container.DataItem, "UserName")%> </strong> </td>
                </tr>
               <%-- <tr>
                  <td><strong>Email:</strong></td>
                  <td><a href="mailto:<%# DataBinder.Eval(Container.DataItem, "UserEmail")%>"><%# DataBinder.Eval(Container.DataItem, "UserEmail")%></a> </td>
                </tr>--%>
                <td valign="top"><strong>Comments:</strong></td>
            <td><%# DataBinder.Eval(Container.DataItem, "Comments")%> </td>
                </tr>
                <tr>
                  <td><strong>Date:</strong></td>
                  <td><%# DataBinder.Eval(Container.DataItem, "CommentDate","{0:dd-MMM-yyyy}") %> </td>
                </tr>
                <tr>
                  <td colspan="2"><br />
              <separatortemplate>
                <hr />
            </separatortemplate></td>
                </tr>
              </table>
            </itemtemplate>
          </asp:TemplateColumn>
          </columns>
        </asp:DataGrid>   
  
       
</asp:Content>
