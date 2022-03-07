<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="PerpanjanganPenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm64" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-size: large;
            width: 301px;
        }
        .style2
        {
            width: 301px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                Perpanjangan Proposal Penelitian</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Masukkan Awal Perpanjangan :</td>
            <td>
                        <asp:TextBox ID="dateMulai" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="dateMulai_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="dateMulai" TodaysDateFormat="0:MM/dd/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Durasi Perpanjangan :</td>
            <td>
                        <asp:DropDownList ID="dateSelesai" runat="server">
                            <asp:ListItem>1 bulan</asp:ListItem>
                            <asp:ListItem>2 bulan</asp:ListItem>
                        </asp:DropDownList>
                    </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Button ID="Simpan" runat="server" style="text-align: right" 
                    Text="Simpan" onclick="Simpan_Click" />
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Kembali" 
                    onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CssClass="GridViewStyle" DataKeyNames="id_proposal" 
        HeaderStyle-CssClass="HeaderStyle" 
        PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" 
        SelectedRowStyle-CssClass="SelectedRowStyle" style="margin-top: 0px">
        <Columns>
            <asp:BoundField DataField="KE" HeaderText="No" />
            <asp:BoundField DataField="judul" HeaderText="Judul" />
            <asp:BoundField DataField="TGL_MULAI_PERPANJANG" 
                HeaderText="Perpanjangan Awal" />
            <asp:BoundField DataField="TGL_SELESAI_PERPANJANG" 
                HeaderText="Perpanjangan Berakhir" />
        </Columns>
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>

</asp:Content>
