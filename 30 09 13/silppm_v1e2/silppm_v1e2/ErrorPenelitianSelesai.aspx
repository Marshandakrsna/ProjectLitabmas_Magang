<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="ErrorPenelitianSelesai.aspx.cs" Inherits="silppm_v1e2.WebForm83" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Maaf anda tidak dapat menambahkan Proposal Baru, karena Penelitian anda 
        Sebelumnya telah dinyatakan Belum Berakhir.
    </p>
    <p>
        Cek Penelitian anda 
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Profile.aspx">disini.</asp:LinkButton>
    </p>
</asp:Content>
