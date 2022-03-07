<%@ Page Title="" Language="C#" MasterPageFile="~/Pustakawan.Master" AutoEventWireup="true" CodeBehind="WebForm38.aspx.cs" Inherits="silppm_v1e2.WebForm38" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Selamat datang&nbsp;&nbsp;</span><asp:Label ID="lblnama" runat="server" 
    CssClass="style2" Font-Size="Medium" Text="Nama"></asp:Label>
<span class="style2">
&nbsp;di Sistem Informasi Lembaga Penelitian dan Pengabdian Masyarakat Universitas 
Atma Jaya Yogyakarta.<br />
Anda melakukan Log In sebagai Pustakawan dan memiliki hak sebagai berikut :<br />
        1 Review Laporan Penelitian<br />
        2 Review Laporan Pengabdian<br />
        3 Melakukan Approval untuk Laporan Penelitian yang sudah di Terima<br />
        4 Melakukan Approval untuk Laporan Pengabdian yang sudah di Terima
    </p>
</asp:Content>
