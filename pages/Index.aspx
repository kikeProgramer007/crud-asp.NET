<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD.pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:800px">
            <h2>Listado de registros</h2>
            <br />
            <div class="container">
                <div class="row">
                    <div class="col align-self-end">
                         <asp:Button runat="server" Text="Create" CssClass="btn  btn-warning" ID="btnCreate" OnClick="btnCreate_Click"/>
                    </div>
                </div>
            </div>
            <br />
            <div class="container row">
                <div class="table small">
                    <asp:GridView runat="server" ID="gvUsuarios" class="table table-borderles table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="Opciones del administrador">
                                <ItemTemplate>
                                    
                                    <asp:Button runat="server" Text="Read" CssClass="btn  btn-info btn-sm" ID="btnRead" OnClick="btnRead_Click"/>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-warning btn-sm" />
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn  btn-danger btn-sm" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            
         
            
                </div>
            </div>
        </div>
    </form>
</asp:Content>
