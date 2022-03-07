<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="ErrorLaporanPengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm90" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />Maaf anda sudah pernah melakukan upload Laporan sebelumnya,</p>
    <p>
        Silahkan tekan
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Link Berikut</asp:LinkButton>
&nbsp;untuk melakukan upload ulang laporan.</p>
</asp:Content>
