<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Banco.CapaDatos.capalogica.capapresentacion.Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Clientes</title>
    <link href="~/CSS/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="inicio.aspx">Inicio</a></li>
                <li><a class="active" href="Clientes.aspx">Clientes</a></li>
                <li><a href="Cuentas.aspx">Cuentas</a></li>
                <li><a href="Contact.aspx">Contactos</a></li>
                <li><a href="AcercaDe.aspx">Acerca de</a></li>
            </ul>
        </div>
        <div>
            <h1>Gestion de Clientes</h1>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay clientes registrados"></asp:GridView>
        </div>
        <div>
            <asp:Label ID="lblCodigo" runat="server" Text="Codigo"></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEdad" runat="server" Text="Edad"></asp:Label>
            <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblSaldo" runat="server" Text="Saldo"></asp:Label>
            <asp:TextBox ID="txtSaldo" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cliente" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnBorrar" runat="server" Text="Borrar Cliente" OnClick="btnBorrar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar Cliente" OnClick="btnEditar_Click" />
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>