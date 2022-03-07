<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PortalDekan.aspx.cs" Inherits="silppm_v1e2.PortalDekan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sistem Informasi Lembaga Penelitian dan Pengabdian Masyarakat UAJY</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/StylePopUp.css" rel="stylesheet" type="text/css" />
      <link href="Styles/gridviewstyle/YahooGridView.css" rel="stylesheet" type="text/css" />
        <link type="text/css" href="Styles/menu.css" rel="stylesheet" />
    <script type="text/javascript" src="Styles/jquery.js"></script>
    <script type="text/javascript" src="Styles/menu.js"></script>
    <style type="text/css">



div#menu {
   
    width:100%;
		background:transparent url(../Styles/images/header_bg.gif) repeat-x 0 0;  
}
div#copyright { display: none; }
    
        
    </style>
    
</head>
<body>
 

    
    <form id="form2" runat="server">
    <div class="page">
        <div class="header">
            <div class="title">
            </div>
            <div class="loginDisplay">
                 <img src="../Styles/images/banner.jpg" alt="" border="0" style="width: 938px" />
            </div>
            </div>

        <div class="main">
         
            Silahkan pilih Role yang akan digunakan :
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Dekan</asp:ListItem>
                <asp:ListItem>Dosen</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Konfirmasi" />
         
        </div>
        <div class="clear">
        </div>
    
    <div class="footer">
    </div>
    
    </div>
    </form>
</body>
</html>
