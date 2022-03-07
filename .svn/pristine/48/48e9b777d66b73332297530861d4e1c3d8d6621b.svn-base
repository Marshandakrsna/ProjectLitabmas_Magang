<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="LihatPengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm32" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style15
    {
        font-size: 16px;
        color: #000066;
        background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        width: 526px;
        text-align: justify;
    }
    
        .style4
        {
            font-size: 16px;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
            text-align: left;
        }
        .style7
        {
            text-align: justify;
        }
        .style17
        {
            text-align: justify;
            width: 526px;
        }
    .style16
    {
        text-align: justify;
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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        Berikut hasil penilaian proposal anda :</p>
    <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="3" 
        Width="910px">
        <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
            <HeaderTemplate>
                Prodi
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
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Dekan
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
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
                Penilaian
            </HeaderTemplate>
            <ContentTemplate>
                <table border="1px" class="GridViewStyle" style="width:100%;">
                    <tr>
                        <td class="style15">
                            Kriteria Penilaian</td>
                        <td class="style4">
                            Nilai</td>
                        <td class="style4">
                            Justifikasi Penilaian</td>
                    </tr>
                    <tr>
                        <td class="style17">
                            1. Analisis SItuai (Kondisi eksisting mitra, persoalan yang dihadapi mitra)
                            <br />
                            Bobot: 20%</td>
                        <td class="style7">
                            <asp:Label ID="lblNilai1" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJusti1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            2. Permasalahan mitra (Kecocokan permasalahan spesifik yang dihadapi mitra dan 
                            program serta kompetisi tim)<br /> Bobot: 15%</td>
                        <td class="style7">
                            <asp:Label ID="lblNilai2" runat="server"></asp:Label>
                            <br />
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJusti2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            3. Solusi yang ditawarkan (Ketepatan metode pendekatan untuk mengatasi 
                            permasalahan, rencana kegiatan, dan kontribusi partisipasi mitra)<br /> Bobot: 
                            20%</td>
                        <td class="style7">
                            <asp:Label ID="lblNilai3" runat="server"></asp:Label>
                            <br />
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJusti3" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            4. Target Luaran (Jenis luaran output&amp;outcome dan spesifikasinya sesuai kegiatan 
                            yang diusulkan)<br /> Bobot: 15%</td>
                        <td class="style7">
                            <asp:Label ID="lblNilai4" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJusti4" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            5. Kelayakan TIM (Kuatilikasi tim pelaksana, relevansi skill tim, sinergisme 
                            tim, pengalaman kemasyarakatan, organisasi tim, jadwal kegiatan, kelengkapan 
                            lampiran)<br /> Bobot: 10%</td>
                        <td class="style7">
                            <asp:Label ID="lblNilai5" runat="server"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJusti5" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            Biaya Pekerjaan (Kelayakan usulan biaya, biaya program: Bahan habis, peralatan, 
                            perjalanan, dan lain-lain pengeluaran)<br /> Bobot: 20%</td>
                        <td class="style7">
                            <asp:Label ID="lblNilai6" runat="server"></asp:Label>
                            <br />
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblJusti6" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel2" runat="server">
                <br />
                <p>Catatan Oleh Review ke Dua :</p>
                    <table border="1px" class="GridViewStyle" style="width:100%;">
                        <tr>
                            <td class="style15">
                                Kriteria Penilaian</td>
                            <td class="style4">
                                Nilai</td>
                            <td class="style4">
                                Justifikasi Penilaian</td>
                        </tr>
                        <tr>
                            <td class="style17">
                                1. Analisis SItuai (Kondisi eksisting mitra, persoalan yang dihadapi mitra)
                                <br />
                                Bobot: 20%</td>
                            <td class="style7">
                                <asp:Label ID="lblNilai7" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJusti7" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                2. Permasalahan mitra (Kecocokan permasalahan spesifik yang dihadapi mitra dan 
                                program serta kompetisi tim)<br /> Bobot: 15%</td>
                            <td class="style7">
                                <asp:Label ID="lblNilai8" runat="server"></asp:Label>
                                <br />
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJusti8" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                3. Solusi yang ditawarkan (Ketepatan metode pendekatan untuk mengatasi 
                                permasalahan, rencana kegiatan, dan kontribusi partisipasi mitra)<br /> Bobot: 
                                20%</td>
                            <td class="style7">
                                <asp:Label ID="lblNilai9" runat="server"></asp:Label>
                                <br />
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJusti9" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                4. Target Luaran (Jenis luaran output&amp;outcome dan spesifikasinya sesuai kegiatan 
                                yang diusulkan)<br /> Bobot: 15%</td>
                            <td class="style7">
                                <asp:Label ID="lblNilai10" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJusti10" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                5. Kelayakan TIM (Kuatilikasi tim pelaksana, relevansi skill tim, sinergisme 
                                tim, pengalaman kemasyarakatan, organisasi tim, jadwal kegiatan, kelengkapan 
                                lampiran)<br /> Bobot: 10%</td>
                            <td class="style7">
                                <asp:Label ID="lblNilai11" runat="server"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJusti11" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                Biaya Pekerjaan (Kelayakan usulan biaya, biaya program: Bahan habis, peralatan, 
                                perjalanan, dan lain-lain pengeluaran)<br /> Bobot: 20%</td>
                            <td class="style7">
                                <asp:Label ID="lblNilai12" runat="server"></asp:Label>
                                <br />
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblJusti12" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </asp:Panel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Catatan Penilai
            </HeaderTemplate>
            <ContentTemplate>
                <table border="1px" class="GridViewStyle" style="width:100%;">
                    <tr>
                        <td class="style4" colspan="2">
                            Catatan Penilai</td>
                    </tr>
                    <tr>
                        <td class="style16">
                            Kekuatan atau keunikan proposal ini
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblCatatan1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style16">
                            Beberapa Argumentasi kunci yang digunakan dalam penilaian proposal ini</td>
                        <td class="style7">
                            <asp:Label ID="lblCatatan2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style16">
                            Dokumen-dokumen yang perlu dilampirkan sebagai tambahan</td>
                        <td class="style7">
                            <asp:Label ID="lblCatatan3" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style16">
                            Beberapa ide yang ditambahkan untuk memperkaya atau meningkatkan kualitas 
                            proposal ini</td>
                        <td class="style7">
                            <asp:Label ID="lblCatatan4" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style16">
                            Tambahan lain-lain</td>
                        <td class="style7">
                            <asp:Label ID="lblCatatan5" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" colspan="2">
                            Catatan Akhir :</td>
                    </tr>
                    <tr>
                        <td class="style17">
                            Kesimpulan penilai proposal ini
                        </td>
                        <td class="style7">
                            <asp:Label ID="lblKesimpulan" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            Anggaran yang disarankan untuk disetujui adalah</td>
                        <td class="style7">
                            <asp:Label ID="lblAnggaran" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            &nbsp;</td>
                        <td class="style7">
                            <asp:Label ID="lblAnggaranHuruf" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            Usulan ini memiliki keunikan</td>
                        <td class="style7">
                            <asp:Label ID="lblUsulan" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server">
                <br />
                <p>Catatan Oleh Review ke Dua :</p>
                    <table border="1px" class="GridViewStyle" style="width:100%;">
                        <tr>
                            <td class="style4" colspan="2">
                                Catatan Penilai</td>
                        </tr>
                        <tr>
                            <td class="style16">
                                Kekuatan atau keunikan proposal ini
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblCatatan6" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style16">
                                Beberapa Argumentasi kunci yang digunakan dalam penilaian proposal ini</td>
                            <td class="style7">
                                <asp:Label ID="lblCatatan7" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style16">
                                Dokumen-dokumen yang perlu dilampirkan sebagai tambahan</td>
                            <td class="style7">
                                <asp:Label ID="lblCatatan8" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style16">
                                Beberapa ide yang ditambahkan untuk memperkaya atau meningkatkan kualitas 
                                proposal ini</td>
                            <td class="style7">
                                <asp:Label ID="lblCatatan9" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style16">
                                Tambahan lain-lain</td>
                            <td class="style7">
                                <asp:Label ID="lblCatatan10" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4" colspan="2">
                                Catatan Akhir :</td>
                        </tr>
                        <tr>
                            <td class="style17">
                                Kesimpulan penilai proposal ini
                            </td>
                            <td class="style7">
                                <asp:Label ID="lblKesimpulan0" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                Anggaran yang disarankan untuk disetujui adalah</td>
                            <td class="style7">
                                <asp:Label ID="lblAnggaran0" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                &nbsp;</td>
                            <td class="style7">
                                <asp:Label ID="lblAnggaranHuruf0" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                Usulan ini memiliki keunikan</td>
                            <td class="style7">
                                <asp:Label ID="lblUsulan0" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </asp:Panel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        
        <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
            <HeaderTemplate>
                KA LPPM
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
        </ajaxToolkit:TabPanel>
        
    </ajaxToolkit:TabContainer>

</asp:Content>
