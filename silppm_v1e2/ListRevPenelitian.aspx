<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="ListRevPenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm42" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" 
        Text="Maaf tidak ada proposal yang tersedia untuk dilakukan review." 
        Visible="False"></asp:Label>
    <asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id_proposal" style="margin-top: 0px" CssClass="GridViewStyle" 
             HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" Width="890px" 
        onrowcommand="GridView1_RowCommand">
    <Columns>
        <asp:TemplateField HeaderText="AKSI" ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                    CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Pilih"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Judul" DataField="judul" />
        <asp:BoundField HeaderText="Jenis" DataField="kategori" >
        <ControlStyle Width="50px" />
        <HeaderStyle HorizontalAlign="Right" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="detail_pelaku" >
        <ControlStyle Width="50px" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Status" DataField="DESKRIPSI" />
    </Columns>
    <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
    <PagerStyle CssClass="PagerStyle"></PagerStyle>
    <RowStyle CssClass="RowStyle"></RowStyle>
    <SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
</asp:GridView>
</asp:Content>
