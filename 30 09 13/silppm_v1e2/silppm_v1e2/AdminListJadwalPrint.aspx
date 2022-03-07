<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminListJadwalPrint.aspx.cs" Inherits="silppm_v1e2.WebForm61" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Silahkan pilih proposal yang hendak dicetak :</p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CssClass="GridViewStyle" DataKeyNames="id_proposal" 
                HeaderStyle-CssClass="HeaderStyle" onrowcommand="GridView1_RowCommand" 
                PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" 
                SelectedRowStyle-CssClass="SelectedRowStyle" style="margin-top: 0px" 
                AllowPaging="True" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                Width="914px">
                <Columns>
                    <asp:TemplateField HeaderText="AKSI">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbjadwal" runat="server" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                CommandName="jadwal">Cetak Jadwal</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AKSI">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbsurat" runat="server" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="surat">Cetak Surat Pengantar 70%</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AKSI">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbsurat30" runat="server" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                CommandName="surat30">Cetak Surat Pengantar 30%</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nama" HeaderText="Nama" />
                    <asp:BoundField DataField="judul" HeaderText="Judul" />
                </Columns>
                <HeaderStyle CssClass="HeaderStyle" />
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="RowStyle" />
                <SelectedRowStyle CssClass="SelectedRowStyle" />
            </asp:GridView>
    <asp:Label ID="Label1" runat="server" 
        Text="Tidak ada data untuk ditampilkan." 
        Visible="False"></asp:Label>

    </asp:Content>
