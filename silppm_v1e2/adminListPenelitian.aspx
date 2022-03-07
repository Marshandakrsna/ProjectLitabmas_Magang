﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true"
    CodeBehind="adminListPenelitian.aspx.cs" Inherits="silppm_v1e2.UI.adminListPenelitian" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnMunculReview"
        PopupControlID="pnlReview" DynamicServicePath="" Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Button ID="btnMunculReview" runat="server" OnClick="btnMunculReview_Click" Style="display: none" />
    <asp:Label ID="Label2" runat="server" Text="Pilih Tahun Periode Pengajuan Proposal :"></asp:Label>
    <table>
        <tr>
            <td>
                Tahun
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                NPP
            </td>
            <td>
                <asp:TextBox ID="txtNppDosen" runat="server" AutoPostBack="True" OnTextChanged="DropDownList1_SelectedIndexChanged"></asp:TextBox>
            </td>
        </tr>
    </table>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <asp:GridView ID="gvPenelitian" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle"
        RowStyle-CssClass="RowStyle" SelectedRowStyle-CssClass="SelectedRowStyle" Width="926px"
        OnRowCommand="gvPenelitian_RowCommand" OnPageIndexChanging="gvPenelitian_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="AKSI">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkBtnPilih" runat="server" CommandArgument='<%# Eval("ID_PROPOSAL") %>'
                        CommandName="Pilih">Edit</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reviewer">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkBtnSetRev" runat="server" CommandArgument='<%# Eval("ID_PROPOSAL") %>'
                        CommandName="Review">Set Reviewer</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Display">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkLihatProp" runat="server" CommandArgument='<%# Eval("ID_PROPOSAL") %>'
                        CommandName="Proposal">Proposal</asp:LinkButton>|
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID_PROPOSAL") %>'
                        CommandName="Pengesahan">Pengesahan</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NAMA" HeaderText="NAMA" />
            <asp:BoundField DataField="NPP" HeaderText="NPP" />
            <asp:BoundField DataField="FAK" HeaderText="FAKULTAS" />
            <asp:BoundField DataField="PRODI" HeaderText="PRODI" />
            <asp:BoundField DataField="judul" HeaderText="JUDUL" />
            <asp:BoundField DataField="deskripsi" HeaderText="STATUS" />
            <asp:BoundField DataField="TAHUN_AKADEMIK" HeaderText="PERIODE" />
            <asp:BoundField DataField="DANA_SETUJU" HeaderText="DANA" DataFormatString="{0:C2}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:GridView ID="gvPenelitian0" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle"
        RowStyle-CssClass="RowStyle" SelectedRowStyle-CssClass="SelectedRowStyle" Width="926px"
        OnRowCommand="gvPenelitian_RowCommand" OnPageIndexChanging="gvPenelitian_PageIndexChanging"
        Visible="False" PageSize="500">
        <Columns>
            <asp:BoundField DataField="NAMA" HeaderText="NAMA" />
            <asp:BoundField DataField="FAK" HeaderText="FAKULTAS" />
            <asp:BoundField DataField="PRODI" HeaderText="PRODI" />
            <asp:BoundField DataField="judul" HeaderText="JUDUL" />
            <asp:BoundField DataField="deskripsi" HeaderText="STATUS" />
            <asp:BoundField DataField="TAHUN_AKADEMIK" HeaderText="PERIODE" />
            <asp:BoundField DataField="DANA_SETUJU" HeaderText="DANA" DataFormatString="{0:C2}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>
    <asp:Button ID="btn_download" runat="server" OnClick="btn_download_Click" Text="Download" />
    <br />
    <asp:Panel ID="pnlReview" CssClass="panelPopup" runat="server" ScrollBars="Auto">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Judul"></asp:Label>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtJudul" runat="server"></asp:TextBox>
                            <asp:Label ID="lblIdProp" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Nama Dosen"></asp:Label>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDosen" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Reviewer 1"></asp:Label>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddRev1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Reviewer 2"></asp:Label>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddRev2" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="BtnSimpan" runat="server" Text="Simpan" OnClick="BtnSimpan_Click" />
        <asp:Button ID="btnBatalKeg" runat="server" OnClick="btnBatalKeg_Click" Text="Batal" />
    </asp:Panel>
</asp:Content>
