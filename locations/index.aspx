
<%@ Page Title="Locations" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="index.aspx.vb" Inherits="locations" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">  
        <h2>Malta Locations</h2>
    </hgroup>
    <p>
        The number shown in brackets denotes the number of movies made at that location (according to the data used by this site).
    </p>

<asp:DataList id="DataList1" runat="server"
RepeatColumns="2"
RepeatDirection="Vertical"
 >
  <ItemTemplate>
    <li>
	<asp:HyperLink id="lnkLocation" 
	Font-Size="12"	
    NavigateUrl='<%# "thumbs/index.aspx?LocationSiteID=" & DataBinder.Eval(Container.DataItem,"LocationSiteID") %>'
    Text='<%# DataBinder.Eval(Container.DataItem,"LocationPlaceAndSiteName") & " (" & DataBinder.Eval(Container.DataItem,"CountofTitleID") &")"  %>'
    runat="server" />    
	</li>
  </ItemTemplate>
  <FooterTemplate>
    </ul>
  </FooterTemplate>
</asp:DataList>

   
</asp:Content>