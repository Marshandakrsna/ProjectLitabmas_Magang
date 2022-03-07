<%@ Page Title="" Language="C#" MasterPageFile="~/ReviewerMaster.Master" AutoEventWireup="true" CodeBehind="monevPenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm28" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView2" 
            runat="server" AutoGenerateColumns="False" 
            onrowcommand="GridView2_RowCommand" CssClass="GridViewStyle" 
            HeaderStyle-CssClass="HeaderStyle" 
    PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" 
    DataKeyNames="id_proposal" 
    onselectedindexchanged="GridView2_SelectedIndexChanged" Width="917px">
    <Columns>
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
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="no_update" HeaderText="No" />
                <asp:BoundField DataField="tanggal" HeaderText="Tanggal" />
                <asp:BoundField DataField="keterangan" HeaderText="Keterangan" />
            </Columns>
        </asp:GridView>
    </p>
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
