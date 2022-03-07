<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true"
    CodeBehind="HomePengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm3" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            font-size: 14px;
            background-color: #FFFF99;
        }
        .style8
        {
            text-align: justify;
        }
        .style9
        {
            width: 208px;
            height: 23px;
        }
        .style10
        {
            height: 23px;
        }
        .style12
        {
            text-align: justify;
        }
        .style4
        {
            text-align: center;
            font-size: 16px;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        }
        #mapCanvas
        {
            width: 600px;
            height: 300px;
            float: left;
        }
        #infoPanel
        {
            float: left;
            margin-left: 10px;
        }
        #infoPanel div
        {
            margin-bottom: 5px;
        }
        .style13
        {
            text-align: justify;
            width: 208px;
        }
    </style>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCDO19UiZ_tabbU4p6FerT0H_3XPloY020&sensor=false">
    </script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places">
    </script>
    <script type="text/javascript">
        //window.onload = initialize;
        var geocoder = new google.maps.Geocoder();

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(initialize);
        } else {
            alert("Geo Location is not supported on your current browser!");
        }
        function geocodePosition(pos) {
            geocoder.geocode({
                latLng: pos
            }, function (responses) {
                if (responses && responses.length > 0) {
                    updateMarkerAddress(responses[0].formatted_address);
                } else {
                    updateMarkerAddress('Cannot determine address at this location.');
                }
            });
        }

        function updateMarkerStatus(str) {
            document.getElementById('markerStatus').innerHTML = str;
        }

        function updateMarkerPosition(latLng) {
            document.getElementById('info').innerHTML = [
        latLng.lat(),
        latLng.lng()
        ].join(', ');

        }
        function updateLabelDalemWeb(latLing) {

        }

        function updateMarkerAddress(str) {
            document.getElementById('address').innerHTML = str;
        }

        function initialize(position) {
            var lat = position.coords.latitude;
            var long = position.coords.longitude;

            var latLng = new google.maps.LatLng(lat, long);

            //var latLng = new google.maps.LatLng(-34.397, 150.644);
            var map = new google.maps.Map(document.getElementById('mapCanvas'), {
                zoom: 12,
                center: latLng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            var marker = new google.maps.Marker({
                position: latLng,
                title: 'Point A',
                map: map,
                draggable: true
            });



            // Update current position info.
            updateMarkerPosition(latLng);
            geocodePosition(latLng);

            // Add dragging event listeners.
            google.maps.event.addListener(marker, 'dragstart', function () {
                updateMarkerAddress('Dragging...');
            });

            google.maps.event.addListener(marker, 'drag', function () {
                updateMarkerStatus('Dragging...');
                updateMarkerPosition(marker.getPosition());
            });

            google.maps.event.addListener(marker, 'dragend', function () {
                updateMarkerStatus('Drag ended');
                geocodePosition(marker.getPosition());
            });
            updateLabelDalemWeb(latLng);
        }



        // Onload handler to fire off the app.
        google.maps.event.addDomListener(window, 'load', initialize);
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager runat="server" ID="TSM_SPD">
    </asp:ToolkitScriptManager>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
        Width="100%">
        <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Data Penelitian">
            <HeaderTemplate>
                Data Pengabdian
            </HeaderTemplate>
            <ContentTemplate>
                <table style="background-color: White; width: 100%;" border="1px" class="GridViewStyle">
                    <tr>
                        <td class="style13">
                            Periode Penelitian
                        </td>
                        <td>
                            <asp:Label ID="lblPeriode" runat="server"></asp:Label>
                        </td>
                    </tr><tr>
                            <td class="style15">
                                Tahun Akademik
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTahun" runat="server" 
                                    OnSelectedIndexChanged="ddlTahun_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                Semester Akademik
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSemester" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    <tr>
                        <td class="style15">
                            Skim PENGABDIAN
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSkim" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSkim_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Judul Kegiatan Pengabdian
                        </td>
                        <td>
                            <asp:TextBox ID="txtJudul" runat="server" Width="532px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Judul Penelitian yang digunakan sebagai landasan kegiatan yang diusulkan ini
                        </td>
                        <td class="style12">
                            <asp:TextBox ID="txtJudulPenelitian" runat="server" Width="532px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            Tema Universitas
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTema" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                            Topik sesuai dengan rencana unit
                        </td>
                        <td>
                                <asp:DropDownList ID="ddLRencanaUnit" runat="server" OnSelectedIndexChanged="ddLRencanaUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Jenis Pengabdian
                        </td>
                        <td>
                            <asp:Label ID="lblJenisPengabdian" runat="server" Text="Jenis Pengabdian"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="panelBawah" runat="server">
                    <table style="background-color: White; width: 100%;" border="1px" class="GridViewStyle">
                        <tr>
                            <td class="style13">
                                &nbsp;
                            </td>
                            <td class="style4">
                                Nama
                            </td>
                            <td class="style4">
                                Bidang Keahlian
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                Mitra Kerjasama atau Mitra Sasaran
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="txtNamaMitra" runat="server" Width="340px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeahlianMitra" runat="server" Width="340px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                Lokasi Kegiatan
                            </td>
                            <td class="style12" colspan="2">
                                <asp:TextBox ID="txtLokasi" runat="server" Width="625px" Height="24px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8" colspan="3">
                                <div id="mapCanvas">
                                </div>
                                <div id="infoPanel">
                                    <b>Marker status:</b>
                                    <div id="markerStatus">
                                        <i>Click and drag the marker.</i></div>
                                    <b>Current position:</b>
                                    <div id="info">
                                    </div>
                                    <b>Closest matching address:</b>
                                    <div id="address">
                                    </div>
                                </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                Jarak PT ke lokasi kegiatan pengabdian
                            </td>
                            <td class="style12" colspan="2">
                                <asp:TextBox ID="txtJarak" runat="server" Width="625px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                Luaran (Output) yang dihasilkan
                            </td>
                            <td class="style12" colspan="2">
                                <asp:TextBox ID="txtOutput" runat="server" Width="625px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                Outcome
                            </td>
                            <td class="style12" colspan="2">
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Enabled="False" Text="Laporan" />
                                <br />
                                <asp:CheckBox ID="CheckBox7" runat="server" Checked="True" Enabled="False" Text="Jurnal/Prosiding" />
                                <br />
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Desain" />
                                <br />
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="Model" />
                                <br />
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="Software" />
                                <br />
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="Alat" />
                                <br />
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="Lainnya :" />
                                <asp:TextBox ID="txtTrackRecord" runat="server" Width="436px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                Tanggal Mulai Pengabdian
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="dateMulai" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dateMulai"
                                    Enabled="True" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" TargetControlID="dateMulai" Mask="99/99/9999"
                                    MaskType="Date" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True" />
                           <asp:TextBox ID="tanggal_selesai" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tanggal_selesai"
                                    Enabled="True" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="tanggal_selesai"
                                    Mask="99/99/9999" MaskType="Date" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True" />
                            </td>
                            <td>
                                Durasi efektif :<asp:DropDownList ID="dateSelesai" runat="server">
                                    <asp:ListItem Value="1">1 bulan</asp:ListItem>
                                    <asp:ListItem Value="2">2 bulan</asp:ListItem>
                                    <asp:ListItem Value="3">3 bulan</asp:ListItem>
                                    <asp:ListItem Value="4">4 bulan</asp:ListItem>
                                    <asp:ListItem Value="5">5 bulan</asp:ListItem>
                                    <asp:ListItem Value="6">6 bulan</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                Sasaran
                            </td>
                            <td class="style12" colspan="2">
                                <asp:TextBox ID="txtSasaran" runat="server" Width="625px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                Beban SKS
                            </td>
                            <td class="style12">
                                Ketua :
                                <asp:TextBox ID="txtSksKetua" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSksKetua"
                                    ErrorMessage="*hanya boleh diisi angka" ForeColor="Red" ValidationExpression="^\d+$"
                                    ValidationGroup="check"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Panel ID="panelSksAnggota" runat="server">
                                    Anggota :<asp:TextBox ID="txtSksAnggota" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSksAnggota"
                                        ErrorMessage="*hanya boleh diisi angka" ForeColor="Red" ValidationExpression="^\d+$"
                                        ValidationGroup="check"></asp:RegularExpressionValidator>
                                </asp:Panel>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td class="style13" rowspan="2">
                                Dana yang diusulkan
                            </td>
                            <td class="style4">
                                Dari UAJY
                            </td>
                            <td class="style4" style="text-align: center">
                                Dari Pribadi pengusul
                            </td>
                        </tr>--%>
                        <%--<tr>
                            <td class="style12">
                                Rp
                                <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="check"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4"
                                    ErrorMessage="*hanya boleh diisi angka" ForeColor="Red" ValidationExpression="^\d+$"
                                    ValidationGroup="check"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                Rp
                                <asp:TextBox ID="TextBox5" runat="server" ValidationGroup="check" Width="140px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5"
                                    ErrorMessage="*hanya boleh diisi angka" ForeColor="Red" ValidationExpression="^\d+$"
                                    ValidationGroup="check"></asp:RegularExpressionValidator>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="style13">
                                Dokumen
                            </td>
                            <td class="style12">
                                Format : PENGABDIAN_XX_YYYYY.pdf
                                <br />
                                X=Penelitian Ke-<br />
                                Y= 5 Digit Belakang NPP<br />
                                <asp:FileUpload ID="FileUpload1" runat="server" Style="text-align: left" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="BtnSimpan" runat="server" Text="Simpan" OnClick="BtnSimpan_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Identitas Pengusul">
            <ContentTemplate>
                <table>
                    <tr>
                        <td class="style13">
                            Pengusul
                        </td>
                        <td>
                            <asp:Label ID="lblNamaKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            NIDN
                        </td>
                        <td>
                            <asp:Label ID="lblNIDNKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style9">
                            NIP/NPP
                        </td>
                        <td class="style10">
                            <asp:Label ID="lblNPPKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Jabatan/Golongan
                        </td>
                        <td>
                            <asp:Label ID="lblGolonganKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Unit/Fakultas/Jurusan
                        </td>
                        <td>
                            <asp:Label ID="lblFakKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                            ,
                            <asp:Label ID="lblJurusanKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Bidang Keahlian
                        </td>
                        <td>
                            <asp:Label ID="lblKeahlian" runat="server" Text="Tidak Tersedia"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Alamat Kantor
                        </td>
                        <td>
                            <asp:Label ID="lblAlamatKantor" runat="server" Text="Tidak Tersedia"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Alamat Rumah
                        </td>
                        <td>
                            <asp:Label ID="lblAlamatKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnlAnggotaKelompok" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvAnggota" runat="server" CssClass="GridViewStyle" OnRowDataBound="gvAnggota_RowDataBound"
                                OnRowCommand="gvAnggota_RowCommand" PageSize="100" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="No" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_no_urut" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="grid_header" HorizontalAlign="Left" VerticalAlign="Top" Width="30px" />
                                        <ItemStyle CssClass="grid_cell" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle"
                                            Width="30px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NPP" HeaderText="NPP" />
                                    <asp:BoundField DataField="NAMA_LENGKAP_GELAR" HeaderText="NAMA" />
                                    <asp:BoundField DataField="INSTITUSI_ASAL" HeaderText="INSTITUSI" />
                                    <asp:BoundField DataField="BIDANG_KEAHLIAN_PENGABDIAN" HeaderText="KEAHLIAN" />
                                    <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />
                                    <asp:BoundField DataField="NO_TELPON_RUMAH" HeaderText="TELP RUMAH" />
                                    <asp:BoundField DataField="NO_TELPON_HP" HeaderText="HP" />
                                    <asp:BoundField DataField="ALAMAT" HeaderText="ALAMAT" />
                                </Columns>
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="btnAnggota" runat="server" Text="Tambah Anggota non UAJY" />
                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" Enabled="True" TargetControlID="btnAnggota"
                        PopupControlID="pnlAnggota" DynamicServicePath="">
                    </asp:ModalPopupExtender>
                    <asp:Button ID="btnAnggota0" runat="server" Text="Tambah Anggota UAJY" />
                    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnAnggota0"
                        PopupControlID="panelKaryawan" DynamicServicePath="" Enabled="True">
                    </asp:ModalPopupExtender>
                </asp:Panel>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="RAB">
            <ContentTemplate>
                <table style="background-color: White; width: 100%;" border="1px" class="GridViewStyle">
                    <tr>
                        <td class="style14" style="text-align: center">
                        </td>
                        <td class="style14" style="text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                            Dana UAJY
                        </td>
                        <td class="style5">
                            Rp
                            <asp:TextBox ID="txtDanaUajy" runat="server" ValidationGroup="check" 
                                AutoPostBack="True" ontextchanged="txtDanaUajy_TextChanged">0</asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDanaUajy"
                                FilterType="Custom, Numbers" Enabled="True" />
                            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtDanaUajy0" runat="server" AutoPostBack="True" 
                                ontextchanged="txtDanaUajy_TextChanged" ValidationGroup="check" Visible="False"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtDanaUajy0_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                TargetControlID="txtDanaUajy0">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                            Dana Pribadi
                        </td>
                        <td>
                            Rp
                            <asp:TextBox ID="txtDanaPribadi" runat="server" ValidationGroup="check" 
                                Width="140px" AutoPostBack="True" ontextchanged="txtDanaUajy_TextChanged">0</asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtDanaPribadi"
                                FilterType="Custom, Numbers" Enabled="True" />
                            <asp:TextBox ID="txtDanaPribadi0" runat="server" AutoPostBack="True" 
                                ontextchanged="txtDanaUajy_TextChanged" ValidationGroup="check" Visible="False" 
                                Width="140px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtDanaPribadi0_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                TargetControlID="txtDanaPribadi0">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                                <asp:Label ID="lbl2" runat="server" Visible="False"></asp:Label>
                            Dana Eksternal
                        </td>
                        <td>
                            Rp
                            <asp:TextBox ID="txtDanaEks" runat="server" ValidationGroup="check" 
                                Width="140px" AutoPostBack="True" ontextchanged="txtDanaUajy_TextChanged">0</asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtDanaEks"
                                FilterType="Custom, Numbers" Enabled="True" />
                            <asp:TextBox ID="txtDanaEks0" runat="server" AutoPostBack="True" 
                                ontextchanged="txtDanaUajy_TextChanged" ValidationGroup="check" Visible="False" 
                                Width="140px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtDanaEks0_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                TargetControlID="txtDanaEks0">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                            Dana Kerjasama
                        </td>
                        <td>
                            Rp
                            <asp:TextBox ID="txtDanaKerjasama" runat="server" ValidationGroup="check" 
                                Width="140px" AutoPostBack="True" ontextchanged="txtDanaUajy_TextChanged">0</asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtDanaKerjasama"
                                FilterType="Custom, Numbers" Enabled="True" />
                            <asp:TextBox ID="txtDanaKerjasama0" runat="server" AutoPostBack="True" 
                                ontextchanged="txtDanaUajy_TextChanged" ValidationGroup="check" Visible="False" 
                                Width="140px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtDanaKerjasama0_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                TargetControlID="txtDanaKerjasama0">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnDtlRab" runat="server" Style="display: none" OnClick="btnDtlRab_Click" />
                <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" Enabled="True" TargetControlID="btnDtlRab"
                    PopupControlID="pnlDetailRAB" DynamicServicePath="">
                </asp:ModalPopupExtender>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvRab" runat="server" CssClass="GridViewStyle"
                         DataKeyNames="ID_RAB_PENGABDIAN"   OnRowCommand="gvRab_RowCommand" 
                            PageSize="100" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="No" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_no_urut" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Left" VerticalAlign="Top" Width="30px" />
                                    <ItemStyle CssClass="grid_cell" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle"
                                        Width="30px" />
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="ID_RAB_PENELITIAN" HeaderText="ID_RAB_PENELITIAN" />
                                    <asp:BoundField DataField="ID_PROPOSAL" HeaderText="ID_PROPOSAL" />--%>
                                <asp:BoundField DataField="DESKRIPSI" HeaderText="DESKRIPSI" />
                                <asp:BoundField DataField="JUMLAH_DANA" HeaderText="JUMLAH_DANA" DataFormatString="{0:n2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MIN_PCT" HeaderText="MIN" DataFormatString="{0:n2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MAX_PCT" HeaderText="MAX" DataFormatString="{0:n2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PERSENTASE" HeaderText="PERSENTASE" DataFormatString="{0:n2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="PERSENTASE">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPERSENTASE" runat="server" Text='<%#Eval("PERSENTASE")%>'></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtPERSENTASE"
                                            FilterType="Custom, Numbers" ValidChars="," Enabled="True" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UPDATE PCT">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="pilih" runat="server" OnCheckedChanged="cbPct_CheckedChanged" AutoPostBack="true" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AKSI" HeaderStyle-HorizontalAlign="Center" FooterStyle-Font-Bold="true"
                                    HeaderStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblPilih" CommandName="Anggaran" CommandArgument='<%#Eval("ID_RAB_PENGABDIAN")%>'
                                            runat="server">Anggaran</asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterStyle Font-Bold="True" />
                                    <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </asp:TabPanel>
       
    </asp:TabContainer>
    <asp:Panel ID="pnlAnggota" runat="server" CssClass="panelPopup">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <fieldset>
                    <legend>Anggota Penelitian</legend>
                    <table>
                        <tr>
                            <td>
                                NPP
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_npp_anggota" runat="server" Width="120px"></asp:TextBox>
                                <asp:Label ID="lbl_personil" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NIDN
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_NIDN" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NPWP
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtNPWP" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nama
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_nama_anggota" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Jabatan Fungsional
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_jabatan" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Pangkat, Golongan
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_pangkat" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txt_golongan" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bidang Keahlian
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeahlian" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Unit/Fakultas
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_unit" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Jurusan/Program Studi
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_prodi" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Alamat
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtAlamat" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Kota
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtKota" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Propinsi
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtProp" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Kode pos
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtKodepos" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                No. Telp
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelp" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                No. Telp
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtHp" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3">
                                <asp:Button ID="btnSimpanAnggota" runat="server" Text="Tambah Anggota" OnClick="btnSimpanAnggota_Click" />
                                <asp:Button ID="btnSelesai0" runat="server" OnClick="btnSelesai_Click" Text="Tutup" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    
    <asp:Panel ID="panelKaryawan" CssClass="panelPopup" runat="server" ScrollBars="Auto"
        Height="400px">
        <table>
            <tr>
                <td>
                    Pencarian Nama / NPP
                    <asp:TextBox runat="server" ID="txtSearchKAryawan" AutoPostBack="true" OnTextChanged="txtSearchKAryawan_TextChanged"></asp:TextBox>
                    <asp:Button ID="btn_cariPopKaryawan" runat="server" Text="Cari" OnClick="btn_cariPopKaryawan_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Both" Width="400px">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvKaryawan" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                    OnRowCommand="gvKaryawan_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Pilih">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButtonSumberDaya" runat="server" CommandArgument='<%#Eval("NPP")%>'
                                                    CommandName="Select" CausesValidation="False">Pilih</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NPP" HeaderText="NPP" />
                                        <asp:BoundField DataField="NAMA_LENGKAP_GELAR" HeaderText="NAMA" />
                                    </Columns>
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <RowStyle CssClass="RowStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="3">
                    <asp:Button ID="btnSelesaiKaryawak" runat="server" Text="Tutup" OnClick="btnSelesaiKaryawak_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlDetailRAB" CssClass="panelPopup" runat="server" ScrollBars="Auto"
        Height="400px">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblJenisRAB" runat="server" Text=""></asp:Label>(
                        <asp:Label ID="lblMin" runat="server" Text="Label"></asp:Label>% * 
                        <asp:Label ID="lblTotalRAB" runat="server" Text="Label"></asp:Label> =
                        <asp:Label ID="lblMin0" runat="server" Text="Label"></asp:Label>
                        )&nbsp;</legend>
                    <asp:Label ID="lblRab" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblDtlRab" runat="server" Visible="False"></asp:Label>
                    <table>
                        <tr>
                            <td>
                                Rincian Anggaran
                            </td>
                            <td>
                                <asp:TextBox ID="txtRincian" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Volume
                            </td>
                            <td>
                                <asp:TextBox ID="txtVolume" runat="server" AutoPostBack="True" OnTextChanged="txtVolume_TextChanged"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtVolume"
                                    FilterType="Custom, Numbers" Enabled="True" />
                                <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                                Satuan<asp:TextBox ID="txtSatuan" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga Satuan
                            </td>
                            <td>
                                <asp:TextBox ID="txtHargaSatuan" runat="server" AutoPostBack="True" OnTextChanged="txtVolume_TextChanged"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtHargaSatuan"
                                    FilterType="Custom, Numbers" Enabled="True" />
                                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Jumlah
                            </td>
                            <td>
                                <asp:TextBox ID="txtJumlah" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtJumlah"
                                    FilterType="Custom, Numbers" Enabled="True" />
                                <asp:Label ID="lblJumlahFPD" runat="server" Visible="false"></asp:Label>
                                <asp:TextBox ID="txtJumlah0" runat="server" Enabled="False" ReadOnly="True" 
                                    Visible="False"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="txtJumlah0_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                    TargetControlID="txtJumlah0" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSimpanDetail" runat="server" Text="Simpan" OnClick="btnSimpanDetail_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvDtl_RAB" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                    OnRowCommand="gvDtl_RAB_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Pilih">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButtonSumberDaya" runat="server" CommandArgument='<%#Eval("ID_DTL_RAB_PENGABDIAN")%>'
                                                    CommandName="Select" CausesValidation="False">Pilih</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="KETERANGAN" HeaderText="KETERANGAN" />
                                        <asp:BoundField DataField="SATUAN" HeaderText="SATUAN" />
                                        <asp:BoundField DataField="JUMLAH" HeaderText="JUMLAH" DataFormatString="{0:n0}">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HARGA_SATUAN" HeaderText="HARGA_SATUAN" DataFormatString="{0:n0}">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="JUMLAH_DANA" HeaderText="JUMLAH_DANA" DataFormatString="{0:n0}">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <RowStyle CssClass="RowStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                </asp:GridView>
                            </td>
                            <tr>
                                <td align="right" colspan="3">
                                    Jumlah <asp:Label ID="lblTotalRAB0" runat="server" Text="Label"></asp:Label>
                                    <br />
                                    <asp:Button ID="btnSelesaiDtl" runat="server" Text="Tutup" 
                                        OnClick="btnSelesaiDtl_Click" style="height: 26px" />
                                </td>
                            </tr>
                    </table>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>
