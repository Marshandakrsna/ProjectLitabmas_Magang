<%@ Page Title="" Language="C#" MasterPageFile="~/ReviewerMaster.Master" AutoEventWireup="true" CodeBehind="REVPengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm14" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style4
        {
            font-size: 16px;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
            text-align: left;
        }
        .style8
        {
            width: 162px;
        }
        .style12
        {
            text-align: justify;
        }
        .style9
        {
            width: 162px;
            height: 23px;
        }
        .style10
        {
            height: 23px;
        }
        .style14
        {

            text-align: center;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');        
            }
        .style11
        {
            text-align: left;
        }
        .style7
        {
            text-align: justify;
        }
        .style15
    {
        font-size: 16px;
        color: #000066;
        background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        width: 349px;
        text-align: justify;
    }
    .style16
    {
        text-align: justify;
    }
        .style18
        {
            text-align: justify;
            width: 330px;
        }
        .style19
        {
            width: 330px;
            text-align: right;
        }
        .style20
        {
            font-size: 16px;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
            text-align: left;
            width: 40px;
        }
        .style21
        {
            width: 40px;
            height: 23px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
   
    <asp:Panel ID="panelConfirm" runat="server">
        <table style="Background-color:White; width:100%; " border="1px" 
    class="GridViewStyle">
            <tr>
                <td colspan="3" style="text-align: center" class="style4">
                    <strong>LEMBAR EVALUASI PROPOSAL PENGABDIAN UAJY</strong></td>
            </tr>
            <tr>
                <td class="style8">
                    Periode Penelitian</td>
                <td colspan="2">
                    <asp:Label ID="lblPeriode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Judul Kegiatan Pengabdian</td>
                <td colspan="2">
                    <asp:Label ID="lblJudul" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Judul Penelitian yang digunakan sebagai landasan kegiatan yang diusulkan ini</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblLandasan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Jenis Pengabdian</td>
                <td colspan="2">
                    <asp:Label ID="lblJenis" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Pengusul</td>
                <td colspan="2">
                    <asp:Label ID="lblNamaKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    NIDN</td>
                <td colspan="2">
                    <asp:Label ID="lblNIDNKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    NIP/NPP</td>
                <td class="style10" colspan="2">
                    <asp:Label ID="lblNPPKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Pangkat/Golongan</td>
                <td colspan="2">
                    <asp:Label ID="lblPangkatKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                    ,<asp:Label ID="lblGolKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Unit/Fakultas/Jurusan</td>
                <td colspan="2">
                    <asp:Label ID="lblFakKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                    ,<asp:Label ID="lblJurusanKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Bidang Keahlian</td>
                <td colspan="2">
                    <asp:Label ID="lblKeahlianKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Alamat Kantor</td>
                <td colspan="2">
                    <asp:Label ID="lblAlamatKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Alamat Rumah</td>
                <td colspan="2">
                    <asp:Label ID="lblTelpKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Anggota Tim</td>
                <td class="style14">
                    Nama</td>
                <td class="style14">
                    Bidang Keahlian</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="lblNama1" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblBidang1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="lblNama2" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblBidang2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Mitra Kerjasama atau Mitra Sasaran</td>
                <td class="style12">
                    <asp:Label ID="lblMitra" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblKeahlianMitra" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Lokasi Kegiatan</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblLokasi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Jarak PT ke lokasi kegiatan pengabdian</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblJarak" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Luaran (Output) yang dihasilkan</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Luaran (Outcome) yang dihasilkan</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblOutcome" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Jangka waktu dan durasi pelaksanaan kegiatan</td>
                <td class="style12">
                    <asp:Label ID="lblWaktu" runat="server"></asp:Label>
                </td>
                <td>
                    Berakhir sampai dengan :
                    <asp:Label ID="lblAkhir" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Sasaran</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblSasaran" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Beban SKS</td>
                <td class="style12">
                    Ketua :
                    <asp:Label ID="lblSksKetua" runat="server"></asp:Label>
                </td>
                <td>
                    Anggota :<asp:Label ID="lblSksAnggota" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Topik Pengabdian sesuai dengan rencana unit</td>
                <td class="style12" colspan="2">
                    <asp:Label ID="lblUnit" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8" rowspan="2">
                    Dana yang diusulkan</td>
                <td class="style14">
                    Dari UAJY</td>
                <td class="style14" style="text-align: center">
                    Dari Pribadi pengusul</td>
            </tr>
            <tr>
                <td class="style12">
                    Rp
                    <asp:Label ID="lblDanaUajy" runat="server"></asp:Label>
                </td>
                <td>
                    Rp
                    <asp:Label ID="lblDanaPengusul" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Dokumen</td>
                <td class="style11">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Lihat Proposal</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <table style="width:100%;" border="1px" 
        class="GridViewStyle">
            <tr>
                <td class="style15">
                    Kriteria Penilaian</td>
                <td class="style4">
                    Skor</td>
                <td class="style20">
                    Nilai</td>
                <td class="style4">
                    Justifikasi Penilaian</td>
            </tr>
            <tr>
                <td class="style16">
                    1. Analisis SItuai (Kondisi eksisting mitra, persoalan yang dihadapi mitra)
                    <br />
                    Bobot: 20%</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style21">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger controlid="DropDownList1" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti1" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="447px" style="margin-right: 4px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    2. Permasalahan mitra (Kecocokan permasalahan spesifik yang dihadapi mitra dan 
                    program serta kompetisi tim)<br /> Bobot: 15%</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style21">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger controlid="DropDownList2" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti2" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="447px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    3. Solusi yang ditawarkan (Ketepatan metode pendekatan untuk mengatasi 
                    permasalahan, rencana kegiatan, dan kontribusi partisipasi mitra)<br /> Bobot: 20%</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style21">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger controlid="DropDownList3" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti3" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="447px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    4. Target Luaran (Jenis luaran output&amp;outcome dan spesifikasinya sesuai kegiatan 
                    yang diusulkan)<br /> Bobot: 15%</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList4_SelectedIndexChanged">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style21">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label4" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger controlid="DropDownList4" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti4" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="447px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    5. Kelayakan TIM (Kuatilikasi tim pelaksana, relevansi skill tim, sinergisme 
                    tim, pengalaman kemasyarakatan, organisasi tim, jadwal kegiatan, kelengkapan 
                    lampiran)<br /> Bobot: 10%</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList5_SelectedIndexChanged">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style21">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label5" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger controlid="DropDownList5" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti5" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="447px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    Biaya Pekerjaan (Kelayakan usulan biaya, biaya program: Bahan habis, peralatan, 
                    perjalanan, dan lain-lain pengeluaran)<br /> Bobot: 20%</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList6_SelectedIndexChanged">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style21">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label6" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger controlid="DropDownList6" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti6" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="447px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16" colspan="2">
                    Jumlah</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label7" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    &nbsp;Passing Grade : 70% * 700 = 490.&nbsp;</td>
            </tr>
            <tr>
                <td class="style16">
                    Skor yang diberikan :</td>
                <td class="style7" colspan="3">
                    1 (Sangat Buruk Sekali)<br /> 2 (Buruk Sekali)<br /> 3 (Buruk)<br /> 5 (Baik)<br /> 
                    6 (Baik Sekali)<br /> 7 (Istimewa)</td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
        <table style="width:100%;" border="1px" 
        class="GridViewStyle">
            <tr>
                <td class="style4" colspan="2">
                    Catatan Penilai</td>
            </tr>
            <tr>
                <td class="style18">
                    Kekuatan atau keunikan proposal ini
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtCatatan1" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="562px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Beberapa Argumentasi kunci yang digunakan dalam penilaian proposal ini</td>
                <td class="style7">
                    <asp:TextBox ID="txtCatatan2" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="562px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Dokumen-dokumen yang perlu dilampirkan sebagai tambahan</td>
                <td class="style7">
                    <asp:TextBox ID="txtCatatan3" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="562px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Beberapa ide yang ditambahkan untuk memperkaya atau meningkatkan kualitas 
                    proposal ini</td>
                <td class="style7">
                    <asp:TextBox ID="txtCatatan4" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="562px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    Tambahan lain-lain</td>
                <td class="style7">
                    <asp:TextBox ID="txtCatatan5" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="562px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    Catatan Akhir :</td>
            </tr>
            <tr>
                <td class="style19">
                    Kesimpulan penilai proposal ini
                </td>
                <td class="style7">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>Disetujui tanpa perbaikan</asp:ListItem>
                        <asp:ListItem>Disetujui dengan perbaikan sesuai saran</asp:ListItem>
                        <asp:ListItem>Ditolak</asp:ListItem>
                        <asp:ListItem>Disarankan dirombak dan diusulkan pada periode berikutnya</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Anggaran yang disarankan untuk disetujui adalah</td>
                <td class="style7">
                    Rp
                    <asp:TextBox ID="txtAnggaran" runat="server"></asp:TextBox>
                    ,- </td>
            </tr>
            <tr>
                <td class="style19">
                    &nbsp;</td>
                <td class="style7">
                    Tuliskan Dengan Huruf:<asp:TextBox ID="txtAnggaranHuruf" runat="server" 
                        Height="24px" Width="420px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Usulan ini memiliki keunikan</td>
                <td class="style7">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                        <asp:ListItem>Tidak Berpotensi KKN</asp:ListItem>
                        <asp:ListItem>Berpotensi KKN jika program ini dan mahasiswa peserta kegiatan ini memenuhi beberapa syarat KKN yang diatur dalam pelaksanaan KKN</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    &nbsp;</td>
                <td class="style7">
                    <asp:Button ID="btnSave" runat="server" Text="Simpan" onclick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
