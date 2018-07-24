<%@ Page Title="Malta" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">  
        <h2>Movies Made in Malta</h2>
    </hgroup>
 <%--   Styles for social network buttons--%>

 <style type="text/css">
 #share-buttons img {
width: 35px;
padding: 5px;
border: 0;
box-shadow: 0;
display: inline;
}
 
</style>


<div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.10";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
  
            <p>
                This web site is dedicated to movies made in Malta, Gozo and Comino.<br />             
               
            Malta has been a favorite amongst filmmakers and TV drama Producers (as well as the odd TV commercial and pop video) for many years<br />
            <p>
                There are several reasons that attract Hollywood filmmakers (and others) to Malta.
                The natural historic settings and backdrops which can double as virtually any period in history and many other countries in the Mediterranean, North Africa and even the Middle East. Spielberg used it for EIGHT different countries in his movie <strong>Munich</strong>!.<br />
                <br />
                Its unique large water tanks in Rinella which have been used in countless sea faring movies. Not to mention, bright sunshine, cheaper production costs and the facilities at the <strong>MFS</strong> (Mediterranean Film Studios)</p>
            <br />
 
        
    
   <div class="fb-like" data-href="http://moviesmadeinmalta.com" data-layout="button_count" data-action="like" data-size="large" data-show-faces="false" data-share="true"></div>
<div id="share-buttons">
    
    <!-- Email -->
    <a href="mailto:?Subject=Movies Made in Malta&amp;Body=I%20saw%20this%20and%20thought%20of%20you!%20 http://www.moviesmadeinmalta.com">
        <img src="Images/icons/email.png" alt="Email"/></a>
  <!-- Gmail -->
<a target="_blank" href="https://mail.google.com/mail/?view=cm&fs=1&tf=1&body=http://www.moviesmadeinmalta.com&su=Movies Made In Malta"><img src="Images/icons/gmail.png"  /></a>
    <!-- Google+ -->
    <a href="https://plus.google.com/share?url=http://www.moviesmadeinmalta.com" target="_blank"><img src="Images/icons/google.png" alt="Google" /></a>    
   <!-- Pinterest -->
    <a href="javascript:void((function()%7Bvar%20e=document.createElement('script');e.setAttribute('type','text/javascript');e.setAttribute('charset','UTF-8');e.setAttribute('src','http://assets.pinterest.com/js/pinmarklet.js?r='+Math.random()*99999999);document.body.appendChild(e)%7D)());">
       <img src="Images/icons/pinterest.png" alt="Pinterest" /></a>
            <!-- StumbleUpon-->
    <a href="http://www.stumbleupon.com/submit?url=https://simplesharebuttons.com&amp;title=Movies Made in Malta" target="_blank">
        <img src="Images/icons/stumbleupon.png" alt="StumbleUpon" /></a>    
    
    <!-- Twitter -->
    <a href="https://twitter.com/share?url=http://www.moviesmadeinmalta.com&amp;text=Simple%20Share%20Buttons&amp;hashtags=simplesharebuttons" target="_blank"><img src="Images/icons/twitter.png" alt="Twitter" /></a>

<%--             <!-- Buffer -->
    <a href="https://bufferapp.com/add?url=http://www.moviesmadeinmalta.com&amp;text=Movies Made in Malta" target="_blank">
        <img src="Images/icons/buffer.png" alt="Buffer" />
    </a>
    
    <!-- Digg -->
    <a href="http://www.digg.com/submit?url=http://www.moviesmadeinmalta.com" target="_blank">
        <img src="Images/icons/diggit.png" alt="Digg" />
    </a>

   --%>  

        </div>

    <!-- SOCIAL MEDIA ICONS LINKS -->
    
           <div style="display: inline-block"></div>
    
 
                
</asp:Content>
