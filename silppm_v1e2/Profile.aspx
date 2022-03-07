﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="silppm_v1e2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style8
        {
            width: 162px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
   
        <table style="Background-color:White; width:100%; " border="1px" 
        class="GridViewStyle">
            <tr>
                <td class="style8">
        Nama&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
        </td>
                <td>
        <asp:Label ID="lblnama" runat="server" Text="disini_nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Pangkat/Golongan</td>
                <td>
                    <asp:Label ID="lblPangkatKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                    /<asp:Label ID="lblGolKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    NPP/NIDN</td>
                <td>
                    <asp:Label ID="lblNPPKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                    /<asp:Label ID="lblNIDNKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Unit/Fakultas/Jurusan</td>
                <td>
                    <asp:Label ID="lblFakKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                    /<asp:Label ID="lblJurusanKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Alamat</td>
                <td>
                    <asp:Label ID="lblAlamatKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Alamat Kantor</td>
                <td>
                    <asp:Label ID="lblAlamatKantor" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    No. Telp/Faks</td>
                <td>
                    <asp:Label ID="lblTelpKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Email</td>
                <td>
                    <asp:Label ID="lblEmailKetua" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Bidang Keahlian</td>
                <td>
                    <asp:Label ID="lblKeahlian" runat="server" Text="Tidak Tersedia"></asp:Label>
                </td>
            </tr>
            </table>
    <p>
        Proposal yang sudah diajukan :</p>
    <asp:Panel ID="Panel1" runat="server">
        Proposal Penelitian :<asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="id_proposal" 
            EnablePersistedSelection="True" HeaderStyle-CssClass="HeaderStyle" 
            onrowcommand="GridView1_RowCommand" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" 
            SelectedRowStyle-CssClass="SelectedRowStyle" Width="936px" 
            AllowPaging="True">
            <Columns>
                <asp:TemplateField AccessibleHeaderText="Button1" HeaderText="AKSI">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Lihat">Lihat Review</asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                    <ItemStyle BackColor="Transparent" Font-Underline="True" ForeColor="Blue" />
                </asp:TemplateField>
                <asp:BoundField AccessibleHeaderText="id_proposal" DataField="id_proposal" 
                    HeaderText="NOMOR PROPOSAL" Visible="False" />
                <asp:BoundField DataField="judul" HeaderText="JUDUL PROPOSAL">
                <ControlStyle Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="DESKRIPSI" HeaderText="STATUS" />
                <asp:TemplateField HeaderText="AKSI" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkRevisi" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                            CommandName="revisi">Edit Detail</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle BackColor="Transparent" Font-Underline="True" ForeColor="Blue" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="HeaderStyle" />
            <PagerStyle CssClass="PagerStyle" />
            <RowStyle CssClass="RowStyle" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        Proposal Pengabdian :<br />
        <asp:GridView ID="GridViewPengabdian" runat="server" 
            AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="id_proposal" 
            EnablePersistedSelection="True" HeaderStyle-CssClass="HeaderStyle" 
            onrowcommand="GridViewPengabdian_RowCommand" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" 
            SelectedRowStyle-CssClass="SelectedRowStyle" Width="936px" 
            AllowPaging="True">
            <Columns>
                <asp:TemplateField AccessibleHeaderText="Button1" HeaderText="AKSI">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Lihat">Lihat Review</asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                    <ItemStyle BackColor="Transparent" Font-Underline="True" ForeColor="Blue" />
                </asp:TemplateField>
                <asp:BoundField AccessibleHeaderText="id_proposal" DataField="id_proposal" 
                    HeaderText="NOMOR PROPOSAL" Visible="False" />
                <asp:BoundField DataField="Judul_kegiatan" HeaderText="JUDUL PROPOSAL">
                <ControlStyle Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="DESKRIPSI" HeaderText="STATUS" />
                <asp:TemplateField HeaderText="AKSI" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkRevisi0" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                            CommandName="revisi">Edit Detail</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle BackColor="Transparent" Font-Underline="True" ForeColor="Blue" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="HeaderStyle" />
            <PagerStyle CssClass="PagerStyle" />
            <RowStyle CssClass="RowStyle" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
        </asp:GridView>
    </asp:Panel>
    <p>
        &nbsp;</p>
    <p>
        Proposal yang sudah disetujui :        
        <asp:GridView ID="GridView2" 
            runat="server" AutoGenerateColumns="False" 
            onrowcommand="GridView2_RowCommand" CssClass="GridViewStyle" 
            HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" DataKeyNames="id_proposal" 
            Width="934px" onrowdatabound="GridView2_RowDataBound" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="judul" HeaderText="JUDUL" >
                <ControlStyle Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="DESKRIPSI" HeaderText="STATUS" />
                <asp:BoundField DataField="id_proposal" HeaderText="id" Visible="False" />
                <asp:TemplateField HeaderText="AKSI">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>-- Pilih! --</asp:ListItem>
                            <asp:ListItem>Lihat Review</asp:ListItem>
                            <asp:ListItem>Lihat Jadwal</asp:ListItem>
                            <asp:ListItem>Lapor Perkembangan</asp:ListItem>
                            <asp:ListItem>Unggah Draft Laporan Final</asp:ListItem>
                            <asp:ListItem>Unggah Laporan Final</asp:ListItem>
                            <asp:ListItem>Unggah Outcome</asp:ListItem>
                            <asp:ListItem>Perpanjang Masa Akhir</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>

<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>

<PagerStyle CssClass="PagerStyle"></PagerStyle>

<RowStyle CssClass="RowStyle"></RowStyle>

<SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
        </asp:GridView>
    </p>
    <asp:Panel ID="Panel3" runat="server">
        Proposal Pengabdian yang sudah di setujui :
        <br />
        <asp:GridView ID="GridViewPengabdianLolos" runat="server" 
            AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="id_proposal" 
            HeaderStyle-CssClass="HeaderStyle" 
            onrowcommand="GridViewPengabdianLolos_RowCommand" 
            PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" 
            SelectedRowStyle-CssClass="SelectedRowStyle" Width="934px" 
            AllowPaging="True" onrowdatabound="GridViewPengabdianLolos_RowDataBound">
            <Columns>
                <asp:BoundField DataField="judul_kegiatan" HeaderText="JUDUL">
                <ControlStyle Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="id_proposal" HeaderText="id" Visible="False" />
                <asp:BoundField DataField="DESKRIPSI" HeaderText="STATUS" />
                <asp:TemplateField HeaderText="AKSI">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlPengabdianLolos" runat="server" 
                            onselectedindexchanged="ddlPengabdianLolos_SelectedIndexChanged" 
                            AutoPostBack="True">
                            <asp:ListItem>-- Pilih! --</asp:ListItem>
                            <asp:ListItem>Lihat Review</asp:ListItem>
                            <asp:ListItem>Lihat Jadwal</asp:ListItem>
                            <asp:ListItem>Lapor Perkembangan</asp:ListItem>
                            <asp:ListItem>Unggah Draft Laporan Final</asp:ListItem>
                            <asp:ListItem>Unggah Laporan Final</asp:ListItem>
                            <asp:ListItem>Perpanjang Masa Akhir</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="HeaderStyle" />
            <PagerStyle CssClass="PagerStyle" />
            <RowStyle CssClass="RowStyle" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>
