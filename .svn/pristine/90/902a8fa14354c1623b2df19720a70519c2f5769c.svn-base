<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="HomePengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm3" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
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
         #mapCanvas {
            width: 600px;
            height: 300px;
            float: left;
          }
          #infoPanel {
            float: left;
            margin-left: 10px;
          }
          #infoPanel div {
            margin-bottom: 5px;
          }
        .style13
        {
            text-align: justify;
            width: 208px;
        }
        </style>
        
        <script type="text/javascript"
src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCDO19UiZ_tabbU4p6FerT0H_3XPloY020&sensor=false">
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
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
   
        <table style="Background-color:White; width:100%; " border="1px" 
        class="GridViewStyle">
            <tr>
                <td colspan="2" style="text-align: center" class="style4">
                    <strong>TAMBAH PROPOSAL PENGABDIAN PADA MASYARAKAT</strong></td>
            </tr>
            <tr>
                <td class="style13">
                    Periode Penelitian</td>
                <td>
                    <asp:Label ID="lblPeriode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
    Judul Kegiatan Pengabdian</td>
                <td>
    <asp:TextBox ID="txtJudul" runat="server" Width="532px" TextMode="MultiLine"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtJudul" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="style13">
                    Judul Penelitian yang digunakan sebagai landasan kegiatan yang diusulkan ini</td>
                <td class="style12">
    <asp:TextBox ID="txtJudulPenelitian" runat="server" Width="532px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtJudulPenelitian" ErrorMessage="*Harus di isi" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Jenis Pengabdian</td>
                <td>
                    <asp:Label ID="lblJenisPengabdian" runat="server" Text="Jenis Pengabdian"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Pengusul</td>
                <td>
                    <asp:Label ID="lblNamaKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    NIDN</td>
                <td>
                    <asp:Label ID="lblNIDNKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    NIP/NPP</td>
                <td class="style10">
                    <asp:Label ID="lblNPPKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Jabatan/Golongan</td>
                <td>
                    <asp:Label ID="lblGolonganKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Unit/Fakultas/Jurusan</td>
                <td>
                    <asp:Label ID="lblFakKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                    , <asp:Label ID="lblJurusanKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Bidang Keahlian</td>
                <td>
                    <asp:Label ID="lblKeahlian" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Alamat Kantor</td>
                <td>
                    <asp:Label ID="lblAlamatKantor" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Alamat Rumah</td>
                <td>
                    <asp:Label ID="lblAlamatKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            </table>
            <asp:Panel ID="panelAnggota" runat="server">
                <table style="Background-color:White; width:100%; " border="1px" 
                    class="GridViewStyle">
                    <tr>
                        <td class="style13">
                            Anggota Tim</td>
                        <td class="style4">
                            Nama</td>
                        <td class="style4">
                            Bidang Keahlian</td>
                    </tr>
                    <tr>
                        <td class="style13">
                            &nbsp;</td>
                        <td class="style12">
                            <asp:TextBox ID="txtNama1" runat="server" Width="340px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBidang1" runat="server" Width="340px" Height="22px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            &nbsp;</td>
                        <td class="style12">
                            <asp:TextBox ID="txtNama2" runat="server" Width="340px" Height="21px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBidang2" runat="server" Width="340px" Height="22px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
</asp:Panel>
<asp:Panel ID="panelBawah" runat="server">
    <table style="Background-color:White; width:100%; " border="1px" 
        class="GridViewStyle">
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style4">
                Nama</td>
            <td class="style4">
                Bidang Keahlian</td>
        </tr>
        <tr>
            <td class="style8">
                Mitra Kerjasama atau Mitra Sasaran</td>
            <td class="style12">
                <asp:TextBox ID="txtNamaMitra" runat="server" Width="340px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtKeahlianMitra" runat="server" Width="340px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Lokasi Kegiatan</td>
            <td class="style12" colspan="2">
                <asp:TextBox ID="txtLokasi" runat="server" Width="625px" Height="24px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtLokasi" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="3">
                         <div ID="mapCanvas">
                        </div>
                        <div ID="infoPanel">
                            <b>Marker status:</b>
                            <div ID="markerStatus">
                                <i>Click and drag the marker.</i></div>
                            <b>Current position:</b>
                            <div ID="info">
                            </div>
                            <b>Closest matching address:</b>
                            <div ID="address">
                            </div>
                        </div>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Jarak PT ke lokasi kegiatan pengabdian</td>
            <td class="style12" colspan="2">
                <asp:TextBox ID="txtJarak" runat="server" Width="625px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtJarak" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Luaran (Output) yang dihasilkan</td>
            <td class="style12" colspan="2">
                <asp:TextBox ID="txtOutput" runat="server" Width="625px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtOutput" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Outcome</td>
            <td class="style12" colspan="2">
                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Enabled="False" 
                    Text="Laporan" />
                <br />
                <asp:CheckBox ID="CheckBox7" runat="server" Checked="True" Enabled="False" 
                    Text="Jurnal/Prosiding" />
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
            <td class="style8">
                Tanggal Mulai Pengabdian</td>
            <td class="style12">
                <asp:TextBox ID="dateMulai" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="dateMulai_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="dateMulai" TodaysDateFormat="0:MM/dd/yyyy">
                </ajaxToolkit:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="dateMulai" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                Durasi efektif :<asp:DropDownList ID="dateSelesai" runat="server">
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
            <td class="style8">
                Sasaran</td>
            <td class="style12" colspan="2">
                <asp:TextBox ID="txtSasaran" runat="server" Width="625px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtSasaran" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Beban SKS</td>
            <td class="style12">
                Ketua :
                <asp:TextBox ID="txtSksKetua" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtSksKetua" ErrorMessage="*hanya boleh diisi angka" 
                    ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtSksKetua" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Panel ID="panelSksAnggota" runat="server">
                    Anggota :<asp:TextBox ID="txtSksAnggota" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="txtSksAnggota" ErrorMessage="*hanya boleh diisi angka" 
                        ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Topik Penelitian sesuai dengan rencana unit</td>
            <td class="style12" colspan="2">
                <asp:DropDownList ID="ddLRencanaUnit" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                    ControlToValidate="ddLRencanaUnit" ErrorMessage="*Harus di isi" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style8" rowspan="2">
                Dana yang diusulkan</td>
            <td class="style4">
                Dari UAJY</td>
            <td class="style4" style="text-align: center">
                Dari Pribadi pengusul</td>
        </tr>
        <tr>
            <td class="style12">
                Rp
                <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="check"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBox4" ErrorMessage="*hanya boleh diisi angka" 
            ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                    ControlToValidate="TextBox4" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                Rp
                <asp:TextBox ID="TextBox5" runat="server" ValidationGroup="check" 
                        Width="140px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="TextBox5" ErrorMessage="*hanya boleh diisi angka" 
            ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Dokumen</td>
            <td class="style12">
                Format : PENGABDIAN_XX_YYYYY.pdf
                <br />
                X=Penelitian Ke-<br /> Y= 5 Digit Belakang NPP<br />
                <asp:FileUpload ID="FileUpload1" runat="server" style="text-align: left" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                    ControlToValidate="FileUpload1" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td>
                <asp:Button ID="BtnSimpan" runat="server" Text="Simpan" 
                    onclick="BtnSimpan_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>

    </asp:Content>
