<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="AdminDisplayHistoryPengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm98" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label2" runat="server" 
        Text="Pilih Tahun Periode Pengajuan Proposal :"></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label1" runat="server" Text="History Penelitian"></asp:Label>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="id_proposal" 
                HeaderStyle-CssClass="HeaderStyle" onrowcommand="GridView1_RowCommand" 
                PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" 
                SelectedRowStyle-CssClass="SelectedRowStyle" Width="926px">
                <Columns>
                    <asp:BoundField DataField="NAMA" HeaderText="NAMA" />
                    <asp:BoundField DataField="FAK" HeaderText="FAKULTAS" />
                    <asp:BoundField DataField="PRODI" HeaderText="PRODI" />
                    <asp:BoundField DataField="judul_kegiatan" HeaderText="JUDUL" />
                    <asp:BoundField DataField="deskripsi" HeaderText="STATUS" />
                    <asp:BoundField DataField="TAHUN_ANGGARAN" HeaderText="PERIODE" />
                    <asp:TemplateField HeaderText="DOKUMEN PROPOSAL">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                CommandName="Proposal">Unduh Proposal</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DRAFT LAPORAN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Draft">Unduh Draft</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LAPORAN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                CommandName="Laporan">Unduh Laporan</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="HeaderStyle" />
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="RowStyle" />
                <SelectedRowStyle CssClass="SelectedRowStyle" />
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
                        <asp:AsyncPostBackTrigger controlid="DropDownList1" EventName="SelectedIndexChanged" />
                        </Triggers>
    </asp:UpdatePanel>
    <br />
    </asp:Content>
