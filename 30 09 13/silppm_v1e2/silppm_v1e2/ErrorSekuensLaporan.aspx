<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="ErrorSekuensLaporan.aspx.cs" Inherits="silppm_v1e2.WebForm63" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Maaf anda tidak dapat mengunggah Draft Laporan Akhir.</p>
    <p>
        Hal ini mungkin dikarenakan anda belum mengunggah laporan perkembangan bulanan untuk keperluan monev.. Terimakasih.</p>
    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Kembali</asp:LinkButton>
    </p>
</asp:Content>
