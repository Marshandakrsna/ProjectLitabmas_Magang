<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminKelolaPeriode.aspx.cs" Inherits="silppm_v1e2.WebForm23" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 284px;
        }
        .style2
        {
            text-decoration: underline;
            font-size: medium;
        }
        .style3
        {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    <table style="width:100%;">
    <tr>
        <td class="style2" colspan="2" style="text-align: center">
            
            <strong>PENGELOLAAN PERIODE PROPOSAL</strong></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            <strong>PERIODE AKTIF :</strong></td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Nama Periode :</td>
        <td class="style1">
            <asp:Label ID="lblPeriode" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Masa Periode :</td>
        <td class="style1">
            Awal :
            <asp:Label ID="lblAwal" runat="server"></asp:Label>
        </td>
        <td>
            Akhir :<asp:Label ID="lblAkhir" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            <strong>UBAH PERIODE ::</strong></td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Periode :</td>
        <td colspan="2">
            <asp:DropDownList ID="txtPeriode" runat="server" Height="16px" Width="114px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Periode Awal :</td>
        <td class="style1">
                        <asp:TextBox ID="dateMulai" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="dateMulai_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="dateMulai" 
                TodaysDateFormat="0:MM/dd/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="dateMulai" ErrorMessage="*Harus di isi" 
                ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Periode AKhir :</td>
        <td class="style1">
                        <asp:TextBox ID="dateAkhir" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="dateAkhir_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="dateAkhir" 
                TodaysDateFormat="0:MM/dd/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="dateAkhir" ErrorMessage="*Harus di isi" 
                ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style1">
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                Text="Buka Periode" />
        </td>
        <td>
            <asp:Button ID="btnBatal" runat="server" Text="Batal" />
        </td>
    </tr>
</table>
</asp:Content>
