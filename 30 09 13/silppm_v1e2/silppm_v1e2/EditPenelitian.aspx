<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="EditPenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm4" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        
        {
            text-align: center;
            font-size: 16px;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        }
        .style5
        {
            width: 730px;
        }
        .style10
        {
            width: 444px;
        }
        .style11
        {
            width: 433px;
        }
        .style14
        {
            width: 377px;
        }
        .style3
        {
            font-size: 7pt;
        background-color: #FFFF99;
    }
                    
        .style15
        {
            width: 162px;
        }
    
        .style13
        {
            width: 1508px;
            height: 29px;
        }
        .style19
        {
            width: 1226px;
            height: 23px;
        }
        .style21
        {
            width: 1508px;
        }
        #mapCanvas
        {
            height: 215px;
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
    

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <table style="Background-color:White; width:100%; " border="1px" 
            class="GridViewStyle">
            <tr>
                <td colspan="2" style="text-align: center" class="style4">
                    <strong>EDIT PROPOSAL PENELITIAN INTERNAL </strong></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center" class="style3">
                    <em style="border-style: 0; border-width: 0px;">(Bedasarkan SK Rektor Nomor 101/HP/Per.Pen/2012)</em></td>
            </tr>
            <tr>
                <td class="style15">
                    Periode Penelitian</td>
                <td>
                    <asp:Label ID="lblPeriode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Judul Penelitian</td>
                <td>
    <asp:TextBox ID="txtJudul" runat="server" Width="536px" TextMode="MultiLine"></asp:TextBox>
                    <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtJudul" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Kata Kunci (Inggris)</td>
                <td>
                    <asp:TextBox ID="txtKataKunci" runat="server" Width="469px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtKataKunci" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Jenis Kegiatan</td>
                <td>
                    <asp:DropDownList ID="ddlJenis" runat="server">
                        <asp:ListItem>Laboratorium</asp:ListItem>
                        <asp:ListItem>Lapangan</asp:ListItem>
                        <asp:ListItem>Pustaka</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Nama Ketua Peneliti</td>
                <td>
                    <asp:Label ID="lblNamaKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            </table>
    <asp:Panel ID="pnlAnggotaKelompok" runat="server">
        <table style="Background-color:White; width:100%; " border="1px" 
            class="GridViewStyle">
            <tr>
                <td class="style19">
                </td>
                <td class="style10">
                    Anggota1</td>
                <td class="style10">
                    Anggota 2</td>
            </tr>
            <tr>
                <td class="style19">
                    Nama Lengkap</td>
                <td class="style11">
                    <asp:TextBox ID="txtNamaAnggota1" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtNamaAnggota2" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Pangkat/Golongan</td>
                <td class="style11">
                    <asp:TextBox ID="txtPangkatAnggota1" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtPangkatAnggota2" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    NPP</td>
                <td class="style11">
                    <asp:TextBox ID="txtNPPAnggota1" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtNPPAnggota2" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Jabatan</td>
                <td class="style11">
                    <asp:TextBox ID="txtJabatanAnggota1" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtJabatanAnggota2" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Unit/Fakultas/Jurusan</td>
                <td class="style11">
                    <asp:TextBox ID="txtUnitAnggota1" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtUnitAnggota2" runat="server" Height="22px" Width="373px"></asp:TextBox>
                </td>
            </tr>
        </table>
</asp:Panel>
        
        <asp:Panel ID="Panel1" runat="server">
            <table style="Background-color:White; width:100%; " border="1px" 
                class="GridViewStyle">
                <tr>
                    <td class="style21">
                        Lokasi Penelitian</td>
                    <td class="style5" style="text-align: left" colspan="2">
                        <asp:TextBox ID="txtLokasi" runat="server" Height="52px" TextMode="MultiLine" 
                            Width="746px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style5" colspan="2" style="text-align: left">
                        <div ID="infoPanel">
                            <div ID="mapCanvas">
                            </div>
                            <b>Marker status:</b>
                            <div ID="markerStatus">
                                <i>Click and drag the marker.</i></div>
                            <b>Current position:</b>
                            <div ID="info">
                            </div>
                            <b>Closest matching address:</b>
                            <div ID="address">
                            </div>
                        </div></td>
                </tr>
                <tr>
                    <td class="style21">
                        Jarak dari Kampus UAJY</td>
                    <td class="style5" style="text-align: left">
                        <asp:TextBox ID="txtJarakKM" runat="server" Width="92px"></asp:TextBox>
                        (Km)<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtJarakKM" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="txtJarakKM" ErrorMessage="*hanya boleh diisi angka" 
                            ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtJarakJam" runat="server" Width="97px"></asp:TextBox>
                        (Jam)<asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
                            runat="server" ControlToValidate="txtJarakJam" 
                            ErrorMessage="*hanya boleh diisi angka" ForeColor="Red" 
                            ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        Waktu Penelitian&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        :&nbsp;&nbsp;</td>
                    <td class="style5">
                        <asp:TextBox ID="dateMulai" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="dateMulai_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="dateMulai" TodaysDateFormat="0:MM/dd/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="dateMulai" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        Waktu Efektif :
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
                    <td class="style21">
                        Berbeban SKS</td>
                    <td class="style5" 
                    style="border-right-style: 0; border-right-width: 0px; border-right-color: 0;">
                        Ketua :<asp:TextBox ID="txtBebanSKS" runat="server" 
                        Width="109px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="txtBebanSKS" ErrorMessage="*hanya boleh diisi angka" 
                            ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtBebanSKS" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td 
                    
                        style="border-top-width: 0px; border-top-style: 0; border-top-color: 0; border-left-style: 0; border-bottom-style: 0;">
                        <asp:Panel ID="pnlSKSAnggota" runat="server">
                            Anggota :<asp:TextBox ID="txtSKSAnggota" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ControlToValidate="txtSKSAnggota" ErrorMessage="*hanya boleh diisi angka" 
                                ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        Topik Penelitian sesuai dengan rencana unit</td>
                    <td colspan="2">
                        
                                <asp:DropDownList ID="ddLRencanaUnit" runat="server" 
                                    onselectedindexchanged="ddLRencanaUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                            
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="ddLRencanaUnit" ErrorMessage="*Harus di isi" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        Outcome</td>
                    <td colspan="2">
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
                    <td class="style13">
                        Biaya Di Usulkan</td>
                    <td class="style14" style="text-align: center" >
                        Dana UAJY</td>
                    <td class="style14" style="text-align: center">
                        Dana Pribadi Peneliti</td>
                </tr>
                <tr>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style5">
                        Rp
                        <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="check"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBox4" ErrorMessage="*hanya boleh diisi angka" 
            ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        Rp
                        <asp:TextBox ID="TextBox5" runat="server" ValidationGroup="check" Width="140px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="TextBox5" ErrorMessage="*hanya boleh diisi angka" 
            ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        Dokumen Proposal</td>
                    <td class="style5" colspan="2">
                        Format : PENELITIAN_XX_YYYYY.pdf
                        <br />
                        X=Penelitian Ke-<br /> Y= 5 Digit Belakang NPP<br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="FileUpload1" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="border-right-style: 0; border-bottom-style: 0; border-left-style: 0; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-right-color: 0; border-bottom-color: 0; border-left-color: 0;" 
                        class="style21">
                        <asp:Label ID="lbl2" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td class="style5" 
                    
                        style="border-right-style: 0; border-bottom-style: 0; border-left-style: 0; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-right-color: 0; border-bottom-color: 0; border-left-color: 0">
                        <asp:Button ID="Button1" runat="server" Text="Ubah Proposal" 
            onclick="Button1_Click1"  />
                    </td>
                    <td 
                    
                        style="border-right-style: 0; border-bottom-style: 0; border-left-style: 0; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-right-color: 0; border-bottom-color: 0; border-left-color: 0">
                        <asp:Button ID="Button2" runat="server" onclick="Button2_Click1" Text="Batal" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
</asp:Content>
