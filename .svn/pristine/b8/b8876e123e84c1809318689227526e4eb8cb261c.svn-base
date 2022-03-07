<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="DekanApprovalProposalPengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm70" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

         
        .style4
        {
            font-size: 14px;
        background-color: #FFFF99;
    }
        
        .style4
        {
            text-align: center;
            font-size: 16px;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        }
         
        .style17
    {
        text-align: justify;
        }
        .style12
        {
            text-align: justify;
        }
        .style18
        {
            text-align: justify;
            width: 283px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <asp:Panel ID="panelBawah" runat="server">
        <table style="Background-color:White; width:102%; " border="1px" 
        class="GridViewStyle">
            <tr>
                <td class="style4" colspan="3">
                    <strong>PENGESAHAN PROPOSAL PENGABDIAN PADA MASYARAKAT</strong></td>
            </tr>
            <tr>
                <td class="style18">
                    Periode Penelitian</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblPeriode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Judul Kegiatan Pengabdian</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblJudul" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Judul Penelitian yang digunakan sebagai landasan kegiatan yang diusulkan ini</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblLandasan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Jenis Pengabdian</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblJenis" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Dosen Pengusul</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblDosenPengusul" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Anggota 1</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblAnggota1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Anggota 2</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblAnggota2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Mitra Kerjasama atau Mitra sasaran</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblMitra" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Lokasi</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblLokasi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Jarak PT ke lokasi kegiatan pengabdian</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblJarak" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Luaran (Output) yang dihasilkan</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Outcome</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblOutcome" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Jangka waktu dan durasi pelaksanaan kegiatan</td>
                <td class="style12">
                    <asp:Label ID="lblAwal" runat="server"></asp:Label>
                </td>
                <td>
                    Durasi efektif :
                    <asp:Label ID="lblAkhir" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                Sasaran</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblSasaran" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                Beban SKS</td>
                <td class="style12">
                Ketua :
                    <asp:Label ID="lblSKSKetua" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Panel ID="panelSksAnggota" runat="server">
                    Anggota :
                        <asp:Label ID="lblSKSAnggota" runat="server"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style18">
                Topik Penelitian sesuai dengan rencana unit</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblTopik" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18" rowspan="2">
                Dana yang diusulkan</td>
                <td class="style4">
                Dari UAJY</td>
                <td class="style4" style="text-align: center">
                Dari Pribadi pengusul</td>
            </tr>
            <tr>
                <td class="style12">
                Rp&nbsp;
                    <asp:Label ID="lblDanaUajy" runat="server"></asp:Label>
                </td>
                <td>
                Rp
                    <asp:Label ID="lblDanaPribadi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style18">
                Dokumen</td>
                <td class="style12" colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Unduh</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style18">
                &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
                    Text="Setujui Proposal" />
                </td>
                <td>
                    <asp:Button ID="LblRevisi0" runat="server" onclick="LblRevisi_Click" 
                    Text=" Revisi / Tolak" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
