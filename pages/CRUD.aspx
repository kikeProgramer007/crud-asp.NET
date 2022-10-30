<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUD.pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbNombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Edad</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbEdad"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbEmail"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de nacimiento</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbDate"></asp:TextBox>
            </div>
            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" Visible="false" CssClass="btn btn-primary" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" CssClass="btn btn-primary" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible="false" CssClass="btn btn-primary" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Visible="true" CssClass="btn btn-dark" />

        </div>

    </form>
</asp:Content>
