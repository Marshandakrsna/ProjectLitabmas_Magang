﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Homev3_vertical_menu.Master" AutoEventWireup="true" CodeBehind="DekanListReview.aspx.cs" Inherits="silppm_v1e2.WebForm47" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    
    <asp:Label ID="Label1" runat="server" 
        Text="Tidak ada data untuk ditampilkan." 
        Visible="False"></asp:Label>
   
    <asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id_proposal" style="margin-top: 0px" CssClass="GridViewStyle" 
             HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" 
             onrowcommand="GridView1_RowCommand" Width="909px">
        <Columns>
            <asp:TemplateField HeaderText="AKSI">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="review"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" >Pilih</asp:LinkButton>
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
    
    </p>
</asp:Content>
