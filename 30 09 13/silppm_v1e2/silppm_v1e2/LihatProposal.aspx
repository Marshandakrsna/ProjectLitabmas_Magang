<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="LihatProposal.aspx.cs" Inherits="silppm_v1e2.WebForm17" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style10
        {
          
            text-align: center;
       
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
            top: 0px;
            left: 110px;
            z-index: -1;
        }
        .style7
        {
            text-align: left;
        }
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
        .style29
        {
            text-align: left;
            width: 23px;
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
        .style31
        {
            width: 541px;
        }
        .style33
        {
            text-align: left;
            
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Berikut detail Proposal anda :<br />
    </p>

   
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
        Width="911px">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                PRODI
            </HeaderTemplate>
         <ContentTemplate>
             <asp:Panel ID="Panel3" runat="server">
                 <table border="1" class="GridViewStyle" style="width:100%;">
                     <tr>
                         <td class="style10">
                             Tanggal</td>
                         <td class="style10">
                             Komentar</td>
                         <td class="style10">
                             Status</td>
                     </tr>
                     <tr>
                         <td>
                             <asp:Label ID="lblTglProdi" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lblFeedBackProdi" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lblProdiStatus" runat="server"></asp:Label>
                         </td>
                     </tr>
                 </table>
             </asp:Panel>
             <br />
             <br />
             <asp:Label ID="lblSetuju1" runat="server" Visible="False">Prodi Telah Menyetujui Proposal</asp:Label>
             <br />
             <asp:Label ID="lblSetuju" runat="server" Visible="False">Status : Menunggu Persetujuan Dekan</asp:Label>
             <br />
        </ContentTemplate>
        
        
   
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                DEKAN
            </HeaderTemplate>
            
       
            <ContentTemplate>
                <asp:Panel ID="Panel4" runat="server">
                    <table border="1" class="GridViewStyle" style="width:100%;">
                        <tr>
                            <td class="style10">
                                Tanggal</td>
                            <td class="style10">
                                Komentar</td>
                            <td class="style10">
                                Status</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTglDekan" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFeedBackDekan" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDekanStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <br />
                <asp:Label ID="lblSetuju3" runat="server" Visible="False">Dekan Telah Menyetujui Proposal</asp:Label>
                <br />
                <asp:Label ID="lblSetuju2" runat="server" Visible="False">Menunggu Review Oleh LPPM</asp:Label>
            </ContentTemplate>
            
       
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Skor Penilaian Review
            </HeaderTemplate>
            <ContentTemplate>

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
                            <asp:Label ID="lblnilai1" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJustifikasi1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            Kesesuaian tema penelitian yang diajukan dengan tema penelitian dalam rencana 
                            induk penelitian Fakultas, jurusan, program studi atau laboratorium.</td>
                        <td class="style29">
                            <asp:Label ID="lblnilai2" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJustifikasi2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            Kesesuaian tema penelitian yang diajukan dengan rencana induk penelitian pribadi 
                            peneliti.</td>
                        <td class="style29">
                            <asp:Label ID="lblnilai3" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJustifikasi3" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            Track record peneliti : kesesuaian dan kecukupan penelitian yang pernah 
                            dilakukan ketua peneliti terkait dengan tema penelitian yang diajukan.</td>
                        <td class="style29">
                            <asp:Label ID="lblnilai4" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJustifikasi4" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            Kesesuaian permasalahan dengan pendekatan atau metode penelitian yang dipilih.</td>
                        <td class="style29">
                            <asp:Label ID="lblnilai5" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJustifikasi5" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            Kesesuaian penelitian dengan dana yang diajukan.</td>
                        <td class="style29">
                            <asp:Label ID="lblnilai6" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJustifikasi6" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            Rencana outcome berupa : adanya makalah seminar nasional, makalah seminar 
                            internasional, artikel jurnal terakreditasi nasional, artikel jurnal 
                            terakreditasi internasional, buku ajar, benda model atau paten.</td>
                        <td class="style29">
                            <asp:Label ID="lblnilai7" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJustifikasi7" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style31" style="text-align: right">
                            Jumlah</td>
                        <td class="style29">
                            <asp:Label ID="lbljumlah1" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <table style="width:100%;">
                        <tr>
                            <td class="style23">
                                Revisi dilakukan Oleh
                            </td>
                            <td>
                                <asp:Label ID="lblReveiewer1" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style23">
                                Status</td>
                            <td>
                                <asp:Label ID="lblStatus1" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style23">
                                Biaya yang diRekomendasikan</td>
                            <td>
                                <asp:Label ID="llblBiayaRekomen1" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style24">
                                Biaya disetujui
                            </td>
                            <td class="style25">
                                <asp:Label ID="lblBiayaSetuju1" runat="server"></asp:Label>
                            </td>
                            <td class="style25">
                            </td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>
                <br />
                <asp:Panel ID="Panel1" runat="server">
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
                                <asp:Label ID="lblnilai8" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJustifikasi8" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                Kesesuaian tema penelitian yang diajukan dengan tema penelitian dalam rencana 
                                induk penelitian Fakultas, jurusan, program studi atau laboratorium.</td>
                            <td class="style29">
                                <asp:Label ID="lblnilai9" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJustifikasi9" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                Kesesuaian tema penelitian yang diajukan dengan rencana induk penelitian pribadi 
                                peneliti.</td>
                            <td class="style29">
                                <asp:Label ID="lblnilai10" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJustifikasi10" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                Track record peneliti : kesesuaian dan kecukupan penelitian yang pernah 
                                dilakukan ketua peneliti terkait dengan tema penelitian yang diajukan.</td>
                            <td class="style29">
                                <asp:Label ID="lblnilai11" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJustifikasi11" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                Kesesuaian permasalahan dengan pendekatan atau metode penelitian yang dipilih.</td>
                            <td class="style29">
                                <asp:Label ID="lblnilai12" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJustifikasi12" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                Kesesuaian penelitian dengan dana yang diajukan.</td>
                            <td class="style29">
                                <asp:Label ID="lblnilai13" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJustifikasi13" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                Rencana outcome berupa : adanya makalah seminar nasional, makalah seminar 
                                internasional, artikel jurnal terakreditasi nasional, artikel jurnal 
                                terakreditasi internasional, buku ajar, benda model atau paten.</td>
                            <td class="style29">
                                <asp:Label ID="lblnilai14" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJustifikasi14" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style31" style="text-align: right">
                                Jumlah</td>
                            <td class="style29">
                                <asp:Label ID="lbljumlah2" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
            <HeaderTemplate>
                KALPPM
            </HeaderTemplate>
            <ContentTemplate>
                <asp:Panel ID="Panel5" runat="server">
                    <table border="1" class="GridViewStyle" style="width:100%;">
                        <tr>
                            <td class="style10">
                                Tanggal</td>
                            <td class="style10">
                                Komentar</td>
                            <td class="style10">
                                Status</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTglDekan0" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFeedBackDekan0" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDekanStatus0" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Label ID="lblSetuju4" runat="server" Visible="False">KALPPM Telah Menyetujui Proposal</asp:Label>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    <br />
    
    </asp:Content>
