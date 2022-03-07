<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true"
    CodeBehind="KelolaReviewer.aspx.cs" Inherits="silppm_v1e2.UI.KelolaReviewer" %>

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
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" VerticalStripWidth="100px"
        Width="100%">
        <asp:TabPanel runat="server" HeaderText="Kelola Reviewer Penelitian" ID="TabPanel1">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvPenelitian" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle"
                            RowStyle-CssClass="RowStyle" SelectedRowStyle-CssClass="SelectedRowStyle" Width="926px"
                            OnRowCommand="gvPenelitian_RowCommand" 
                            onselectedindexchanging="gvPenelitian_SelectedIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="AKSI">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkBtnPilih" runat="server" CommandArgument='<%# Eval("ID_PROPOSAL") %>'
                                            CommandName="Pilih">Pilih</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NAMA" HeaderText="NAMA" />
                                <asp:BoundField DataField="FAK" HeaderText="FAKULTAS" />
                                <asp:BoundField DataField="PRODI" HeaderText="PRODI" />
                                <asp:BoundField DataField="judul" HeaderText="JUDUL" />
                                <asp:BoundField DataField="deskripsi" HeaderText="STATUS" />
                                <asp:BoundField DataField="TAHUN_AKADEMIK" HeaderText="PERIODE" />
                            </Columns>
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Reviewer Penelitian" ID="TabPanel2">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvPenelitian0" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle"
                            RowStyle-CssClass="RowStyle" SelectedRowStyle-CssClass="SelectedRowStyle" Width="926px"
                            OnRowCommand="gvPenelitian0_RowCommand" 
                            onselectedindexchanging="gvPenelitian0_SelectedIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Input Nilai">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkBtnRev1" runat="server" CommandArgument='<%# Eval("ID_PROPOSAL") %>'
                                            CommandName="rev1">Reviewer 1</asp:LinkButton>
                                        <asp:LinkButton ID="LinkBtnRev2" runat="server" CommandArgument='<%# Eval("ID_PROPOSAL") %>'
                                            CommandName="rev2">Reviewer 2</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NAMA" HeaderText="NAMA" />
                                <asp:BoundField DataField="FAK" HeaderText="FAKULTAS" />
                                <asp:BoundField DataField="PRODI" HeaderText="PRODI" />
                                <asp:BoundField DataField="judul" HeaderText="JUDUL" />
                                <asp:BoundField DataField="deskripsi" HeaderText="STATUS" />
                                <asp:BoundField DataField="TAHUN_AKADEMIK" HeaderText="PERIODE" />
                                <asp:BoundField DataField="REVIEWER1" HeaderText="REVIEWER1" />
                                <asp:BoundField DataField="REVIEWER2" HeaderText="REVIEWER2" />
                            </Columns>
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
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
                            <asp:Label ID="lblIdProp" runat="server"></asp:Label>
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
    </asp:UpdatePanel> <asp:Button ID="BtnSimpan" runat="server" Text="Simpan" 
            onclick="BtnSimpan_Click" />
        <asp:Button ID="btnBatalKeg" runat="server" OnClick="btnBatalKeg_Click" Text="Batal" />
    </asp:Panel>
</asp:Content>
