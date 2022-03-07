<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="ProdiKelolaTemaPenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm43" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Tambahkan Tema Penelitian :</p>
    <asp:TextBox ID="TextBox1" runat="server" Height="23px" Width="394px"></asp:TextBox>
<asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
    Text="Tambahkan" />
<br />
<asp:Panel ID="Panel1" runat="server">
    Tema yang sudah aktif :<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CssClass="GridViewStyle" DataKeyNames="ID_ROAD_MAP_PENELITIAN" 
        HeaderStyle-CssClass="HeaderStyle" onrowcommand="GridView2_RowCommand" 
        PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" 
        SelectedRowStyle-CssClass="SelectedRowStyle" style="margin-top: 0px">
        <Columns>
            <asp:TemplateField HeaderText="AKSI">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="hapus"
                        OnClientClick="return confirm('Apakah anda yakin ingin menghapus Tema Penelitian ini?');">Hapus</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DESKRIPSI" HeaderText="TEMA" />
        </Columns>
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>
</asp:Panel>
</asp:Content>
