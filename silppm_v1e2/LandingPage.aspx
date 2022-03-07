<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="silppm_v1e2.LandingPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistem Informasi Lembaga Penelitian dan Pengabdian Masyarakat UAJY</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <%-- <link rel="SHORTCUT ICON" href="Styles/images/uajyicon.ico" />--%>
    <link rel="stylesheet" type="text/css" media="all" href="Styles/Site.css" />
    <link href="Styles/StylePopUp.css" rel="stylesheet" type="text/css" />
    <%--    <link rel="stylesheet" type="text/css" media="all" href="Styles/960.css" />--%>
    </head><body>


<form id="id" runat="server">
<table cellspacing="0" cellpadding="0" width="750" align="center" border="0">
        <!--DWLayoutTable-->
        <tr>
            <td width="780" valign="top">
            
                <table cellspacing="0" cellpadding="0" width="750" align="center" border="0">
                    <tr>
                        <td>
                            <img src="Styles/images/banner.jpg" alt="" border="0" />
                        </td>
                    </tr>
                  
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center" bgcolor="#ffffff">
                                <tr>
                                  <td width="100px">
                                 <div style="float:left; margin-left:10px; margin-right:30px">
                                      <img alt="" border="0" height="138" 
                                          src="Styles/images/kampus2-gedung-thomas-aquinas-680x453.png" width="198" /></div>
                                    <td height="138" valign="top" class="style3">
                                            <h3 align="center" style="font-weight: bold">
                                                Selamat Datang di Sistem Informasi 
                                                LEMBAGA PENELITIAN DAN PENGABDIAN (SILPPM) Universitas Atma Jaya 
                                                Yogyakarta
                                                 </h3>
                                                                                   <p class="style4">               Aplikasi SILPPM ( Sistem Informasi 
                                                                                       Lembaga Penelitian dan Pengabdian Masyarakat ) Universitas Atma Jaya Yogyakarta
                                            adalah aplikasi berbasis web yang digunakan untuk menunjang proses administrasi
                                                                                       pengajuan proposal penelitian dan pengabdian di Universitas Atma Jaya Yogyakarta. </p>
                                            <p class="style4">               User : NPP , password&nbsp; : NPP ( khusus yg blm 
                                                mengganti username)
                            
                                   
                                    </td>
                                    <td valign="top" width="250" height="160" align="left">

                                        <fieldset title="LOGIN">
                                           
        
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0" style="width: 246px">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" 
                                        style="text-align: left">Username:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" style="margin-right: 0px" 
                                        Width="124px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                                        style="text-align: left">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="125px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            
                            <tr>
                            <td align="right">
                                    
                                </td>
                                <td align="left" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                                        onclick="LoginButton_Click" Text="Log In" ValidationGroup="Login1" Width="66px" Font-Bold="True" Height="33px"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        
                                        </fieldset>
                                      
                                    </td><td width="10px">
                                     </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                   
                    <tr>
                  
                      <td align="center" id="">
                            <img src="Styles/images/footer.jpg" alt="" border="0" width="958" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="4">
            </td>
        </tr>
    </table>

    
    
    
    </form>
    
       </body>
</html>
