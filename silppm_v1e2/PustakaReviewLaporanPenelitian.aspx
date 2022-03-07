<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="PustakaReviewLaporanPenelitian.aspx.cs" Inherits="silppm_v1e2.WebForm39" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<fieldset>

         <br />

        <legend class="style1"><strong>Laporan Penelitian yang perlu di Review :</strong></legend>
    
   
    <asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id_proposal" style="margin-top: 0px" CssClass="GridViewStyle" 
             HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" 
             onrowcommand="GridView2_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="AKSI">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="review"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" >Review</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Nama" DataField="nama" />
            <asp:BoundField HeaderText="Judul" DataField="judul" />
            <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>

<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>

<PagerStyle CssClass="PagerStyle"></PagerStyle>

<RowStyle CssClass="RowStyle"></RowStyle>

<SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
    </asp:GridView>
    
   </fieldset>
</asp:Content>
