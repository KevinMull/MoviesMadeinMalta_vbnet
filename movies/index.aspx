<%@ Page Title="Movie List" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="index.aspx.vb" Inherits="_Movies" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
      <hgroup class="title">  
        <h2>Movie List</h2>
    </hgroup> 
    
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting ="false" AlternatingRowStyle-BackColor="White"  >
                <Columns>
                    <asp:BoundField DataField="TitleURL" HeaderText="Title" HtmlEncode="false"/>
                    <asp:BoundField DataField="TitleYear" HeaderText="Year" SortExpression="TitleYear" /> 
                    <asp:TemplateField
                        ItemStyle-HorizontalAlign="center"
                        HeaderText="Stills">
                        <ItemTemplate>
                        <asp:HyperLink id="urlTitle" 
                        imageUrl="/images/filmstrip.jpg"
                        NavigateUrl='<%# "/title/index.aspx?TitleID=" & DataBinder.Eval(Container.DataItem, "intScenesTitleID")%>'
                        Visible='<%# CheckNullVal(Container.DataItem("intScenesTitleID")) %>'
                        runat="server"/>	
                        </ItemTemplate>
                        </asp:TemplateField>                                       
                   <asp:TemplateField
                        ItemStyle-HorizontalAlign="center"
                        HeaderText="IMDB Link">
                        <ItemTemplate>

                        <asp:HyperLink id="urlimdb" 
                        imageUrl="/images/imdb.png"
                        NavigateUrl=<%# DataBinder.Eval(Container.DataItem, "imdbURL")%>
                        Target="blank"
                        runat="server"/>	

                        </ItemTemplate>
                        </asp:TemplateField> 
                    
                </Columns>
            </asp:GridView>
          
            <br />                
           
</asp:Content>
