<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminPreviewUpdate.aspx.cs" Inherits="silppm_v1e2.WebForm27" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
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
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                            CommandName="Lihat">Lihat Dokumen</asp:LinkButton>
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
        </p>
    <p>

    <asp:Label ID="Label1" runat="server" 
        Text="Maaf, belum ada daftar perkembangan."></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Kembali" />
    </p>
</asp:Content>
