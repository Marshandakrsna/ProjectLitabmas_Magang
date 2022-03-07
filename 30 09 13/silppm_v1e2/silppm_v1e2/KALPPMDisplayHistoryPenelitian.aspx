<%@ Page Title="" Language="C#" MasterPageFile="~/KALPPMmaster.Master" AutoEventWireup="true" CodeBehind="KALPPMDisplayHistoryPenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm86" %>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="GridViewStyle" 
                HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" 
                RowStyle-CssClass="RowStyle" SelectedRowStyle-CssClass="SelectedRowStyle" 
                Width="926px">
                <Columns>
                    <asp:BoundField DataField="NAMA" HeaderText="NAMA" />
                    <asp:BoundField DataField="FAK" HeaderText="FAKULTAS" />
                    <asp:BoundField DataField="PRODI" HeaderText="PRODI" />
                    <asp:BoundField DataField="judul" HeaderText="JUDUL" />
                    <asp:BoundField DataField="deskripsi" HeaderText="STATUS" />
                    <asp:BoundField DataField="TAHUN_ANGGARAN" HeaderText="PERIODE" />
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
