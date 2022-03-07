<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="InternalKel.aspx.cs" Inherits="silppm_v1e2.WebForm5" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style2
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%; text-align: left;">
        <tr>
            <td  colspan="2" style="text-align: center">
                Tambah Proposal Penelitian
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                    Periode Penelitian</td>
            <td>
                <asp:DropDownList ID="ddlTahun" runat="server" Height="17px" Width="203px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                    Judul</td>
            <td>
                <asp:TextBox ID="txtJudul" runat="server" Width="435px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                    Nama Anggota 1</td>
            <td>
                <asp:TextBox ID="txtnama1" runat="server" Width="342px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                    Nama Anggota 2</td>
            <td>
                <asp:TextBox ID="txtnama2" runat="server" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                    Lokasi Penelitian</td>
            <td>
                <asp:TextBox ID="txtLokasi" runat="server" TextMode="MultiLine" Width="434px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                    Waktu Penelitian</td>
            <td>
                <BDP:BasicDatePicker ID="dateAwal" runat="server" DateFormat="0:MM/dd/yyyy" />
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td>
                Lama Penelitian : 
                <asp:DropDownList ID="dateSelesai" runat="server">
                    <asp:ListItem>1 bulan</asp:ListItem>
                    <asp:ListItem>2 bulan</asp:ListItem>
                    <asp:ListItem>3 bulan</asp:ListItem>
                    <asp:ListItem>4 bulan</asp:ListItem>
                    <asp:ListItem>5 bulan</asp:ListItem>
                    <asp:ListItem>6 bulan</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                    Biaya Penelitian</td>
            <td>
                Rp
                <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="check"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBox4" ErrorMessage="*hanya boleh diisi angka" 
            ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                    Dokumen Penelitian</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <td style="text-align: right" >
            <asp:Button ID="Button1" runat="server" Text="Tambah Proposal" 
            onclick="Button1_Click1" style="text-align: right"  />
        </td>
        <td>
            &nbsp;</td>
    </table>
</asp:Content>
