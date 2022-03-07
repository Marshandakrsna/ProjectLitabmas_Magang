<%@ Page Title="" Language="C#" MasterPageFile="~/KALPPMmaster.Master" AutoEventWireup="true" CodeBehind="KALPPMLihatHasilReview.aspx.cs" Inherits="silppm_v1e2.WebForm58" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style23
        {
            width: 205px;
        }
        .style24
        {
            width: 205px;
            height: 21px;
        }
        .style25
        {
            height: 21px;
        }
        
        .style10
        {
          
            text-align: center;
       
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
            top: 0px;
            left: 110px;
            z-index: -1;
        }
        .style33
        {
            text-align: left;
            
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        }
        .style30
        {
            width: 541px;
            height: 18px;
            text-align: justify;
            top: 0px;
            left: 110px;
            z-index: -1;
        }
        .style29
        {
            text-align: left;
            width: 23px;
        }
        .style7
        {
            text-align: left;
        }
        .style31
        {
            width: 541px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Panel ID="Panel2" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="style23">
                    Revisi dilakukan Oleh
                </td>
                <td>
                    <asp:Label runat="server" ID="lblReveiewer1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style23">
                    Status</td>
                <td>
                    <asp:Label runat="server" ID="lblStatus1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style23">
                    Biaya yang diRekomendasikan</td>
                <td>
                    <asp:Label runat="server" ID="llblBiayaRekomen1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style24">
                    Biaya disetujui
                </td>
                <td class="style25">
                    <asp:Label runat="server" ID="lblBiayaSetuju1"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table border="1px" class="GridViewStyle" style="width:100%;" 
                    __designer:mapid="19d">
        <tr __designer:mapid="19e">
            <td class="style10" __designer:mapid="19f">
                Kriteria Penilaian</td>
            <td class="style33" __designer:mapid="1a0">
                Nilai</td>
            <td class="style33" __designer:mapid="1a1">
                Justifikasi_Penilaian</td>
        </tr>
        <tr __designer:mapid="1a2">
            <td class="style30" __designer:mapid="1a3">
                Originalitas penelitian : terlihat pada orisinalitas permasalahan, metode 
                            penelitian, tempat penelitian dan waktu penelitian.</td>
            <td class="style29" __designer:mapid="1a4">
                <asp:Label runat="server" ID="lblnilai1"></asp:Label>
            </td>
            <td class="style7" __designer:mapid="1a6">
                <asp:Label runat="server" ID="lblJustifikasi1"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="1a8">
            <td class="style30" __designer:mapid="1a9">
                Kesesuaian tema penelitian yang diajukan dengan tema penelitian dalam rencana 
                            induk penelitian Fakultas, jurusan, program studi atau laboratorium.</td>
            <td class="style29" __designer:mapid="1aa">
                <asp:Label runat="server" ID="lblnilai2"></asp:Label>
            </td>
            <td class="style7" __designer:mapid="1ac">
                <asp:Label runat="server" ID="lblJustifikasi2"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="1ae">
            <td class="style30" __designer:mapid="1af">
                Kesesuaian tema penelitian yang diajukan dengan rencana induk penelitian pribadi 
                            peneliti.</td>
            <td class="style29" __designer:mapid="1b0">
                <asp:Label runat="server" ID="lblnilai3"></asp:Label>
            </td>
            <td class="style7" __designer:mapid="1b2">
                <asp:Label runat="server" ID="lblJustifikasi3"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="1b4">
            <td class="style30" __designer:mapid="1b5">
                Track record peneliti : kesesuaian dan kecukupan penelitian yang pernah 
                            dilakukan ketua peneliti terkait dengan tema penelitian yang diajukan.</td>
            <td class="style29" __designer:mapid="1b6">
                <asp:Label runat="server" ID="lblnilai4"></asp:Label>
            </td>
            <td class="style7" __designer:mapid="1b8">
                <asp:Label runat="server" ID="lblJustifikasi4"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="1ba">
            <td class="style30" __designer:mapid="1bb">
                Kesesuaian permasalahan dengan pendekatan atau metode penelitian yang dipilih.</td>
            <td class="style29" __designer:mapid="1bc">
                <asp:Label runat="server" ID="lblnilai5"></asp:Label>
            </td>
            <td class="style7" __designer:mapid="1be">
                <asp:Label runat="server" ID="lblJustifikasi5"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="1c0">
            <td class="style30" __designer:mapid="1c1">
                Kesesuaian penelitian dengan dana yang diajukan.</td>
            <td class="style29" __designer:mapid="1c2">
                <asp:Label runat="server" ID="lblnilai6"></asp:Label>
            </td>
            <td class="style7" __designer:mapid="1c4">
                <asp:Label runat="server" ID="lblJustifikasi6"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="1c6">
            <td class="style30" __designer:mapid="1c7">
                Rencana outcome berupa : adanya makalah seminar nasional, makalah seminar 
                            internasional, artikel jurnal terakreditasi nasional, artikel jurnal 
                            terakreditasi internasional, buku ajar, benda model atau paten.</td>
            <td class="style29" __designer:mapid="1c8">
                <asp:Label runat="server" ID="lblnilai7"></asp:Label>
            </td>
            <td class="style7" __designer:mapid="1ca">
                <asp:Label runat="server" ID="lblJustifikasi7"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="1cc">
            <td class="style31" style="text-align: right" __designer:mapid="1cd">
                Jumlah</td>
            <td class="style29" __designer:mapid="1ce">
                <asp:Label runat="server" ID="lbljumlah1"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="Panel1">
        Penilaian Oleh Review kedua :
        <table border="1px" class="GridViewStyle" style="width:100%;">
            <tr>
                <td class="style10">
                    Kriteria Penilaian</td>
                <td class="style33">
                    Nilai</td>
                <td class="style33">
                    Justifikasi_Penilaian</td>
            </tr>
            <tr>
                <td class="style30">
                    Originalitas penelitian : terlihat pada orisinalitas permasalahan, metode 
                                penelitian, tempat penelitian dan waktu penelitian.</td>
                <td class="style29">
                    <asp:Label runat="server" ID="lblnilai8"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label runat="server" ID="lblJustifikasi8"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style30">
                    Kesesuaian tema penelitian yang diajukan dengan tema penelitian dalam rencana 
                                induk penelitian Fakultas, jurusan, program studi atau laboratorium.</td>
                <td class="style29">
                    <asp:Label runat="server" ID="lblnilai9"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label runat="server" ID="lblJustifikasi9"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style30">
                    Kesesuaian tema penelitian yang diajukan dengan rencana induk penelitian pribadi 
                                peneliti.</td>
                <td class="style29">
                    <asp:Label runat="server" ID="lblnilai10"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label runat="server" ID="lblJustifikasi10"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style30">
                    Track record peneliti : kesesuaian dan kecukupan penelitian yang pernah 
                                dilakukan ketua peneliti terkait dengan tema penelitian yang diajukan.</td>
                <td class="style29">
                    <asp:Label runat="server" ID="lblnilai11"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label runat="server" ID="lblJustifikasi11"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style30">
                    Kesesuaian permasalahan dengan pendekatan atau metode penelitian yang dipilih.</td>
                <td class="style29">
                    <asp:Label runat="server" ID="lblnilai12"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label runat="server" ID="lblJustifikasi12"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style30">
                    Kesesuaian penelitian dengan dana yang diajukan.</td>
                <td class="style29">
                    <asp:Label runat="server" ID="lblnilai13"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label runat="server" ID="lblJustifikasi13"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style30">
                    Rencana outcome berupa : adanya makalah seminar nasional, makalah seminar 
                                internasional, artikel jurnal terakreditasi nasional, artikel jurnal 
                                terakreditasi internasional, buku ajar, benda model atau paten.</td>
                <td class="style29">
                    <asp:Label runat="server" ID="lblnilai14"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label runat="server" ID="lblJustifikasi14"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style31" style="text-align: right">
                    Jumlah</td>
                <td class="style29">
                    <asp:Label runat="server" ID="lbljumlah2"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
