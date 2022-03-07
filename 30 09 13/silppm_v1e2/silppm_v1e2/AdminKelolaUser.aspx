<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminKelolaUser.aspx.cs" Inherits="silppm_v1e2.WebForm21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Daftar Dosen :</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" DataKeyNames="npp" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcommand="GridView1_RowCommand" CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
        SelectedRowStyle-CssClass="SelectedRowStyle" Width="926px">
            <Columns>
                <asp:TemplateField HeaderText="Sesuaikan">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="UbahRole" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Ubah Role User</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="npp" HeaderText="NPP" />
                <asp:BoundField DataField="nama" HeaderText="Nama" />
                <asp:BoundField HeaderText="Role" DataField="DESKRIPSI" />
            </Columns>

<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>

<PagerStyle CssClass="PagerStyle"></PagerStyle>

<RowStyle CssClass="RowStyle"></RowStyle>

<SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
        </asp:GridView>
        <asp:HiddenField ID="hiddenTmpNpp" runat="server" />
    </p>
    <asp:Panel ID="panelUbah" runat="server">
        Pilih Role :<br />
        <asp:RadioButtonList ID="listRole" runat="server">
            <asp:ListItem>Assesor</asp:ListItem>
            <asp:ListItem>Dosen</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Ubah Role" />
    </asp:Panel>
</asp:Content>
