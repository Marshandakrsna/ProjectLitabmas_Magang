<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminListKelolaReview.aspx.cs" Inherits="silppm_v1e2.WebForm59" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
Pilih Reviewer :<asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        DataKeyNames="npp" style="margin-top: 0px" CssClass="GridViewStyle" 
             HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" Width="890px" 
        onrowcommand="GridView1_RowCommand">
    <Columns>
        <asp:TemplateField HeaderText="AKSI" ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                    CommandName="pilih" 
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                    Text="Tambahkan Proposal Penelitian"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AKSI">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                    CommandName="pilihPengabdian" Text="Tambahkan Proposal Pengabdian"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Nama" DataField="nama" />
    </Columns>
    <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
    <PagerStyle CssClass="PagerStyle"></PagerStyle>
    <RowStyle CssClass="RowStyle"></RowStyle>
    <SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
</asp:GridView>
<br />
    <asp:Label ID="Label1" runat="server" 
        Text="Tidak ada data untuk ditampilkan." 
        Visible="False"></asp:Label>
    </asp:Content>
