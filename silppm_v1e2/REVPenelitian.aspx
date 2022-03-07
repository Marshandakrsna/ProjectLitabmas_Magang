<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" 
AutoEventWireup="true" CodeBehind="REVPenelitian.aspx.cs" Inherits="silppm_v1e2.REVPenelitian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        
        .style1
        {
            text-align: left;
        }
        .style4
        {
            text-align: left;
        }
        .style5
        {
            text-align: center;
            font-size: 16px;
            color: #000066;
            background-image: url('Styles/gridviewstyle/Images/YahooSprite.gif');
        }
        .style6
        {
            text-align: justify;
        }
        .style7
        {
            text-align: justify;
        }
        .style8
        {
            text-align: left;
        }
        .style9
        {
            text-align: center;
            }
        .style10
        {
            text-align: center;
            font-weight: bold;
            background-color: #FFFFCC;
            font-size: 14px;
        }
        .style11
        {
            text-align: center;
            font-weight: bold;
            background-color: #FFFFCC;
        }
        .style12
        {
            text-align: center;
            width: 87px;
            font-weight: bold;
            background-color: #FFFFCC;
        }
        .style21
        {
            text-align: left;
            }
        .auto-style1 {
            height: 35px;
        }
        .auto-style2 {
            text-align: left;
            height: 37px;
        }
        .auto-style3 {
            text-align: left;
            height: 25px;
        }
        .auto-style4 {
            color: #003399;
            font-size: large;
            font-weight: bold;
            text-align: left;
            height: 25px;
        }
        .auto-style5 {
            text-align: center;
            font-weight: bold;
            background-color: #FFFFCC;
            width: 88px;
        }
        .auto-style6 {
            width: 105px;
        }
        .auto-style8 {
            text-align: center;
            width: 49px;
        }
        .auto-style9 {
            text-align: center;
            font-weight: bold;
            background-color: #FFFFCC;
            width: 62px;
        }
        .auto-style12 {
            text-align: center;
            width: 62px;
        }
        .auto-style13 {
            text-align: center;
            width: 62px;
        }
        .auto-style14 {
            width: 88px;
        }
    </style>
    <script language="javascript">

        $(document).ready(function () {
            $('#Test1').click(function () {
                var selected = $('#<%= txtSkor1.ClientID %>').val();
                document.getElementById('<%=Label1.ClientID %>').innerHTML = selected;
            });
            
        });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>

         <strong>

         <br />

         </strong>

        <legend class="style1"><strong>Proposal Penelitian yang perlu di Review :</strong></legend>
    
         <strong>
    
    <asp:Panel ID="pnlPersetujuan" runat="server">
    
        <table style="width:100%;" border="1px" class="GridViewStyle" >
            <tr>
                <td colspan="2">
                    <asp:HiddenField ID="hidden1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="2">
                    <strong >LEMBAR EVALUASI PROPOSAL PENELITIAN DANA UAJY</strong></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    </td>
                <td class="auto-style4" Style="display: none">
                    <asp:TextBox ID="txtAngota2" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4" Style="display: none">
                    &nbsp;</td>
                <td class="style1">
                    <asp:TextBox ID="txtAnggota3" runat="server" Enabled="true" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Dokumen Proposal</td>
                <td class="style1">
                    <asp:LinkButton ID="LinkLihatProp" runat="server" onclick="LinkButton1_Click">Lihat Proposal</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
         </strong>
    
    <%--<asp:Panel ID="panelKonfirmasi" runat="server">
        <table style="width:100%;" border="1px" class="GridViewStyle">
            <tr>
                <td class="style5" colspan="5">
                    <strong>LEMBAR EVALUASI PROPOSAL PENELITIAN DANA UAJY</strong></td>
            </tr>
            <tr>
                <td class="style10">
                    Kriteria Penilaian</td>
                <td class="style12">
                    Bobot</td>
                <td class="style11">
                    Skor</td>
                <td class="style11">
                    Nilai</td>
                <td class="style11">
                    Justifikasi Penilaian</td>
            </tr>
            <tr>
                <td class="style6">
                    Originalitas penelitian : terlihat pada orisinalitas permasalahan, metode 
                    penelitian, tempat penelitian dan waktu penelitian.</td>
                <td class="style9">
                    20%</td>
                <td class="style7">
                    
                    <asp:DropDownList ID="txtSkor1" runat="server" Width="46px" 
                            onselectedindexchanged="txtSkor1_SelectedIndexChanged" 
                        AutoPostBack="true">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
                <td class="style9">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor1" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti1" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="302px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Kesesuaian tema penelitian yang diajukan dengan tema penelitian dalam rencana 
                    induk penelitian Fakultas, jurusan, program studi atau laboratorium.</td>
                <td class="style9">
                    10%</td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor2" runat="server" Width="46px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor2_SelectedIndexChanged">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style9">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor2" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti2" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="302px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Kesesuaian tema penelitian yang diajukan dengan rencana induk penelitian pribadi 
                    peneliti.</td>
                <td class="style9">
                    10%</td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor3" runat="server" Width="46px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor3_SelectedIndexChanged">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style9">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor3" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti3" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="302px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Track record peneliti : kesesuaian dan kecukupan penelitian yang pernah 
                    dilakukan ketua peneliti terkait dengan tema penelitian yang diajukan.</td>
                <td class="style9">
                    10%</td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor4" runat="server" Width="46px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor4_SelectedIndexChanged">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style9">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label4" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor4" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti4" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="302px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Kesesuaian permasalahan dengan pendekatan atau metode penelitian yang dipilih.</td>
                <td class="style9">
                    20%</td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor5" runat="server" Width="46px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor5_SelectedIndexChanged">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style9">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label5" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor5" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti5" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="302px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Kesesuaian penelitian dengan dana yang diajukan</td>
                <td class="style9">
                    10%</td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor6" runat="server" Width="46px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor6_SelectedIndexChanged">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style9">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label6" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor6" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti6" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="302px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Rencana outcome berupa : adanya makalah seminar nasional, makalah seminar 
                    internasional, artikel jurnal terakreditasi nasional, artikel jurnal 
                    terakreditasi internasional, buku ajar, benda model atau paten.</td>
                <td class="style9">
                    20%</td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor7" runat="server" Width="46px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor7_SelectedIndexChanged">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style9">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label7" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor7" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtJusti7" runat="server" Height="75px" TextMode="MultiLine" 
                        Width="302px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style8" colspan="2">
                    Jumlah</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label8" runat="server"></asp:Label>
                        </ContentTemplate>
                        
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    &nbsp;Passing Grade : 550</td>
            </tr>
        </table>
    </asp:Panel>
        <asp:Panel ID="pnlSkorPenilaian" runat="server">
            <table style="width:100%;" border="1px" class="GridViewStyle">
                <tr>
                    <td class="auto-style1" colspan="2">
                        </td>
                </tr>
                <tr>
                    <td class="style8" colspan="2">
                        <asp:HiddenField ID="hdnUsername" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Simpan" />
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                </tr>
            </table>
    </asp:Panel>--%>

    <asp:Panel ID="panelKonfirmasi" runat="server">
        <table style="width:100%;" border="1px" class="GridViewStyle">
            <tr>
                <td class="style5" colspan="5">
                    <strong>LEMBAR EVALUASI PROPOSAL PENELITIAN DANA UAJY</strong></td>
            </tr>
            <tr>
                <td class="style11">
                    Kriteria Penilaian</td>
                <td class="style11">
                    Bobot</td>
                <td class="auto-style9">
                    Skor</td>
                <td class="auto-style5">
                    Nilai</td>
                <td class="style11">
                    Justifikasi Penilaian</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Relevansi usulan penelitian terhadap bidang fokus, tema, dan topik dengan tema penelitian Universitas dan Unit</td>
                <td class="style9">
                    7.5</td>
                
                <td class="auto-style12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor1" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="auto-style14">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label1n" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor1" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    
                    <asp:DropDownList ID="txtSkor1" runat="server" Width="234px" 
                            onselectedindexchanged="txtSkor1_SelectedIndexChanged" 
                        AutoPostBack="true">
                        <asp:ListItem Value="0">Tidak relevan/ topik lainnya</asp:ListItem>
                        <asp:ListItem Value="3">Relevan</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Kualitas dan relevansi tujuan, permasalahan, state of the art, metode, dan kebaruan penelitian</td>
                <td class="style9">
                   37.5</td>
                
                <td class="auto-style13">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor2" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="auto-style14">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label2n" runat="server" CssClass="auto-style1"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor2" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>

                <td class="auto-style1">
                    <asp:DropDownList ID="txtSkor2" runat="server" Width="234px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor2_SelectedIndexChanged">
                        <asp:ListItem Value="0">Tidak ada</asp:ListItem>
                        <asp:ListItem Value="5">Kurang signifikan</asp:ListItem>
                        <asp:ListItem Value="10">Cukup signifikan</asp:ListItem>
                        <asp:ListItem Value="15">Sangat signifikan</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Keterkaitan usulan penelitian terhadap hasil penelitian yang didapat sebelumnya dan rencana kedepan (roadmap penelitian)</td>
                <td class="style9">
                    12.5</td>
                
                <td class="auto-style12">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor3" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="auto-style14">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label3n" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor3" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor3" runat="server" Width="234px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor3_SelectedIndexChanged">
                        <asp:ListItem Value="0">Tidak ada roadmap</asp:ListItem>
                        <asp:ListItem Value="2">Ada roadmap, keterkaitan milestone dan usulan penelitian tidak jelas</asp:ListItem>
                        <asp:ListItem Value="6">Ada roadmap, keterkaitan milestone dan usulan penelitian jelas</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Kesesuaian kompetensi tim peneliti dan pembagian tugas</td>
                <td class="style9">
                    7.5</td>
               
                <td class="auto-style12">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label4" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor4" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="auto-style14">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label4n" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor4" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                 <td class="style7">
                    <asp:DropDownList ID="txtSkor4" runat="server" Width="234px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor4_SelectedIndexChanged">
                        <asp:ListItem Value="1">Tidak kompeten, tugas tidak jelas</asp:ListItem>
                        <asp:ListItem Value="2">Cukup kompeten, tugas cukup jelas</asp:ListItem>
                        <asp:ListItem Value="3">Sangat kompeten, tugas sangat jelas</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Kewajaran metode tahapan target capaian luaran wajib penelitian</td>
                <td class="style9">
                    12.5</td>
                
                <td class="auto-style12">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label5" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor5" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="auto-style14">
                     <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label5n" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor5" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor5" runat="server" Width="234px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor5_SelectedIndexChanged">
                        <asp:ListItem Value="1">Tidak jelas</asp:ListItem>
                        <asp:ListItem Value="3">Kurang jelas</asp:ListItem>
                        <asp:ListItem Value="5">Sangat jelas</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style15">
                    Kekinian dan sumber primer pengacuan pustaka</td>
                <td class="style9">
                    12.5</td>
              
                <td class="auto-style13">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label6" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor6" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="auto-style14">
                   <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label6n" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor6" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                  <td class="auto-style18">
                    <asp:DropDownList ID="txtSkor6" runat="server" Width="234px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor6_SelectedIndexChanged">
                        <asp:ListItem Value="0">Tidak ada rujukan primer</asp:ListItem>
                        <asp:ListItem Value="1">Rujukan primer dan mutakhir 1-50%</asp:ListItem>
                        <asp:ListItem Value="3">Rujukan primer dan mutakhir 51-80%</asp:ListItem>
                        <asp:ListItem Value="5">Rujukan primer dan mutakhir &gt; 80%</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Penulisan usulan sesuai panduan (jumlah kata per bagian, isi dokumen pendukung) </td>
                <td class="style9">
                    10</td>
                
                <td class="auto-style12">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label7" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor7" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="auto-style14">
                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label7n" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="txtSkor7" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="style7">
                    <asp:DropDownList ID="txtSkor7" runat="server" Width="234px" 
                        AutoPostBack="True" onselectedindexchanged="txtSkor7_SelectedIndexChanged">
                        <asp:ListItem Value="0">Tidak</asp:ListItem>
                        <asp:ListItem Value="4">Ya</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">
                    &nbsp;</td>
               
                <td class="auto-style13">
                    <strong>Jumlah</strong></td>
                <td class="auto-style14">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label8" runat="server"></asp:Label>
                        </ContentTemplate>
                        
                    </asp:UpdatePanel></td>
            </tr>
        </table>
    </asp:Panel>
        <asp:Panel ID="pnlSkorPenilaian" runat="server">
            <table style="width:100%;" border="1px" class="GridViewStyle">
              
                <tr>
                    <td class="auto-style2" colspan="5">
                        <asp:HiddenField ID="hdnUsername" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="style8" colspan="4">
                        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Simpan" />
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                </tr>
            </table>
    </asp:Panel>
    <br />
    </fieldset>
</asp:Content>
