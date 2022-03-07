<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="DekanAddFeedBack.aspx.cs" Inherits="silppm_v1e2.WebForm53" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Silahkan Pilih :</p>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>Revisi</asp:ListItem>
        <asp:ListItem>Di Tolak</asp:ListItem>
    </asp:RadioButtonList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="RadioButtonList1" ErrorMessage="*Harus Di Pilih" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    <p>
        Alasan dilakukan revisi / penolakan :</p>
    <asp:TextBox ID="TextBox1" runat="server" Height="212px" TextMode="MultiLine" 
        Width="920px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox1" ErrorMessage="*Harus Di ISI" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Simpan" onclick="Button1_Click" />
</asp:Content>
