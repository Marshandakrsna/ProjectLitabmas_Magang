<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="ProdiMonevPenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm34" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView2" 
            runat="server" AutoGenerateColumns="False" 
            onrowcommand="GridView2_RowCommand" CssClass="GridViewStyle" 
            HeaderStyle-CssClass="HeaderStyle" 
    PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" 
    DataKeyNames="id_proposal" Width="917px">
    <Columns>
        <asp:BoundField DataField="nama" HeaderText="NAMA" />
        <asp:BoundField DataField="judul" HeaderText="JUDUL" />
        <asp:TemplateField HeaderText="AKSI">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                            CommandName="lihat">Lihat Perkembangan</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="id_proposal" HeaderText="id" Visible="False" />
    </Columns>
    <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
    <PagerStyle CssClass="PagerStyle"></PagerStyle>
    <RowStyle CssClass="RowStyle"></RowStyle>
    <SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
</asp:GridView>
<br />
<asp:HiddenField ID="HiddenField1" runat="server" />
<asp:Panel ID="Panel1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CssClass="GridViewStyle" DataKeyNames="no_update" 
        HeaderStyle-CssClass="HeaderStyle" onrowcommand="GridView1_RowCommand" 
        PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" 
        SelectedRowStyle-CssClass="SelectedRowStyle" Width="890px">
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
    <p>
        <asp:Label ID="Label1" runat="server" 
        Text="Maaf, belum ada daftar perkembangan."></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="OK" />
    </p>
</asp:Panel>
</asp:Content>
