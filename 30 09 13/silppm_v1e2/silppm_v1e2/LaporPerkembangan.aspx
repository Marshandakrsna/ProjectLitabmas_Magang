<%@ Page Title="" Language="C#" MasterPageFile="~/Homev2.Master" AutoEventWireup="true" CodeBehind="LaporPerkembangan.aspx.cs" Inherits="silppm_v1e2.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Berikut Daftar Laporan Perkembangan Penelitian yang telah anda buat:</p>
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" 
            PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" Width="890px" 
            DataKeyNames="no_update" onrowcommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="no_update" HeaderText="No" />
                <asp:BoundField DataField="no_update" HeaderText="LAPORAN MONEV TAHAP KE :" />
                <asp:BoundField DataField="TANGGAL_UPLOAD" HeaderText="Tanggal" />
                <asp:TemplateField HeaderText="AKSI">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Lihat">Lihat Dokumen</asp:LinkButton>
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
        <br />
    </asp:Panel>

    <asp:Label ID="Label1" runat="server" 
        Text="Maaf, anda belum membuat daftar perkembangan."></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td>
                Tanggal</td>
            <td>
                Unggah Dokumen</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTanggal" runat="server"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                    Text="Tambahkan" />
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Kembali" />
            </td>
        </tr>
    </table>

</asp:Content>
