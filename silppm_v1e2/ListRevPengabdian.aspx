<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="ListRevPengabdian.aspx.cs" Inherits="silppm_v1e2.WebForm31" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<fieldset>

         <br />

        <legend class="style1"><strong>Proposal Pengabdian yang perlu di Review :</strong></legend>
    
    
    <asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        DataKeyNames="id_proposal" style="margin-top: 0px" CssClass="GridViewStyle" 
             HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" 
             onrowcommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="AKSI" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="pilih" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                        Text="Pilih"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Judul" DataField="Judul_kegiatan" />
            <asp:BoundField HeaderText="Jenis" DataField="jenis_pengabdian" />
            <asp:BoundField HeaderText="Status" DataField="DESKRIPSI" />
        </Columns>

<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>

<PagerStyle CssClass="PagerStyle"></PagerStyle>

<RowStyle CssClass="RowStyle"></RowStyle>

<SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
    </asp:GridView>
    
    
    </fieldset>
</asp:Content>
