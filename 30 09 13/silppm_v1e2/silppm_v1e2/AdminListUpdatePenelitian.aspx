<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminListUpdatePenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm26" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Berikut Daftar Proposal Penelitian :</p>
    <asp:GridView ID="GridView2" 
            runat="server" AutoGenerateColumns="False" 
            onrowcommand="GridView2_RowCommand" CssClass="GridViewStyle" 
            HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" DataKeyNames="id_proposal" 
        Width="909px" AllowPaging="True">
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
    </asp:Content>
