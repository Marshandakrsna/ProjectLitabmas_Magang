<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="ProdiListAppPengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm66" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
    <br /><legend class="style1"><strong>Laporan Pengabdian yang perlu di Approve :</strong></legend>
    <asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id_proposal" style="margin-top: 0px" CssClass="GridViewStyle" 
             HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" 
             onrowcommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="AKSI">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="review"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" >Pilih</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Nama" DataField="nama" />
            <asp:BoundField HeaderText="Judul" DataField="judul_kegiatan" />
            <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>
        <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
        <PagerStyle CssClass="PagerStyle"></PagerStyle>
        <RowStyle CssClass="RowStyle"></RowStyle>
        <SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
    </asp:GridView>
</fieldset> 
</asp:Content>
