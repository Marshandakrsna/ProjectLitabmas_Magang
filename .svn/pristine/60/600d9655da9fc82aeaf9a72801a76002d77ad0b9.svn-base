<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="EditPengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm100" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style4
        {
            text-align: center;
            font-size: 16px;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        }
         
        .style4
        {
            font-size: 14px;
        background-color: #FFFF99;
    }
        .style13
        {
            text-align: justify;
            width: 208px;
        }
        .style12
        {
            text-align: justify;
        }
        .style8
        {
            text-align: justify;
            }
        .style14
        {
            text-align: justify;
            width: 207px;
        }
    </style>
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
                <strong>EDIT PROPOSAL PENGABDIAN PADA MASYARAKAT</strong></td>
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
                    <asp:Label ID="lblJenisPengabdian" runat="server"></asp:Label>
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
                <td class="style14">
                &nbsp;</td>
                <td class="style4">
                Nama</td>
                <td class="style4">
                Bidang Keahlian</td>
            </tr>
            <tr>
                <td class="style14">
                Mitra Kerjasama atau Mitra Sasaran</td>
                <td class="style12">
                    <asp:TextBox ID="txtNamaMitra" runat="server" Width="340px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtKeahlianMitra" runat="server" Width="340px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14">
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
                <td class="style14">
                Jarak PT ke lokasi kegiatan pengabdian</td>
                <td class="style12" colspan="2">
                    <asp:TextBox ID="txtJarak" runat="server" Width="625px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtJarak" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style14">
                Luaran (Output) yang dihasilkan</td>
                <td class="style12" colspan="2">
                    <asp:TextBox ID="txtOutput" runat="server" Width="625px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtOutput" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style14">
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
                <td class="style14">
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
                <td class="style14">
                Sasaran</td>
                <td class="style12" colspan="2">
                    <asp:TextBox ID="txtSasaran" runat="server" Width="625px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtSasaran" ErrorMessage="*Harus di isi" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style14">
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
                <td class="style14">
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
                <td class="style14" rowspan="2">
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
                <td class="style14">
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
                <td class="style14">
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
